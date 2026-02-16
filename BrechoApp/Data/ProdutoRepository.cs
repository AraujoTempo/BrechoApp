using BrechoApp.Models;
using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;

namespace BrechoApp.Data
{
    /// <summary>
    /// Repositório responsável por gerenciar produtos.
    /// Totalmente compatível com o modelo PNx-Ly-Pz.
    /// Inclui criação, atualização, listagens, exclusão e controle de status.
    /// </summary>
    public class ProdutoRepository
    {
        // ---------------------------------------------------------------------
        // STRING DE CONEXÃO
        //
        // Mantém a conexão centralizada. Usa a mesma conexão do restante
        // do sistema, garantindo consistência.
        // ---------------------------------------------------------------------
        private readonly string _connectionString = DatabaseConfig.ConnectionString;

        // =====================================================================
        // CRIAR PRODUTO
        //
        // Usado na aprovação do lote. Cada item gera um produto.
        // =====================================================================
        public void CriarProduto(Produto produto)
        {
            using var connection = new SqliteConnection(_connectionString);
            connection.Open();

            var command = connection.CreateCommand();

            command.CommandText = @"
                INSERT INTO Produtos (
                    CodigoProduto,
                    CodigoParceiro,
                    CodigoLoteRecebimento,
                    NomeDoItem,
                    MarcaDoItem,
                    ObservacaoDoItem,
                    CategoriaDoItem,
                    TamanhoCorDoItem,
                    PrecoVendaDoItem,
                    StatusDoProduto,
                    DataCriacao,
                    UltimaAtualizacao
                ) VALUES (
                    $codigo, $parceiro, $lote, $nome, $marca, $obs, $cat, $tamcor,
                    $precoVenda, $status, $criacao, $atualizacao
                );
            ";

            command.Parameters.AddWithValue("$codigo", produto.CodigoProduto);
            command.Parameters.AddWithValue("$parceiro", produto.CodigoParceiro);
            command.Parameters.AddWithValue("$lote", produto.CodigoLoteRecebimento);
            command.Parameters.AddWithValue("$nome", produto.NomeDoItem);
            command.Parameters.AddWithValue("$marca", produto.MarcaDoItem);
            command.Parameters.AddWithValue("$obs", produto.ObservacaoDoItem ?? "");
            command.Parameters.AddWithValue("$cat", produto.CategoriaDoItem);
            command.Parameters.AddWithValue("$tamcor", produto.TamanhoCorDoItem);
            command.Parameters.AddWithValue("$precoVenda", produto.PrecoVendaDoItem);
            command.Parameters.AddWithValue("$status", produto.StatusDoProduto);

            command.Parameters.AddWithValue("$criacao",
                produto.DataCriacao.ToString("yyyy-MM-dd HH:mm:ss"));
            command.Parameters.AddWithValue("$atualizacao",
                produto.UltimaAtualizacao.ToString("yyyy-MM-dd HH:mm:ss"));

            command.ExecuteNonQuery();
        }

        // =====================================================================
        // ATUALIZAR PRODUTO
        //
        // Usado quando o lote é reaberto e o produto precisa ser sincronizado.
        // =====================================================================
        public void AtualizarProduto(Produto produto)
        {
            using var connection = new SqliteConnection(_connectionString);
            connection.Open();

            var command = connection.CreateCommand();

            command.CommandText = @"
                UPDATE Produtos SET
                    NomeDoItem = $nome,
                    MarcaDoItem = $marca,
                    ObservacaoDoItem = $obs,
                    CategoriaDoItem = $cat,
                    TamanhoCorDoItem = $tamcor,
                    PrecoVendaDoItem = $precoVenda,
                    StatusDoProduto = $status,
                    CodigoParceiro = $parceiro,
                    UltimaAtualizacao = $atualizacao
                WHERE CodigoProduto = $codigo;
            ";

            command.Parameters.AddWithValue("$codigo", produto.CodigoProduto);
            command.Parameters.AddWithValue("$parceiro", produto.CodigoParceiro);
            command.Parameters.AddWithValue("$nome", produto.NomeDoItem);
            command.Parameters.AddWithValue("$marca", produto.MarcaDoItem);
            command.Parameters.AddWithValue("$obs", produto.ObservacaoDoItem ?? "");
            command.Parameters.AddWithValue("$cat", produto.CategoriaDoItem);
            command.Parameters.AddWithValue("$tamcor", produto.TamanhoCorDoItem);
            command.Parameters.AddWithValue("$precoVenda", produto.PrecoVendaDoItem);
            command.Parameters.AddWithValue("$status", produto.StatusDoProduto);

            command.Parameters.AddWithValue("$atualizacao",
                produto.UltimaAtualizacao.ToString("yyyy-MM-dd HH:mm:ss"));

            command.ExecuteNonQuery();
        }

        // =====================================================================
        // ATUALIZAR STATUS DO PRODUTO
        //
        // Usado em vendas, devoluções, reservas, etc.
        // =====================================================================
        public void AtualizarStatus(string codigoProduto, string novoStatus)
        {
            using var connection = new SqliteConnection(_connectionString);
            connection.Open();

            var command = connection.CreateCommand();

            command.CommandText = @"
                UPDATE Produtos SET
                    StatusDoProduto = $status,
                    UltimaAtualizacao = $atualizacao
                WHERE CodigoProduto = $codigo;
            ";

            command.Parameters.AddWithValue("$codigo", codigoProduto);
            command.Parameters.AddWithValue("$status", novoStatus);
            command.Parameters.AddWithValue("$atualizacao",
                DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));

            command.ExecuteNonQuery();
        }

        // =====================================================================
        // BUSCAR PRODUTO POR CÓDIGO
        //
        // Retorna um produto completo ou null se não existir.
        // =====================================================================
        public Produto BuscarPorCodigo(string codigoProduto)
        {
            using var connection = new SqliteConnection(_connectionString);
            connection.Open();

            var command = connection.CreateCommand();

            command.CommandText = @"
                SELECT *
                FROM Produtos
                WHERE CodigoProduto = $codigo;
            ";

            command.Parameters.AddWithValue("$codigo", codigoProduto);

            using var reader = command.ExecuteReader();

            if (!reader.Read())
                return null;

            return Mapear(reader);
        }














        // =====================================================================
        // LISTAR PRODUTOS POR PARCEIRO
        //
        // Usado em relatórios, extratos e histórico do parceiro.
        // =====================================================================
        public List<Produto> ListarPorParceiro(string codigoParceiro)
        {
            var produtos = new List<Produto>();

            using var connection = new SqliteConnection(_connectionString);
            connection.Open();

            var command = connection.CreateCommand();

            command.CommandText = @"
                SELECT *
                FROM Produtos
                WHERE CodigoParceiro = $parceiro
                ORDER BY DataCriacao DESC;
            ";

            command.Parameters.AddWithValue("$parceiro", codigoParceiro);

            using var reader = command.ExecuteReader();

            while (reader.Read())
                produtos.Add(Mapear(reader));

            return produtos;
        }
        // =====================================================================
        // LISTAR PRODUTOS DISPONÍVEIS PARA VENDA
        //
        // Usado na tela de vendas e no estoque.
        // =====================================================================
        public List<Produto> ListarProdutosDisponiveis()
        {
            var produtos = new List<Produto>();

            using var connection = new SqliteConnection(_connectionString);
            connection.Open();

            var command = connection.CreateCommand();

            command.CommandText = @"
                SELECT *
                FROM Produtos
                WHERE StatusDoProduto = 'Disponível'
                ORDER BY DataCriacao DESC;
            ";

            using var reader = command.ExecuteReader();

            while (reader.Read())
                produtos.Add(Mapear(reader));

            return produtos;
        }

        // =====================================================================
        // EXCLUIR PRODUTO
        //
        // Remove um produto do banco. Usado em casos de erro ou limpeza.
        // =====================================================================
        public void ExcluirProduto(string codigoProduto)
        {
            using var connection = new SqliteConnection(_connectionString);
            connection.Open();

            var command = connection.CreateCommand();

            command.CommandText = @"
                DELETE FROM Produtos
                WHERE CodigoProduto = $codigo;
            ";

            command.Parameters.AddWithValue("$codigo", codigoProduto);

            command.ExecuteNonQuery();
        }

        // =====================================================================
        // MAPEAR SQLITE → OBJETO Produto
        //
        // Converte um registro do banco em um objeto Produto.
        // =====================================================================
        private Produto Mapear(SqliteDataReader reader)
        {
            return new Produto
            {
                CodigoProduto = reader["CodigoProduto"].ToString(),
                CodigoParceiro = reader["CodigoParceiro"].ToString(),
                CodigoLoteRecebimento = reader["CodigoLoteRecebimento"].ToString(),
                NomeDoItem = reader["NomeDoItem"].ToString(),
                MarcaDoItem = reader["MarcaDoItem"].ToString(),
                ObservacaoDoItem = reader["ObservacaoDoItem"]?.ToString(),
                CategoriaDoItem = reader["CategoriaDoItem"].ToString(),
                TamanhoCorDoItem = reader["TamanhoCorDoItem"].ToString(),
                PrecoVendaDoItem = Convert.ToDouble(reader["PrecoVendaDoItem"]),
                StatusDoProduto = reader["StatusDoProduto"].ToString(),
                DataCriacao = DateTime.Parse(reader["DataCriacao"].ToString()),
                UltimaAtualizacao = DateTime.Parse(reader["UltimaAtualizacao"].ToString())
            };
        }
    }
}
