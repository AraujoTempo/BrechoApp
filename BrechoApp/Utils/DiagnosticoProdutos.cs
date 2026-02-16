using BrechoApp.Data;
using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.IO;

namespace BrechoApp.Utils
{
    /// <summary>
    /// Utilitário de diagnóstico para verificar inconsistências entre ItemLote e Produtos.
    /// Este script ajuda a identificar produtos onde PrecoSugeridoDoItem e PrecoVendaDoItem
    /// têm valores incorretos ou inconsistentes.
    /// </summary>
    public static class DiagnosticoProdutos
    {
        private static readonly string _connectionString = DatabaseConfig.ConnectionString;

        /// <summary>
        /// Estrutura para representar uma inconsistência encontrada.
        /// </summary>
        public class Inconsistencia
        {
            public string CodigoProduto { get; set; }
            public string CodigoItemLote { get; set; }
            public int ItemLoteId { get; set; }
            public double ItemPrecoSugerido { get; set; }
            public double ItemPrecoVenda { get; set; }
            public double ProdutoPrecoSugerido { get; set; }
            public double ProdutoPrecoVenda { get; set; }
            public string StatusProduto { get; set; }
            public string Problema { get; set; }
        }

        /// <summary>
        /// Verifica inconsistências entre ItemLote e Produtos.
        /// Retorna uma lista de inconsistências encontradas.
        /// </summary>
        public static List<Inconsistencia> VerificarInconsistencias()
        {
            var inconsistencias = new List<Inconsistencia>();

            using var connection = new SqliteConnection(_connectionString);
            connection.Open();

            // Query para comparar ItemLote com Produtos
            var command = connection.CreateCommand();
            command.CommandText = @"
                SELECT 
                    i.Id AS ItemLoteId,
                    i.CodigoLoteRecebimento,
                    i.CodigoProdutoGerado,
                    i.PrecoSugeridoDoItem AS ItemPrecoSugerido,
                    i.PrecoVendaDoItem AS ItemPrecoVenda,
                    p.PrecoSugeridoDoItem AS ProdutoPrecoSugerido,
                    p.PrecoVendaDoItem AS ProdutoPrecoVenda,
                    p.StatusDoProduto
                FROM ItemLote i
                LEFT JOIN Produtos p ON i.CodigoProdutoGerado = p.CodigoProduto
                WHERE i.CodigoProdutoGerado IS NOT NULL
                ORDER BY i.CodigoLoteRecebimento, i.Id
            ";

            using var reader = command.ExecuteReader();
            while (reader.Read())
            {
                var itemId = reader.GetInt32(0);
                var codigoLote = reader.GetString(1);
                var codigoProduto = reader.IsDBNull(2) ? null : reader.GetString(2);
                var itemPrecoSugerido = reader.GetDouble(3);
                var itemPrecoVenda = reader.GetDouble(4);

                // Se o produto não existe mas o item tem código gerado
                if (reader.IsDBNull(5))
                {
                    inconsistencias.Add(new Inconsistencia
                    {
                        CodigoProduto = codigoProduto ?? "NULL",
                        CodigoItemLote = codigoLote,
                        ItemLoteId = itemId,
                        ItemPrecoSugerido = itemPrecoSugerido,
                        ItemPrecoVenda = itemPrecoVenda,
                        ProdutoPrecoSugerido = 0,
                        ProdutoPrecoVenda = 0,
                        StatusProduto = "NÃO EXISTE",
                        Problema = "ItemLote tem CodigoProdutoGerado mas Produto não existe"
                    });
                    continue;
                }

                var produtoPrecoSugerido = reader.GetDouble(5);
                var produtoPrecoVenda = reader.GetDouble(6);
                var statusProduto = reader.GetString(7);

                // Verifica se os preços são diferentes entre ItemLote e Produto
                bool precoSugeridoDiferente = Math.Abs(itemPrecoSugerido - produtoPrecoSugerido) > 0.01;
                bool precoVendaDiferente = Math.Abs(itemPrecoVenda - produtoPrecoVenda) > 0.01;

                if (precoSugeridoDiferente || precoVendaDiferente)
                {
                    var problemas = new List<string>();
                    if (precoSugeridoDiferente)
                        problemas.Add("PrecoSugerido diferente");
                    if (precoVendaDiferente)
                        problemas.Add("PrecoVenda diferente");

                    inconsistencias.Add(new Inconsistencia
                    {
                        CodigoProduto = codigoProduto,
                        CodigoItemLote = codigoLote,
                        ItemLoteId = itemId,
                        ItemPrecoSugerido = itemPrecoSugerido,
                        ItemPrecoVenda = itemPrecoVenda,
                        ProdutoPrecoSugerido = produtoPrecoSugerido,
                        ProdutoPrecoVenda = produtoPrecoVenda,
                        StatusProduto = statusProduto,
                        Problema = string.Join(", ", problemas)
                    });
                }
            }

            return inconsistencias;
        }

        /// <summary>
        /// Verifica produtos onde PrecoSugeridoDoItem é igual a PrecoVendaDoItem.
        /// Isto pode indicar produtos que não foram atualizados corretamente.
        /// </summary>
        public static List<string> VerificarProdutosComPrecosIguais()
        {
            var produtos = new List<string>();

            using var connection = new SqliteConnection(_connectionString);
            connection.Open();

            var command = connection.CreateCommand();
            command.CommandText = @"
                SELECT 
                    CodigoProduto,
                    PrecoSugeridoDoItem,
                    PrecoVendaDoItem,
                    StatusDoProduto,
                    UltimaAtualizacao
                FROM Produtos
                WHERE ABS(PrecoSugeridoDoItem - PrecoVendaDoItem) < 0.01
                  AND StatusDoProduto = 'Disponível'
                ORDER BY UltimaAtualizacao DESC
            ";

            using var reader = command.ExecuteReader();
            while (reader.Read())
            {
                var codigo = reader.GetString(0);
                var preco = reader.GetDouble(1);
                var status = reader.GetString(3);
                var atualizacao = reader.GetString(4);

                produtos.Add($"{codigo} | PrecoSugerido=PrecoVenda={preco:F2} | Status={status} | Atualizado em {atualizacao}");
            }

            return produtos;
        }

        /// <summary>
        /// Corrige inconsistências copiando os valores do ItemLote para o Produto.
        /// ATENÇÃO: Esta operação modifica o banco de dados!
        /// Retorna o número de produtos corrigidos.
        /// </summary>
        public static int CorrigirInconsistencias()
        {
            var inconsistencias = VerificarInconsistencias();
            int corrigidos = 0;

            using var connection = new SqliteConnection(_connectionString);
            connection.Open();

            foreach (var inc in inconsistencias)
            {
                if (inc.StatusProduto == "NÃO EXISTE")
                    continue; // Não podemos corrigir produtos que não existem

                // Só corrige produtos Disponíveis para evitar alterar produtos vendidos/devolvidos
                if (inc.StatusProduto != "Disponível")
                    continue;

                var command = connection.CreateCommand();
                command.CommandText = @"
                    UPDATE Produtos 
                    SET PrecoSugeridoDoItem = $precoSugerido,
                        PrecoVendaDoItem = $precoVenda,
                        UltimaAtualizacao = $atualizacao
                    WHERE CodigoProduto = $codigo
                ";

                command.Parameters.AddWithValue("$codigo", inc.CodigoProduto);
                command.Parameters.AddWithValue("$precoSugerido", inc.ItemPrecoSugerido);
                command.Parameters.AddWithValue("$precoVenda", inc.ItemPrecoVenda);
                command.Parameters.AddWithValue("$atualizacao", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));

                int rows = command.ExecuteNonQuery();
                corrigidos += rows;
            }

            return corrigidos;
        }

        /// <summary>
        /// Gera um relatório em arquivo texto com todas as inconsistências encontradas.
        /// </summary>
        public static string GerarRelatorio()
        {
            var inconsistencias = VerificarInconsistencias();
            var produtosIguais = VerificarProdutosComPrecosIguais();

            string logPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "logs");
            if (!Directory.Exists(logPath))
                Directory.CreateDirectory(logPath);

            string reportFile = Path.Combine(logPath, $"diagnostico_produtos_{DateTime.Now:yyyy-MM-dd_HHmmss}.txt");

            using var writer = new StreamWriter(reportFile);

            writer.WriteLine("=".PadRight(80, '='));
            writer.WriteLine($"DIAGNÓSTICO DE PRODUTOS - {DateTime.Now:yyyy-MM-dd HH:mm:ss}");
            writer.WriteLine("=".PadRight(80, '='));
            writer.WriteLine();

            writer.WriteLine($"Total de inconsistências encontradas: {inconsistencias.Count}");
            writer.WriteLine($"Total de produtos com preços iguais: {produtosIguais.Count}");
            writer.WriteLine();

            if (inconsistencias.Count > 0)
            {
                writer.WriteLine("-".PadRight(80, '-'));
                writer.WriteLine("INCONSISTÊNCIAS ENTRE ITEMLOTE E PRODUTOS");
                writer.WriteLine("-".PadRight(80, '-'));
                writer.WriteLine();

                foreach (var inc in inconsistencias)
                {
                    writer.WriteLine($"Código Produto: {inc.CodigoProduto}");
                    writer.WriteLine($"  Lote: {inc.CodigoItemLote} | Item ID: {inc.ItemLoteId}");
                    writer.WriteLine($"  Status: {inc.StatusProduto}");
                    writer.WriteLine($"  Problema: {inc.Problema}");
                    writer.WriteLine($"  ItemLote    -> PrecoSugerido: {inc.ItemPrecoSugerido:F2} | PrecoVenda: {inc.ItemPrecoVenda:F2}");
                    writer.WriteLine($"  Produto     -> PrecoSugerido: {inc.ProdutoPrecoSugerido:F2} | PrecoVenda: {inc.ProdutoPrecoVenda:F2}");
                    writer.WriteLine();
                }
            }

            if (produtosIguais.Count > 0)
            {
                writer.WriteLine("-".PadRight(80, '-'));
                writer.WriteLine("PRODUTOS COM PREÇOS IGUAIS (Disponíveis)");
                writer.WriteLine("-".PadRight(80, '-'));
                writer.WriteLine();

                foreach (var produto in produtosIguais)
                {
                    writer.WriteLine(produto);
                }
                writer.WriteLine();
            }

            writer.WriteLine("=".PadRight(80, '='));
            writer.WriteLine("FIM DO RELATÓRIO");
            writer.WriteLine("=".PadRight(80, '='));

            return reportFile;
        }
    }
}
