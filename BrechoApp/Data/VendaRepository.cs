using BrechoApp.Models;
using BrechoApp.Enums;
using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Globalization;

namespace BrechoApp.Data
{
    public class VendaRepository
    {
        private readonly string _connectionString = DatabaseConfig.ConnectionString;

        public VendaRepository()
        {
            DatabaseInitializer.Initialize();
        }

        // ============================================================
        //  GERA PRÓXIMO CÓDIGO DE VENDA (V-1, V-2, V-3...)
        // ============================================================
        public string GerarProximoCodigoVenda()
        {
            using var connection = new SqliteConnection(_connectionString);
            connection.Open();

            string sql = @"
                SELECT CodigoVenda
                FROM Vendas
                WHERE CodigoVenda LIKE 'V-%'
                ORDER BY CAST(SUBSTR(CodigoVenda, 3) AS INTEGER) DESC
                LIMIT 1;
            ";

            using var cmd = new SqliteCommand(sql, connection);
            var result = cmd.ExecuteScalar()?.ToString();

            if (string.IsNullOrWhiteSpace(result))
                return "V-1";

            string numeroStr = result.Length > 2 ? result.Substring(2) : "0";

            if (int.TryParse(numeroStr, out int numero))
                return $"V-{numero + 1}";

            return "V-1";
        }

        // ============================================================
        //  SALVAR VENDA (com itens e pagamentos)
        // ============================================================
        public void SalvarVenda(Venda venda)
        {
            using var connection = new SqliteConnection(_connectionString);
            connection.Open();

            using var transaction = connection.BeginTransaction();

            try
            {
                // 1. Inserir venda principal
                string sqlVenda = @"
                    INSERT INTO Vendas (
                        CodigoVenda, IdVendedor, IdCliente, DataVenda,
                        ValorTotalOriginal, DescontoPercentual, DescontoValor, Campanha,
                        DescontoCampanhaPercentual, DescontoCampanha, ValorTotalFinal,
                        Observacoes, DataCriacao
                    ) VALUES (
                        @CodigoVenda, @IdVendedor, @IdCliente, @DataVenda,
                        @ValorTotalOriginal, @DescontoPercentual, @DescontoValor, @Campanha,
                        @DescontoCampanhaPercentual, @DescontoCampanha, @ValorTotalFinal,
                        @Observacoes, @DataCriacao
                    );
                    SELECT last_insert_rowid();
                ";

                int idVenda;
                using (var cmd = new SqliteCommand(sqlVenda, connection, transaction))
                {
                    cmd.Parameters.AddWithValue("@CodigoVenda", venda.CodigoVenda);
                    cmd.Parameters.AddWithValue("@IdVendedor", venda.IdVendedor);
                    cmd.Parameters.AddWithValue("@IdCliente", venda.IdCliente);
                    cmd.Parameters.AddWithValue("@DataVenda", venda.DataVenda.ToString("yyyy-MM-dd HH:mm:ss"));
                    cmd.Parameters.AddWithValue("@ValorTotalOriginal", venda.ValorTotalOriginal);
                    cmd.Parameters.AddWithValue("@DescontoPercentual", venda.DescontoPercentual);
                    cmd.Parameters.AddWithValue("@DescontoValor", venda.DescontoValor);
                    cmd.Parameters.AddWithValue("@Campanha", (object?)venda.Campanha ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@DescontoCampanhaPercentual", venda.DescontoCampanhaPercentual);
                    cmd.Parameters.AddWithValue("@DescontoCampanha", venda.DescontoCampanha);
                    cmd.Parameters.AddWithValue("@ValorTotalFinal", venda.ValorTotalFinal);
                    cmd.Parameters.AddWithValue("@Observacoes", (object?)venda.Observacoes ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@DataCriacao", venda.DataCriacao.ToString("yyyy-MM-dd HH:mm:ss"));

                    idVenda = Convert.ToInt32(cmd.ExecuteScalar());
                }

                // 2. Inserir itens da venda
                string sqlItem = @"
                    INSERT INTO VendasItens (
                        IdVenda, IdProduto, IdFornecedor, PrecoOriginal, PrecoFinalNegociado
                    ) VALUES (
                        @IdVenda, @IdProduto, @IdFornecedor, @PrecoOriginal, @PrecoFinalNegociado
                    );
                ";

                foreach (var item in venda.Itens)
                {
                    using var cmdItem = new SqliteCommand(sqlItem, connection, transaction);
                    cmdItem.Parameters.AddWithValue("@IdVenda", idVenda);
                    cmdItem.Parameters.AddWithValue("@IdProduto", item.IdProduto);
                    cmdItem.Parameters.AddWithValue("@IdFornecedor", item.IdFornecedor);
                    cmdItem.Parameters.AddWithValue("@PrecoOriginal", item.PrecoOriginal);
                    cmdItem.Parameters.AddWithValue("@PrecoFinalNegociado", item.PrecoFinalNegociado);
                    cmdItem.ExecuteNonQuery();
                }

                // 3. Inserir pagamentos
                string sqlPagamento = @"
                    INSERT INTO VendasPagamentos (
                        IdVenda, TipoPagamento, Valor
                    ) VALUES (
                        @IdVenda, @TipoPagamento, @Valor
                    );
                ";

                foreach (var pag in venda.Pagamentos)
                {
                    using var cmdPag = new SqliteCommand(sqlPagamento, connection, transaction);
                    cmdPag.Parameters.AddWithValue("@IdVenda", idVenda);
                    cmdPag.Parameters.AddWithValue("@TipoPagamento", pag.Tipo.ToString());
                    cmdPag.Parameters.AddWithValue("@Valor", pag.Valor);
                    cmdPag.ExecuteNonQuery();
                }

                // 4. Atualizar status dos produtos
                string sqlUpdateStatus = @"
                    UPDATE Produtos 
                    SET StatusDoProduto = 'Vendido',
                        UltimaAtualizacao = @DataAtualizacao
                    WHERE CodigoProduto = @CodigoProduto;
                ";

                foreach (var item in venda.Itens)
                {
                    using var cmdStatus = new SqliteCommand(sqlUpdateStatus, connection, transaction);
                    cmdStatus.Parameters.AddWithValue("@CodigoProduto", item.IdProduto);
                    cmdStatus.Parameters.AddWithValue("@DataAtualizacao", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                    cmdStatus.ExecuteNonQuery();
                }

                transaction.Commit();
            }
            catch
            {
                transaction.Rollback();
                throw;
            }
        }

        // ============================================================
        //  ATUALIZAR VENDA
        // ============================================================
        public void AtualizarVenda(Venda venda)
        {
            using var connection = new SqliteConnection(_connectionString);
            connection.Open();

            string sql = @"
                 UPDATE Vendas
                 SET 
                     IdVendedor                 = @IdVendedor,
                     IdCliente                  = @IdCliente,
                     DataVenda                  = @DataVenda,
                     ValorTotalOriginal         = @ValorTotalOriginal,
                     DescontoPercentual         = @DescontoPercentual,
                     DescontoValor              = @DescontoValor,
                     Campanha                   = @Campanha,
                     DescontoCampanhaPercentual = @DescontoCampanhaPercentual,
                     DescontoCampanha           = @DescontoCampanha,
                     ValorTotalFinal            = @ValorTotalFinal,
                     Observacoes                = @Observacoes
                 WHERE IdVenda = @IdVenda;
             ";

            using var cmd = new SqliteCommand(sql, connection);

            cmd.Parameters.AddWithValue("@IdVenda", venda.IdVenda);
            cmd.Parameters.AddWithValue("@IdVendedor", venda.IdVendedor);
            cmd.Parameters.AddWithValue("@IdCliente", venda.IdCliente);
            cmd.Parameters.AddWithValue("@DataVenda", venda.DataVenda.ToString("yyyy-MM-dd HH:mm:ss"));
            cmd.Parameters.AddWithValue("@ValorTotalOriginal", venda.ValorTotalOriginal);
            cmd.Parameters.AddWithValue("@DescontoPercentual", venda.DescontoPercentual);
            cmd.Parameters.AddWithValue("@DescontoValor", venda.DescontoValor);
            cmd.Parameters.AddWithValue("@Campanha", (object?)venda.Campanha ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@DescontoCampanhaPercentual", venda.DescontoCampanhaPercentual);
            cmd.Parameters.AddWithValue("@DescontoCampanha", venda.DescontoCampanha);
            cmd.Parameters.AddWithValue("@ValorTotalFinal", venda.ValorTotalFinal);
            cmd.Parameters.AddWithValue("@Observacoes", (object?)venda.Observacoes ?? DBNull.Value);

            cmd.ExecuteNonQuery();
        }

        // ============================================================
        //  BUSCAR VENDA POR CÓDIGO
        // ============================================================
        public Venda BuscarPorCodigo(string codigoVenda)
        {
            using var connection = new SqliteConnection(_connectionString);
            connection.Open();

            string sqlVenda = @"
                SELECT IdVenda, CodigoVenda, IdVendedor, IdCliente, DataVenda,
                       ValorTotalOriginal, DescontoPercentual, DescontoValor, Campanha,
                       DescontoCampanhaPercentual, DescontoCampanha, ValorTotalFinal,
                       Observacoes, DataCriacao
                FROM Vendas
                WHERE CodigoVenda = @CodigoVenda
                LIMIT 1;
            ";

            Venda venda = null;

            using (var cmd = new SqliteCommand(sqlVenda, connection))
            {
                cmd.Parameters.AddWithValue("@CodigoVenda", codigoVenda);
                using var reader = cmd.ExecuteReader();

                if (!reader.Read())
                    return null;

                venda = new Venda
                {
                    IdVenda = Convert.ToInt32(reader["IdVenda"]),
                    CodigoVenda = reader["CodigoVenda"].ToString(),
                    IdVendedor = reader["IdVendedor"].ToString(),
                    IdCliente = reader["IdCliente"].ToString(),
                    DataVenda = DateTime.Parse(reader["DataVenda"].ToString()),
                    ValorTotalOriginal = Convert.ToDouble(reader["ValorTotalOriginal"], CultureInfo.InvariantCulture),
                    DescontoPercentual = Convert.ToDouble(reader["DescontoPercentual"], CultureInfo.InvariantCulture),
                    DescontoValor = Convert.ToDouble(reader["DescontoValor"], CultureInfo.InvariantCulture),
                    Campanha = reader["Campanha"] == DBNull.Value ? null : reader["Campanha"].ToString(),
                    DescontoCampanhaPercentual = Convert.ToDouble(reader["DescontoCampanhaPercentual"], CultureInfo.InvariantCulture),
                    DescontoCampanha = Convert.ToDouble(reader["DescontoCampanha"], CultureInfo.InvariantCulture),
                    ValorTotalFinal = Convert.ToDouble(reader["ValorTotalFinal"], CultureInfo.InvariantCulture),
                    Observacoes = reader["Observacoes"]?.ToString(),
                    DataCriacao = DateTime.Parse(reader["DataCriacao"].ToString())
                };
            }

            if (venda != null)
            {
                venda.Itens = ListarItensPorVenda(venda.IdVenda);
                venda.Pagamentos = ListarPagamentosPorVenda(venda.IdVenda);
            }

            return venda;
        }

        // ============================================================
        //  LISTAR TODAS AS VENDAS
        // ============================================================
        public List<Venda> ListarVendas()
        {
            var lista = new List<Venda>();

            using var connection = new SqliteConnection(_connectionString);
            connection.Open();

            string sql = @"
                SELECT IdVenda, CodigoVenda, IdVendedor, IdCliente, DataVenda,
                       ValorTotalOriginal, DescontoPercentual, DescontoValor, Campanha,
                       DescontoCampanhaPercentual, DescontoCampanha, ValorTotalFinal,
                       Observacoes, DataCriacao
                FROM Vendas
                ORDER BY DataVenda DESC;
            ";

            using var cmd = new SqliteCommand(sql, connection);
            using var reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                var venda = new Venda
                {
                    IdVenda = Convert.ToInt32(reader["IdVenda"]),
                    CodigoVenda = reader["CodigoVenda"].ToString(),
                    IdVendedor = reader["IdVendedor"].ToString(),
                    IdCliente = reader["IdCliente"].ToString(),
                    DataVenda = DateTime.Parse(reader["DataVenda"].ToString()),
                    ValorTotalOriginal = Convert.ToDouble(reader["ValorTotalOriginal"], CultureInfo.InvariantCulture),
                    DescontoPercentual = Convert.ToDouble(reader["DescontoPercentual"], CultureInfo.InvariantCulture),
                    DescontoValor = Convert.ToDouble(reader["DescontoValor"], CultureInfo.InvariantCulture),
                    Campanha = reader["Campanha"] == DBNull.Value ? null : reader["Campanha"].ToString(),
                    DescontoCampanhaPercentual = Convert.ToDouble(reader["DescontoCampanhaPercentual"], CultureInfo.InvariantCulture),
                    DescontoCampanha = Convert.ToDouble(reader["DescontoCampanha"], CultureInfo.InvariantCulture),
                    ValorTotalFinal = Convert.ToDouble(reader["ValorTotalFinal"], CultureInfo.InvariantCulture),
                    Observacoes = reader["Observacoes"]?.ToString(),
                    DataCriacao = DateTime.Parse(reader["DataCriacao"].ToString())
                };

                venda.Pagamentos = ListarPagamentosPorVenda(venda.IdVenda);

                lista.Add(venda);
            }

            return lista;
        }

        // ============================================================
        //  LISTAR VENDAS POR PERÍODO
        // ============================================================
        public List<Venda> ListarVendasPorPeriodo(DateTime inicio, DateTime fim)
        {
            var lista = new List<Venda>();

            using var connection = new SqliteConnection(_connectionString);
            connection.Open();

            string sql = @"
                SELECT IdVenda, CodigoVenda, IdVendedor, IdCliente, DataVenda,
                       ValorTotalOriginal, DescontoPercentual, DescontoValor, Campanha,
                       DescontoCampanhaPercentual, DescontoCampanha, ValorTotalFinal,
                       Observacoes, DataCriacao
                FROM Vendas
                WHERE DataVenda BETWEEN @Inicio AND @Fim
                ORDER BY DataVenda DESC;
            ";

            using var cmd = new SqliteCommand(sql, connection);
            cmd.Parameters.AddWithValue("@Inicio", inicio.ToString("yyyy-MM-dd 00:00:00"));
            cmd.Parameters.AddWithValue("@Fim", fim.ToString("yyyy-MM-dd 23:59:59"));

            using var reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                var venda = new Venda
                {
                    IdVenda = Convert.ToInt32(reader["IdVenda"]),
                    CodigoVenda = reader["CodigoVenda"].ToString(),
                    IdVendedor = reader["IdVendedor"].ToString(),
                    IdCliente = reader["IdCliente"].ToString(),
                    DataVenda = DateTime.Parse(reader["DataVenda"].ToString()),
                    ValorTotalOriginal = Convert.ToDouble(reader["ValorTotalOriginal"], CultureInfo.InvariantCulture),
                    DescontoPercentual = Convert.ToDouble(reader["DescontoPercentual"], CultureInfo.InvariantCulture),
                    DescontoValor = Convert.ToDouble(reader["DescontoValor"], CultureInfo.InvariantCulture),
                    Campanha = reader["Campanha"] == DBNull.Value ? null : reader["Campanha"].ToString(),
                    DescontoCampanhaPercentual = Convert.ToDouble(reader["DescontoCampanhaPercentual"], CultureInfo.InvariantCulture),
                    DescontoCampanha = Convert.ToDouble(reader["DescontoCampanha"], CultureInfo.InvariantCulture),
                    ValorTotalFinal = Convert.ToDouble(reader["ValorTotalFinal"], CultureInfo.InvariantCulture),
                    Observacoes = reader["Observacoes"]?.ToString(),
                    DataCriacao = DateTime.Parse(reader["DataCriacao"].ToString())
                };

                venda.Pagamentos = ListarPagamentosPorVenda(venda.IdVenda);

                lista.Add(venda);
            }

            return lista;
        }

        // ============================================================
        //  LISTAR ITENS DE UMA VENDA
        // ============================================================
        public List<VendaItem> ListarItensPorVenda(int idVenda)
        {
            var lista = new List<VendaItem>();

            using var connection = new SqliteConnection(_connectionString);
            connection.Open();

            string sql = @"
                SELECT 
                    vi.IdVendaItem, vi.IdVenda, vi.IdProduto, vi.IdFornecedor,
                    vi.PrecoOriginal, vi.PrecoFinalNegociado,
                    p.NomeDoItem, p.MarcaDoItem, p.CategoriaDoItem
                FROM VendasItens vi
                INNER JOIN Produtos p ON vi.IdProduto = p.CodigoProduto
                WHERE vi.IdVenda = @IdVenda;
            ";

            using var cmd = new SqliteCommand(sql, connection);
            cmd.Parameters.AddWithValue("@IdVenda", idVenda);

            using var reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                lista.Add(new VendaItem
                {
                    IdVendaItem = Convert.ToInt32(reader["IdVendaItem"]),
                    IdVenda = Convert.ToInt32(reader["IdVenda"]),
                    IdProduto = reader["IdProduto"].ToString(),
                    IdFornecedor = reader["IdFornecedor"].ToString(),
                    PrecoOriginal = Convert.ToDouble(reader["PrecoOriginal"], CultureInfo.InvariantCulture),
                    PrecoFinalNegociado = Convert.ToDouble(reader["PrecoFinalNegociado"], CultureInfo.InvariantCulture),
                    NomeProduto = reader["NomeDoItem"].ToString(),
                    MarcaProduto = reader["MarcaDoItem"].ToString(),
                    CategoriaProduto = reader["CategoriaDoItem"].ToString()
                });
            }

            return lista;
        }

        // ============================================================
        //  LISTAR PAGAMENTOS DE UMA VENDA
        // ============================================================
        public List<Pagamento> ListarPagamentosPorVenda(int idVenda)
        {
            var lista = new List<Pagamento>();

            using var connection = new SqliteConnection(_connectionString);
            connection.Open();

            string sql = @"
                SELECT TipoPagamento, Valor
                FROM VendasPagamentos
                WHERE IdVenda = @IdVenda;
            ";

            using var cmd = new SqliteCommand(sql, connection);
            cmd.Parameters.AddWithValue("@IdVenda", idVenda);

            using var reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                lista.Add(new Pagamento
                {
                    Tipo = Enum.Parse<TipoPagamento>(reader["TipoPagamento"].ToString()),
                    Valor = Convert.ToDouble(reader["Valor"], CultureInfo.InvariantCulture)
                });
            }

            return lista;
        }
    }
}
