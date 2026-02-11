using Microsoft.Data.Sqlite;
using BrechoApp.Models;
using System.Collections.Generic;

namespace BrechoApp.Data
{
    public class ComissaoRepository
    {
        private readonly string _connectionString = DatabaseConfig.ConnectionString;

        private SqliteConnection GetConnection()
        {
            return new SqliteConnection(_connectionString);
        }

        // ✅ ADICIONAR
        public void AdicionarComissao(Comissao comissao)
        {
            using (var conn = GetConnection())
            {
                conn.Open();

                string sql = @"
                    INSERT INTO Comissoes
                    (CodigoComissao, CodigoVenda, CodigoFornecedor, ValorComissao, DataComissao, ComissaoPaga)
                    VALUES
                    (@CodigoComissao, @CodigoVenda, @CodigoFornecedor, @ValorComissao, @DataComissao, @ComissaoPaga)
                ";

                using (var cmd = new SqliteCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@CodigoComissao", comissao.CodigoComissao);
                    cmd.Parameters.AddWithValue("@CodigoVenda", comissao.CodigoVenda);
                    cmd.Parameters.AddWithValue("@CodigoFornecedor", comissao.CodigoFornecedor);
                    cmd.Parameters.AddWithValue("@ValorComissao", comissao.ValorComissao);
                    cmd.Parameters.AddWithValue("@DataComissao", comissao.DataComissao);
                    cmd.Parameters.AddWithValue("@ComissaoPaga", comissao.ComissaoPaga ? 1 : 0);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        // ✅ LISTAR
        public List<Comissao> ListarComissoes()
        {
            var lista = new List<Comissao>();

            using (var conn = GetConnection())
            {
                conn.Open();

                string sql = "SELECT * FROM Comissoes";

                using (var cmd = new SqliteCommand(sql, conn))
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        lista.Add(new Comissao
                        {
                            CodigoComissao = reader["CodigoComissao"].ToString(),
                            CodigoVenda = reader["CodigoVenda"].ToString(),
                            CodigoFornecedor = reader["CodigoFornecedor"].ToString(),
                            ValorComissao = double.Parse(reader["ValorComissao"].ToString()),
                            DataComissao = reader["DataComissao"].ToString(),
                            ComissaoPaga = reader["ComissaoPaga"].ToString() == "1"
                        });
                    }
                }
            }

            return lista;
        }

        // ✅ ATUALIZAR
        public void AtualizarComissao(Comissao comissao)
        {
            using (var conn = GetConnection())
            {
                conn.Open();

                string sql = @"
                    UPDATE Comissoes SET
                        CodigoVenda = @CodigoVenda,
                        CodigoFornecedor = @CodigoFornecedor,
                        ValorComissao = @ValorComissao,
                        DataComissao = @DataComissao,
                        ComissaoPaga = @ComissaoPaga
                    WHERE CodigoComissao = @CodigoComissao
                ";

                using (var cmd = new SqliteCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@CodigoComissao", comissao.CodigoComissao);
                    cmd.Parameters.AddWithValue("@CodigoVenda", comissao.CodigoVenda);
                    cmd.Parameters.AddWithValue("@CodigoFornecedor", comissao.CodigoFornecedor);
                    cmd.Parameters.AddWithValue("@ValorComissao", comissao.ValorComissao);
                    cmd.Parameters.AddWithValue("@DataComissao", comissao.DataComissao);
                    cmd.Parameters.AddWithValue("@ComissaoPaga", comissao.ComissaoPaga ? 1 : 0);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        // ✅ EXCLUIR
        public void ExcluirComissao(string codigoComissao)
        {
            using (var conn = GetConnection())
            {
                conn.Open();

                string sql = "DELETE FROM Comissoes WHERE CodigoComissao = @CodigoComissao";

                using (var cmd = new SqliteCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@CodigoComissao", codigoComissao);
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
