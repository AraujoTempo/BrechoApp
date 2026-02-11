using Microsoft.Data.Sqlite;
using BrechoApp.Models;
using System.Collections.Generic;

namespace BrechoApp.Data
{
    public class LoteDevolucaoRepository
    {
        private readonly string _connectionString = DatabaseConfig.ConnectionString;


        private SqliteConnection GetConnection()
        {
            return new SqliteConnection(_connectionString);
        }

        // ✅ Adicionar lote
        public void AdicionarLoteDevolucao(LoteDevolucao lote)
        {
            using (var conn = GetConnection())
            {
                conn.Open();

                string sql = @"
                    INSERT INTO LotesDevolucao
                    (CodigoLoteDevolucao, CodigoFornecedor, DataDevolucao, StatusDevolucao)
                    VALUES
                    (@CodigoLoteDevolucao, @CodigoFornecedor, @DataDevolucao, @StatusDevolucao)
                ";

                using (var cmd = new SqliteCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@CodigoLoteDevolucao", lote.CodigoLoteDevolucao);
                    cmd.Parameters.AddWithValue("@CodigoFornecedor", lote.CodigoFornecedor);
                    cmd.Parameters.AddWithValue("@DataDevolucao", lote.DataDevolucao);
                    cmd.Parameters.AddWithValue("@StatusDevolucao", lote.StatusDevolucao);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        // ✅ Listar lotes
        public List<LoteDevolucao> ListarLotesDevolucao()
        {
            var lista = new List<LoteDevolucao>();

            using (var conn = GetConnection())
            {
                conn.Open();

                string sql = "SELECT * FROM LotesDevolucao";

                using (var cmd = new SqliteCommand(sql, conn))
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        lista.Add(new LoteDevolucao
                        {
                            CodigoLoteDevolucao = reader["CodigoLoteDevolucao"].ToString(),
                            CodigoFornecedor = reader["CodigoFornecedor"].ToString(),
                            DataDevolucao = reader["DataDevolucao"].ToString(),
                            StatusDevolucao = reader["StatusDevolucao"].ToString()
                        });
                    }
                }
            }

            return lista;
        }

        // ✅ Atualizar lote
        public void AtualizarLoteDevolucao(LoteDevolucao lote)
        {
            using (var conn = GetConnection())
            {
                conn.Open();

                string sql = @"
                    UPDATE LotesDevolucao SET
                        CodigoFornecedor = @CodigoFornecedor,
                        DataDevolucao = @DataDevolucao,
                        StatusDevolucao = @StatusDevolucao
                    WHERE CodigoLoteDevolucao = @CodigoLoteDevolucao
                ";

                using (var cmd = new SqliteCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@CodigoLoteDevolucao", lote.CodigoLoteDevolucao);
                    cmd.Parameters.AddWithValue("@CodigoFornecedor", lote.CodigoFornecedor);
                    cmd.Parameters.AddWithValue("@DataDevolucao", lote.DataDevolucao);
                    cmd.Parameters.AddWithValue("@StatusDevolucao", lote.StatusDevolucao);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        // ✅ Excluir lote
        public void ExcluirLoteDevolucao(string codigoLoteDevolucao)
        {
            using (var conn = GetConnection())
            {
                conn.Open();

                string sql = "DELETE FROM LotesDevolucao WHERE CodigoLoteDevolucao = @CodigoLoteDevolucao";

                using (var cmd = new SqliteCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@CodigoLoteDevolucao", codigoLoteDevolucao);
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
