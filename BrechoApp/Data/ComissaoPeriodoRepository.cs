using Microsoft.Data.Sqlite;
using BrechoApp.Models;
using Microsoft.Data.Sqlite;
using BrechoApp.Models;
using System;
using System.Collections.Generic;

namespace BrechoApp.Data
{
    public class ComissaoPeriodoRepository
    {
        private readonly string _connectionString;

        public ComissaoPeriodoRepository()
        {
            _connectionString = DatabaseConfig.ConnectionString;
        }

        // Criar novo período
        public int CriarPeriodo(int mes, int ano)
        {
            using (var conn = new SqliteConnection(_connectionString))
            {
                conn.Open();

                string sql = @"
                    INSERT INTO ComissaoPeriodo (Mes, Ano, Status)
                    VALUES (@Mes, @Ano, 'Aberto');
                    SELECT last_insert_rowid();
                ";

                using (var cmd = new SqliteCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@Mes", mes);
                    cmd.Parameters.AddWithValue("@Ano", ano);

                    return Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
        }

        // Buscar período existente
        public ComissaoPeriodo BuscarPeriodo(int mes, int ano)
        {
            using (var conn = new SqliteConnection(_connectionString))
            {
                conn.Open();

                string sql = @"
                    SELECT IdPeriodo, Mes, Ano, DataAbertura, DataFechamento, Status
                    FROM ComissaoPeriodo
                    WHERE Mes = @Mes AND Ano = @Ano
                ";

                using (var cmd = new SqliteCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@Mes", mes);
                    cmd.Parameters.AddWithValue("@Ano", ano);

                    using (var reader = cmd.ExecuteReader())
                    {
                        if (!reader.Read())
                            return null;

                        return new ComissaoPeriodo
                        {
                            IdPeriodo = reader.GetInt32(0),
                            Mes = reader.GetInt32(1),
                            Ano = reader.GetInt32(2),
                            DataAbertura = reader.GetString(3),
                            DataFechamento = reader.IsDBNull(4) ? null : reader.GetString(4),
                            Status = reader.GetString(5)
                        };
                    }
                }
            }
        }

        // Fechar período
        public void FecharPeriodo(int idPeriodo)
        {
            using (var conn = new SqliteConnection(_connectionString))
            {
                conn.Open();

                string sql = @"
                    UPDATE ComissaoPeriodo
                    SET Status = 'Fechado',
                        DataFechamento = datetime('now')
                    WHERE IdPeriodo = @IdPeriodo
                ";

                using (var cmd = new SqliteCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@IdPeriodo", idPeriodo);
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
