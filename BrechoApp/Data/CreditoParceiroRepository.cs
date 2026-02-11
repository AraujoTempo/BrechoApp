using Microsoft.Data.Sqlite;
using BrechoApp.Models;
using System.Collections.Generic;

namespace BrechoApp.Data
{
    public class CreditoFornecedorRepository
    {
        private readonly string _connectionString = DatabaseConfig.ConnectionString;


        private SqliteConnection GetConnection()
        {
            return new SqliteConnection(_connectionString);
        }

        // Adiciona um crédito
        public void AdicionarCredito(CreditoFornecedor credito)
        {
            using (var conn = GetConnection())
            {
                conn.Open();

                string sql = @"
                    INSERT INTO CreditoFornecedor
                    (CodigoCredito, CodigoFornecedor, ValorCredito, DataCredito, OrigemCredito)
                    VALUES
                    (@CodigoCredito, @CodigoFornecedor, @ValorCredito, @DataCredito, @OrigemCredito)
                ";

                using (var cmd = new SqliteCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@CodigoCredito", credito.CodigoCredito);
                    cmd.Parameters.AddWithValue("@CodigoFornecedor", credito.CodigoFornecedor);
                    cmd.Parameters.AddWithValue("@ValorCredito", credito.ValorCredito);
                    cmd.Parameters.AddWithValue("@DataCredito", credito.DataCredito);
                    cmd.Parameters.AddWithValue("@OrigemCredito", credito.OrigemCredito);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        // Lista todos os créditos
        public List<CreditoFornecedor> ListarCreditos()
        {
            var lista = new List<CreditoFornecedor>();

            using (var conn = GetConnection())
            {
                conn.Open();

                string sql = "SELECT * FROM CreditoFornecedor";

                using (var cmd = new SqliteCommand(sql, conn))
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        lista.Add(new CreditoFornecedor
                        {
                            CodigoCredito = reader["CodigoCredito"].ToString(),
                            CodigoFornecedor = reader["CodigoFornecedor"].ToString(),
                            ValorCredito = double.Parse(reader["ValorCredito"].ToString()),
                            DataCredito = reader["DataCredito"].ToString(),
                            OrigemCredito = reader["OrigemCredito"].ToString()
                        });
                    }
                }
            }

            return lista;
        }

        // Lista créditos de um fornecedor específico
        public List<CreditoFornecedor> ListarCreditosPorFornecedor(string codigoFornecedor)
        {
            var lista = new List<CreditoFornecedor>();

            using (var conn = GetConnection())
            {
                conn.Open();

                string sql = @"
                    SELECT * FROM CreditoFornecedor
                    WHERE CodigoFornecedor = @CodigoFornecedor
                ";

                using (var cmd = new SqliteCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@CodigoFornecedor", codigoFornecedor);

                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            lista.Add(new CreditoFornecedor
                            {
                                CodigoCredito = reader["CodigoCredito"].ToString(),
                                CodigoFornecedor = reader["CodigoFornecedor"].ToString(),
                                ValorCredito = double.Parse(reader["ValorCredito"].ToString()),
                                DataCredito = reader["DataCredito"].ToString(),
                                OrigemCredito = reader["OrigemCredito"].ToString()
                            });
                        }
                    }
                }
            }

            return lista;
        }

        // Exclui um crédito
        public void ExcluirCredito(string codigoCredito)
        {
            using (var conn = GetConnection())
            {
                conn.Open();

                string sql = "DELETE FROM CreditoFornecedor WHERE CodigoCredito = @CodigoCredito";

                using (var cmd = new SqliteCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@CodigoCredito", codigoCredito);
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
