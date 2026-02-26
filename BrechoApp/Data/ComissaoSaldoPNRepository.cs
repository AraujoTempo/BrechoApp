using Microsoft.Data.Sqlite;
using BrechoApp.Models;
using System;
using System.Collections.Generic;

namespace BrechoApp.Data
{
    public class ComissaoSaldoPNRepository
    {
        private readonly string _connectionString;

        public ComissaoSaldoPNRepository()
        {
            _connectionString = DatabaseConfig.ConnectionString;
        }

        // Inserir saldo consolidado
        public int InserirSaldo(ComissaoSaldoPN saldo)
        {
            using (var conn = new SqliteConnection(_connectionString))
            {
                conn.Open();

                string sql = @"
                    INSERT INTO ComissaoSaldoPN
                    (IdPeriodo, CodigoPN, ComissoesAPagar, ContasAReceber, SaldoFinal, SaldoCompensado, Status)
                    VALUES
                    (@IdPeriodo, @CodigoPN, @ComissoesAPagar, @ContasAReceber, @SaldoFinal, @SaldoCompensado, @Status);
                    SELECT last_insert_rowid();
                ";

                using (var cmd = new SqliteCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@IdPeriodo", saldo.IdPeriodo);
                    cmd.Parameters.AddWithValue("@CodigoPN", saldo.CodigoPN);
                    cmd.Parameters.AddWithValue("@ComissoesAPagar", saldo.ComissoesAPagar);
                    cmd.Parameters.AddWithValue("@ContasAReceber", saldo.ContasAReceber);
                    cmd.Parameters.AddWithValue("@SaldoFinal", saldo.SaldoFinal);
                    cmd.Parameters.AddWithValue("@SaldoCompensado", saldo.SaldoCompensado);
                    cmd.Parameters.AddWithValue("@Status", saldo.Status);

                    return Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
        }

        // Buscar saldos por período
        public List<ComissaoSaldoPN> ListarPorPeriodo(int idPeriodo)
        {
            var lista = new List<ComissaoSaldoPN>();

            using (var conn = new SqliteConnection(_connectionString))
            {
                conn.Open();

                string sql = @"
                    SELECT IdSaldo, IdPeriodo, CodigoPN, ComissoesAPagar, ContasAReceber,
                           SaldoFinal, SaldoCompensado, Status
                    FROM ComissaoSaldoPN
                    WHERE IdPeriodo = @IdPeriodo
                ";

                using (var cmd = new SqliteCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@IdPeriodo", idPeriodo);

                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            lista.Add(new ComissaoSaldoPN
                            {
                                IdSaldo = reader.GetInt32(0),
                                IdPeriodo = reader.GetInt32(1),
                                CodigoPN = reader.GetString(2),
                                ComissoesAPagar = reader.GetDouble(3),
                                ContasAReceber = reader.GetDouble(4),
                                SaldoFinal = reader.GetDouble(5),
                                SaldoCompensado = reader.GetDouble(6),
                                Status = reader.GetString(7)
                            });
                        }
                    }
                }
            }

            return lista;
        }

        // Atualizar saldo (após liquidação)
        public void AtualizarSaldo(ComissaoSaldoPN saldo)
        {
            using (var conn = new SqliteConnection(_connectionString))
            {
                conn.Open();

                string sql = @"
                    UPDATE ComissaoSaldoPN
                    SET ComissoesAPagar = @ComissoesAPagar,
                        ContasAReceber = @ContasAReceber,
                        SaldoFinal = @SaldoFinal,
                        SaldoCompensado = @SaldoCompensado,
                        Status = @Status
                    WHERE IdSaldo = @IdSaldo
                ";

                using (var cmd = new SqliteCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@ComissoesAPagar", saldo.ComissoesAPagar);
                    cmd.Parameters.AddWithValue("@ContasAReceber", saldo.ContasAReceber);
                    cmd.Parameters.AddWithValue("@SaldoFinal", saldo.SaldoFinal);
                    cmd.Parameters.AddWithValue("@SaldoCompensado", saldo.SaldoCompensado);
                    cmd.Parameters.AddWithValue("@Status", saldo.Status);
                    cmd.Parameters.AddWithValue("@IdSaldo", saldo.IdSaldo);

                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}