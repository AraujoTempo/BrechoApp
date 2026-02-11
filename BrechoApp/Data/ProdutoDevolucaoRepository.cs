using Microsoft.Data.Sqlite;
using BrechoApp.Models;
using System.Collections.Generic;

namespace BrechoApp.Data
{
    public class ProdutoDevolucaoRepository
    {
        private readonly string _connectionString = DatabaseConfig.ConnectionString;


        private SqliteConnection GetConnection()
        {
            return new SqliteConnection(_connectionString);
        }

        public void AdicionarProdutoDevolucao(ProdutoDevolucao prod)
        {
            using (var conn = GetConnection())
            {
                conn.Open();

                string sql = @"
                    INSERT INTO ProdutosDevolucao
                    (CodigoProdutoDevolucao, CodigoLoteDevolucao, CodigoProduto, MotivoDevolucao, DataDevolucao)
                    VALUES
                    (@CodigoProdutoDevolucao, @CodigoLoteDevolucao, @CodigoProduto, @MotivoDevolucao, @DataDevolucao)
                ";

                using (var cmd = new SqliteCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@CodigoProdutoDevolucao", prod.CodigoProdutoDevolucao);
                    cmd.Parameters.AddWithValue("@CodigoLoteDevolucao", prod.CodigoLoteDevolucao);
                    cmd.Parameters.AddWithValue("@CodigoProduto", prod.CodigoProduto);
                    cmd.Parameters.AddWithValue("@MotivoDevolucao", prod.MotivoDevolucao);
                    cmd.Parameters.AddWithValue("@DataDevolucao", prod.DataDevolucao);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public List<ProdutoDevolucao> ListarProdutosDevolucao()
        {
            var lista = new List<ProdutoDevolucao>();

            using (var conn = GetConnection())
            {
                conn.Open();

                string sql = "SELECT * FROM ProdutosDevolucao";

                using (var cmd = new SqliteCommand(sql, conn))
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        lista.Add(new ProdutoDevolucao
                        {
                            CodigoProdutoDevolucao = reader["CodigoProdutoDevolucao"].ToString(),
                            CodigoLoteDevolucao = reader["CodigoLoteDevolucao"].ToString(),
                            CodigoProduto = reader["CodigoProduto"].ToString(),
                            MotivoDevolucao = reader["MotivoDevolucao"].ToString(),
                            DataDevolucao = reader["DataDevolucao"].ToString()
                        });
                    }
                }
            }

            return lista;
        }

        public void AtualizarProdutoDevolucao(ProdutoDevolucao prod)
        {
            using (var conn = GetConnection())
            {
                conn.Open();

                string sql = @"
                    UPDATE ProdutosDevolucao SET
                        CodigoLoteDevolucao = @CodigoLoteDevolucao,
                        CodigoProduto = @CodigoProduto,
                        MotivoDevolucao = @MotivoDevolucao,
                        DataDevolucao = @DataDevolucao
                    WHERE CodigoProdutoDevolucao = @CodigoProdutoDevolucao
                ";

                using (var cmd = new SqliteCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@CodigoProdutoDevolucao", prod.CodigoProdutoDevolucao);
                    cmd.Parameters.AddWithValue("@CodigoLoteDevolucao", prod.CodigoLoteDevolucao);
                    cmd.Parameters.AddWithValue("@CodigoProduto", prod.CodigoProduto);
                    cmd.Parameters.AddWithValue("@MotivoDevolucao", prod.MotivoDevolucao);
                    cmd.Parameters.AddWithValue("@DataDevolucao", prod.DataDevolucao);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void ExcluirProdutoDevolucao(string codigoProdutoDevolucao)
        {
            using (var conn = GetConnection())
            {
                conn.Open();

                string sql = "DELETE FROM ProdutosDevolucao WHERE CodigoProdutoDevolucao = @CodigoProdutoDevolucao";

                using (var cmd = new SqliteCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@CodigoProdutoDevolucao", codigoProdutoDevolucao);
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
