using Microsoft.Data.Sqlite;
using BrechoApp.Models;
using System;
using System.Collections.Generic;

namespace BrechoApp.Data
{
    public class ComissaoMovimentoRepository
    {
        private readonly string _connectionString;

        public ComissaoMovimentoRepository()
        {
            _connectionString = DatabaseConfig.ConnectionString;
        }

        // Registrar pagamento ou recebimento
        public int InserirMovimento(ComissaoMovimento mov)
        {
            using (var conn = new SqliteConnection(_connectionString))
            {
                conn.Open();

                string sql = @"
                    INSERT INTO ComissaoMovimento
                    (IdSaldo, Tipo, Valor, FormaPagamento, Observacao)
                    VALUES
                    (@IdSaldo, @Tipo, @Valor, @FormaPagamento, @Observacao);
                    SELECT last_insert_rowid();
                ";

                using (var cmd = new SqliteCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@IdSaldo", mov.IdSaldo);
                    cmd.Parameters.AddWithValue("@Tipo", mov.Tipo);
                    cmd.Parameters.AddWithValue("@Valor", mov.Valor);
                    cmd.Parameters.AddWithValue("@FormaPagamento", mov.FormaPagamento);
                    cmd.Parameters.AddWithValue("@Observacao", mov.Observacao);

                    return Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
        }

        // Listar movimentos de um saldo
        public List<ComissaoMovimento> ListarPorSaldo(int idSaldo)
        {
            var lista = new List<ComissaoMovimento>();

            using (var conn = new SqliteConnection(_connectionString))
            {
                conn.Open();

                string sql = @"
                    SELECT IdMovimento, IdSaldo, Tipo, Valor, FormaPagamento,
                           DataMovimento, Observacao
                    FROM ComissaoMovimento
                    WHERE IdSaldo = @IdSaldo
                ";

                using (var cmd = new SqliteCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@IdSaldo", idSaldo);

                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            lista.Add(new ComissaoMovimento
                            {
                                IdMovimento = reader.GetInt32(0),
                                IdSaldo = reader.GetInt32(1),
                                Tipo = reader.GetString(2),
                                Valor = reader.GetDouble(3),
                                FormaPagamento = reader.GetString(4),
                                DataMovimento = reader.GetString(5),
                                Observacao = reader.IsDBNull(6) ? "" : reader.GetString(6)
                            });
                        }
                    }
                }
            }

            return lista;
        }
    }
}