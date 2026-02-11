using Microsoft.Data.Sqlite;
using BrechoApp.Models;
using System.Collections.Generic;

namespace BrechoApp.Data
{
    public class ClienteRepository
    {
        private readonly string _connectionString = DatabaseConfig.ConnectionString;


        private SqliteConnection GetConnection()
        {
            return new SqliteConnection(_connectionString);
        }

        // ✅ GERA O PRÓXIMO CÓDIGO SEQUENCIAL (C-1, C-2, C-3...)
        private string GerarProximoCodigoCliente()
        {
            using var conn = GetConnection();
            conn.Open();

            string sql = @"
                SELECT CodigoCliente
                FROM Clientes
                WHERE CodigoCliente LIKE 'C-%'
                ORDER BY CAST(SUBSTR(CodigoCliente, 3) AS INTEGER) DESC
                LIMIT 1
            ";

            using var cmd = new SqliteCommand(sql, conn);
            var result = cmd.ExecuteScalar()?.ToString();

            if (string.IsNullOrEmpty(result))
                return "C-1";

            if (int.TryParse(result.Replace("C-", ""), out int numero))
                return $"C-{numero + 1}";

            return "C-1";
        }

        // ✅ ADICIONAR CLIENTE
        public void AdicionarCliente(Cliente cliente)
        {
            if (string.IsNullOrWhiteSpace(cliente.CodigoCliente))
                cliente.CodigoCliente = GerarProximoCodigoCliente();

            using var conn = GetConnection();
            conn.Open();

            string sql = @"
                INSERT INTO Clientes
                (CodigoCliente, Nome, CPF, Telefone, Endereco, Email, Observacao, Aniversario)
                VALUES
                (@CodigoCliente, @Nome, @CPF, @Telefone, @Endereco, @Email, @Observacao, @Aniversario)
            ";

            using var cmd = new SqliteCommand(sql, conn);

            cmd.Parameters.AddWithValue("@CodigoCliente", cliente.CodigoCliente);
            cmd.Parameters.AddWithValue("@Nome", cliente.Nome);
            cmd.Parameters.AddWithValue("@CPF", cliente.CPF);
            cmd.Parameters.AddWithValue("@Telefone", cliente.Telefone);
            cmd.Parameters.AddWithValue("@Endereco", cliente.Endereco);
            cmd.Parameters.AddWithValue("@Email", cliente.Email);
            cmd.Parameters.AddWithValue("@Observacao", cliente.Observacao);
            cmd.Parameters.AddWithValue("@Aniversario", cliente.Aniversario);

            cmd.ExecuteNonQuery();
        }

        // ✅ LISTAR CLIENTES
        public List<Cliente> ListarClientes()
        {
            var lista = new List<Cliente>();

            using var conn = GetConnection();
            conn.Open();

            string sql = "SELECT * FROM Clientes ORDER BY Nome";

            using var cmd = new SqliteCommand(sql, conn);
            using var reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                lista.Add(new Cliente
                {
                    CodigoCliente = reader["CodigoCliente"].ToString(),
                    Nome = reader["Nome"].ToString(),
                    CPF = reader["CPF"].ToString(),
                    Telefone = reader["Telefone"].ToString(),
                    Endereco = reader["Endereco"].ToString(),
                    Email = reader["Email"].ToString(),
                    Observacao = reader["Observacao"].ToString(),
                    Aniversario = reader["Aniversario"].ToString()
                });
            }

            return lista;
        }

        // ✅ ATUALIZAR CLIENTE
        public void AtualizarCliente(Cliente cliente)
        {
            using var conn = GetConnection();
            conn.Open();

            string sql = @"
                UPDATE Clientes SET
                    Nome = @Nome,
                    CPF = @CPF,
                    Telefone = @Telefone,
                    Endereco = @Endereco,
                    Email = @Email,
                    Observacao = @Observacao,
                    Aniversario = @Aniversario
                WHERE CodigoCliente = @CodigoCliente
            ";

            using var cmd = new SqliteCommand(sql, conn);

            cmd.Parameters.AddWithValue("@CodigoCliente", cliente.CodigoCliente);
            cmd.Parameters.AddWithValue("@Nome", cliente.Nome);
            cmd.Parameters.AddWithValue("@CPF", cliente.CPF);
            cmd.Parameters.AddWithValue("@Telefone", cliente.Telefone);
            cmd.Parameters.AddWithValue("@Endereco", cliente.Endereco);
            cmd.Parameters.AddWithValue("@Email", cliente.Email);
            cmd.Parameters.AddWithValue("@Observacao", cliente.Observacao);
            cmd.Parameters.AddWithValue("@Aniversario", cliente.Aniversario);

            cmd.ExecuteNonQuery();
        }

        // ✅ EXCLUIR CLIENTE
        public void ExcluirCliente(string codigoCliente)
        {
            using var conn = GetConnection();
            conn.Open();

            string sql = "DELETE FROM Clientes WHERE CodigoCliente = @CodigoCliente";

            using var cmd = new SqliteCommand(sql, conn);
            cmd.Parameters.AddWithValue("@CodigoCliente", codigoCliente);

            cmd.ExecuteNonQuery();
        }
    }
}
