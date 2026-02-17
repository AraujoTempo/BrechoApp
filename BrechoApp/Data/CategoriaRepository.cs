using BrechoApp.Models;
using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;

namespace BrechoApp.Data
{
    public class CategoriaRepository
    {
        private readonly string _connectionString = DatabaseConfig.ConnectionString;

        // Listar todas as categorias
        public List<Categoria> ListarTodas()
        {
            var categorias = new List<Categoria>();
            using var connection = new SqliteConnection(_connectionString);
            connection.Open();

            var command = connection.CreateCommand();
            command.CommandText = "SELECT Id, NomeCategoria, DataCriacao FROM Categorias ORDER BY NomeCategoria";

            using var reader = command.ExecuteReader();
            while (reader.Read())
            {
                categorias.Add(new Categoria
                {
                    Id = reader.GetInt32(0),
                    NomeCategoria = reader.GetString(1),
                    DataCriacao = DateTime.Parse(reader.GetString(2))
                });
            }
            return categorias;
        }

        // Adicionar categoria
        public void Adicionar(Categoria categoria)
        {
            using var connection = new SqliteConnection(_connectionString);
            connection.Open();

            var command = connection.CreateCommand();
            command.CommandText = @"
                INSERT INTO Categorias (NomeCategoria, DataCriacao)
                VALUES ($nome, $criacao)";

            command.Parameters.AddWithValue("$nome", categoria.NomeCategoria);
            command.Parameters.AddWithValue("$criacao", categoria.DataCriacao.ToString("yyyy-MM-dd HH:mm:ss"));
            command.ExecuteNonQuery();
        }

        // Atualizar categoria
        public void Atualizar(Categoria categoria)
        {
            using var connection = new SqliteConnection(_connectionString);
            connection.Open();

            var command = connection.CreateCommand();
            command.CommandText = @"
                UPDATE Categorias
                SET NomeCategoria = $nome
                WHERE Id = $id";

            command.Parameters.AddWithValue("$nome", categoria.NomeCategoria);
            command.Parameters.AddWithValue("$id", categoria.Id);
            command.ExecuteNonQuery();
        }

        // Excluir categoria
        public void Excluir(int id)
        {
            using var connection = new SqliteConnection(_connectionString);
            connection.Open();

            var command = connection.CreateCommand();
            command.CommandText = "DELETE FROM Categorias WHERE Id = $id";
            command.Parameters.AddWithValue("$id", id);
            command.ExecuteNonQuery();
        }

        // Verificar se categoria existe
        public bool Existe(string nomeCategoria, int? idExcluir = null)
        {
            using var connection = new SqliteConnection(_connectionString);
            connection.Open();

            var command = connection.CreateCommand();
            if (idExcluir.HasValue)
            {
                command.CommandText = "SELECT COUNT(*) FROM Categorias WHERE NomeCategoria = $nome AND Id != $id";
                command.Parameters.AddWithValue("$id", idExcluir.Value);
            }
            else
            {
                command.CommandText = "SELECT COUNT(*) FROM Categorias WHERE NomeCategoria = $nome";
            }
            command.Parameters.AddWithValue("$nome", nomeCategoria);

            return Convert.ToInt32(command.ExecuteScalar()) > 0;
        }
    }
}
