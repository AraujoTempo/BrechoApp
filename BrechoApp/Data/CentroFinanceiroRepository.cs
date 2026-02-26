using System;
using System.Collections.Generic;
using Microsoft.Data.Sqlite;
using BrechoApp.Models;

namespace BrechoApp.Data
{
    public class CentroFinanceiroRepository
    {
        private readonly string _connectionString = DatabaseConfig.ConnectionString;

        // ============================================================
        // LISTAR TODOS
        // ============================================================
        public List<CentroFinanceiro> Listar()
        {
            var lista = new List<CentroFinanceiro>();

            using (var conn = new SqliteConnection(_connectionString))
            {
                conn.Open();

                var cmd = conn.CreateCommand();
                cmd.CommandText = @"SELECT IdCentroFinanceiro, Nome, Tipo, SaldoAtual, Ativo 
                                    FROM CentrosFinanceiros
                                    ORDER BY Nome";

                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        lista.Add(new CentroFinanceiro
                        {
                            IdCentroFinanceiro = reader.GetInt32(0),
                            Nome = reader.GetString(1),
                            Tipo = reader.GetString(2),
                            SaldoAtual = reader.GetDecimal(3),
                            Ativo = reader.GetBoolean(4)
                        });
                    }
                }
            }

            return lista;
        }

        // ============================================================
        // BUSCAR POR ID
        // ============================================================
        public CentroFinanceiro BuscarPorId(int id)
        {
            using (var conn = new SqliteConnection(_connectionString))
            {
                conn.Open();

                var cmd = conn.CreateCommand();
                cmd.CommandText = @"SELECT IdCentroFinanceiro, Nome, Tipo, SaldoAtual, Ativo
                                    FROM CentrosFinanceiros
                                    WHERE IdCentroFinanceiro = $id";

                cmd.Parameters.AddWithValue("$id", id);

                using (var reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return new CentroFinanceiro
                        {
                            IdCentroFinanceiro = reader.GetInt32(0),
                            Nome = reader.GetString(1),
                            Tipo = reader.GetString(2),
                            SaldoAtual = reader.GetDecimal(3),
                            Ativo = reader.GetBoolean(4)
                        };
                    }
                }
            }

            return null;
        }

        // ============================================================
        // INSERIR
        // ============================================================
        public void Inserir(CentroFinanceiro c)
        {
            using (var conn = new SqliteConnection(_connectionString))
            {
                conn.Open();

                var cmd = conn.CreateCommand();
                cmd.CommandText =
                @"INSERT INTO CentrosFinanceiros (Nome, Tipo, SaldoAtual, Ativo)
                  VALUES ($nome, $tipo, $saldo, $ativo)";

                cmd.Parameters.AddWithValue("$nome", c.Nome);
                cmd.Parameters.AddWithValue("$tipo", c.Tipo);
                cmd.Parameters.AddWithValue("$saldo", c.SaldoAtual);
                cmd.Parameters.AddWithValue("$ativo", c.Ativo);

                cmd.ExecuteNonQuery();
            }
        }

        // ============================================================
        // ATUALIZAR
        // ============================================================
        public void Atualizar(CentroFinanceiro c)
        {
            using (var conn = new SqliteConnection(_connectionString))
            {
                conn.Open();

                var cmd = conn.CreateCommand();
                cmd.CommandText =
                @"UPDATE CentrosFinanceiros
                  SET Nome = $nome,
                      Tipo = $tipo,
                      SaldoAtual = $saldo,
                      Ativo = $ativo
                  WHERE IdCentroFinanceiro = $id";

                cmd.Parameters.AddWithValue("$nome", c.Nome);
                cmd.Parameters.AddWithValue("$tipo", c.Tipo);
                cmd.Parameters.AddWithValue("$saldo", c.SaldoAtual);
                cmd.Parameters.AddWithValue("$ativo", c.Ativo);
                cmd.Parameters.AddWithValue("$id", c.IdCentroFinanceiro);

                cmd.ExecuteNonQuery();
            }
        }

        // ============================================================
        // EXCLUIR
        // ============================================================
        public void Excluir(int id)
        {
            using (var conn = new SqliteConnection(_connectionString))
            {
                conn.Open();

                var cmd = conn.CreateCommand();
                cmd.CommandText =
                @"DELETE FROM CentrosFinanceiros
                  WHERE IdCentroFinanceiro = $id";

                cmd.Parameters.AddWithValue("$id", id);

                cmd.ExecuteNonQuery();
            }
        }

        // ============================================================
        // SOMAR SALDO
        // ============================================================
        public void SomarSaldo(int idCentro, decimal valor)
        {
            using (var conn = new SqliteConnection(_connectionString))
            {
                conn.Open();

                var cmd = conn.CreateCommand();
                cmd.CommandText =
                @"UPDATE CentrosFinanceiros
                  SET SaldoAtual = SaldoAtual + $valor
                  WHERE IdCentroFinanceiro = $id";

                cmd.Parameters.AddWithValue("$valor", valor);
                cmd.Parameters.AddWithValue("$id", idCentro);

                cmd.ExecuteNonQuery();
            }
        }

        // ============================================================
        // SUBTRAIR SALDO
        // ============================================================
        public void SubtrairSaldo(int idCentro, decimal valor)
        {
            using (var conn = new SqliteConnection(_connectionString))
            {
                conn.Open();

                var cmd = conn.CreateCommand();
                cmd.CommandText =
                @"UPDATE CentrosFinanceiros
                  SET SaldoAtual = SaldoAtual - $valor
                  WHERE IdCentroFinanceiro = $id";

                cmd.Parameters.AddWithValue("$valor", valor);
                cmd.Parameters.AddWithValue("$id", idCentro);

                cmd.ExecuteNonQuery();
            }
        }
    }
}