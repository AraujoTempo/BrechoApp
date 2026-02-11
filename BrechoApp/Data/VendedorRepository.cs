using System;
using System.Collections.Generic;
using Microsoft.Data.Sqlite;
using BrechoApp.Models;

namespace BrechoApp.Data
{
    public class VendedorRepository
    {
        /// <summary>
        /// Gera automaticamente o próximo código no formato V-0001.
        /// </summary>
        public string GerarCodigo()
        {
            using var conn = Conexao.GetConnection();
            conn.Open();

            string sql = "SELECT CodigoVendedor FROM Vendedores ORDER BY CodigoVendedor DESC LIMIT 1";
            using var cmd = new SqliteCommand(sql, conn);

            var result = cmd.ExecuteScalar();

            if (result == null)
                return "V-0001";

            string ultimo = result.ToString()!;
            int numero = int.Parse(ultimo.Substring(2));
            numero++;

            return $"V-{numero:0000}";
        }

        /// <summary>
        /// Insere um novo vendedor no banco.
        /// </summary>
        public void Inserir(Vendedor v)
        {
            using var conn = Conexao.GetConnection();
            conn.Open();

            string sql = @"
                INSERT INTO Vendedores
                (CodigoVendedor, Nome, CPF, Telefone, Email, Endereco,
                 Banco, Agencia, Conta, ComissaoVendedor, Observacao, Ativo)
                VALUES
                (@Codigo, @Nome, @CPF, @Telefone, @Email, @Endereco,
                 @Banco, @Agencia, @Conta, @Comissao, @Observacao, @Ativo)
            ";

            using var cmd = new SqliteCommand(sql, conn);

            cmd.Parameters.AddWithValue("@Codigo", v.CodigoVendedor);
            cmd.Parameters.AddWithValue("@Nome", v.Nome);
            cmd.Parameters.AddWithValue("@CPF", v.CPF);
            cmd.Parameters.AddWithValue("@Telefone", v.Telefone);
            cmd.Parameters.AddWithValue("@Email", v.Email);
            cmd.Parameters.AddWithValue("@Endereco", v.Endereco);

            cmd.Parameters.AddWithValue("@Banco", v.Banco);
            cmd.Parameters.AddWithValue("@Agencia", v.Agencia);
            cmd.Parameters.AddWithValue("@Conta", v.Conta);

            cmd.Parameters.AddWithValue("@Comissao", v.ComissaoVendedor);
            cmd.Parameters.AddWithValue("@Observacao", v.Observacao);

            cmd.Parameters.AddWithValue("@Ativo", v.Ativo ? 1 : 0);

            cmd.ExecuteNonQuery();
        }

        /// <summary>
        /// Atualiza os dados de um vendedor existente.
        /// </summary>
        public void Atualizar(Vendedor v)
        {
            using var conn = Conexao.GetConnection();
            conn.Open();

            string sql = @"
                UPDATE Vendedores SET
                    Nome=@Nome,
                    CPF=@CPF,
                    Telefone=@Telefone,
                    Email=@Email,
                    Endereco=@Endereco,
                    Banco=@Banco,
                    Agencia=@Agencia,
                    Conta=@Conta,
                    ComissaoVendedor=@Comissao,
                    Observacao=@Observacao,
                    Ativo=@Ativo
                WHERE CodigoVendedor=@Codigo
            ";

            using var cmd = new SqliteCommand(sql, conn);

            cmd.Parameters.AddWithValue("@Codigo", v.CodigoVendedor);
            cmd.Parameters.AddWithValue("@Nome", v.Nome);
            cmd.Parameters.AddWithValue("@CPF", v.CPF);
            cmd.Parameters.AddWithValue("@Telefone", v.Telefone);
            cmd.Parameters.AddWithValue("@Email", v.Email);
            cmd.Parameters.AddWithValue("@Endereco", v.Endereco);

            cmd.Parameters.AddWithValue("@Banco", v.Banco);
            cmd.Parameters.AddWithValue("@Agencia", v.Agencia);
            cmd.Parameters.AddWithValue("@Conta", v.Conta);

            cmd.Parameters.AddWithValue("@Comissao", v.ComissaoVendedor);
            cmd.Parameters.AddWithValue("@Observacao", v.Observacao);

            cmd.Parameters.AddWithValue("@Ativo", v.Ativo ? 1 : 0);

            cmd.ExecuteNonQuery();
        }

        /// <summary>
        /// Retorna todos os vendedores cadastrados.
        /// </summary>
        public List<Vendedor> ListarTodos()
        {
            var lista = new List<Vendedor>();

            using var conn = Conexao.GetConnection();
            conn.Open();

            string sql = "SELECT * FROM Vendedores ORDER BY Nome";

            using var cmd = new SqliteCommand(sql, conn);
            using var reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                lista.Add(new Vendedor
                {
                    CodigoVendedor = reader["CodigoVendedor"].ToString()!,
                    Nome = reader["Nome"].ToString()!,
                    CPF = reader["CPF"].ToString()!,
                    Telefone = reader["Telefone"].ToString()!,
                    Email = reader["Email"].ToString()!,
                    Endereco = reader["Endereco"].ToString()!,

                    Banco = reader["Banco"].ToString()!,
                    Agencia = reader["Agencia"].ToString()!,
                    Conta = reader["Conta"].ToString()!,

                    ComissaoVendedor = Convert.ToDecimal(reader["ComissaoVendedor"]),
                    Observacao = reader["Observacao"].ToString()!,

                    Ativo = Convert.ToInt32(reader["Ativo"]) == 1
                });
            }

            return lista;
        }
    }
}
