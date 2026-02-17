using BrechoApp.Models;
using BrechoApp.Enums;
using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Globalization;

namespace BrechoApp.Data
{
    /// <summary>
    /// Repositório responsável por operações de banco de dados
    /// relacionadas às Comissões de Vendedores.
    /// </summary>
    public class ComissaoVendedorRepository
    {
        private readonly string _connectionString = DatabaseConfig.ConnectionString;
        private readonly ParceiroNegocioRepository _parceiroRepo = new ParceiroNegocioRepository();

        public ComissaoVendedorRepository()
        {
            // Garante que a base esteja criada/atualizada
            DatabaseInitializer.Initialize();
        }

        // ============================================================
        // LISTAR TODAS AS COMISSÕES
        // ============================================================
        public List<ComissaoVendedor> ListarTodas()
        {
            var lista = new List<ComissaoVendedor>();

            using var connection = new SqliteConnection(_connectionString);
            connection.Open();

            string sql = @"
                SELECT 
                    c.IdComissao,
                    c.CodigoPN,
                    p.Nome as NomeVendedor,
                    c.PercentualComissao,
                    c.DataCadastro,
                    c.DataUltimaAlteracao
                FROM ComissoesVendedores c
                INNER JOIN ParceirosNegocio p ON c.CodigoPN = p.CodigoParceiro
                ORDER BY p.Nome
            ";

            using var cmd = new SqliteCommand(sql, connection);
            using var reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                lista.Add(new ComissaoVendedor
                {
                    IdComissao = Convert.ToInt32(reader["IdComissao"]),
                    CodigoPN = reader["CodigoPN"].ToString()!,
                    NomeVendedor = reader["NomeVendedor"].ToString()!,
                    PercentualComissao = Convert.ToDecimal(reader["PercentualComissao"], CultureInfo.InvariantCulture),
                    DataCadastro = DateTime.Parse(reader["DataCadastro"].ToString()!),
                    DataUltimaAlteracao = reader["DataUltimaAlteracao"] == DBNull.Value 
                        ? null 
                        : DateTime.Parse(reader["DataUltimaAlteracao"].ToString()!)
                });
            }

            return lista;
        }

        // ============================================================
        // BUSCAR COMISSÃO POR ID
        // ============================================================
        public ComissaoVendedor? BuscarPorId(int idComissao)
        {
            using var connection = new SqliteConnection(_connectionString);
            connection.Open();

            string sql = @"
                SELECT 
                    c.IdComissao,
                    c.CodigoPN,
                    p.Nome as NomeVendedor,
                    c.PercentualComissao,
                    c.DataCadastro,
                    c.DataUltimaAlteracao
                FROM ComissoesVendedores c
                INNER JOIN ParceirosNegocio p ON c.CodigoPN = p.CodigoParceiro
                WHERE c.IdComissao = @IdComissao
                LIMIT 1
            ";

            using var cmd = new SqliteCommand(sql, connection);
            cmd.Parameters.AddWithValue("@IdComissao", idComissao);

            using var reader = cmd.ExecuteReader();

            if (!reader.Read())
                return null;

            return new ComissaoVendedor
            {
                IdComissao = Convert.ToInt32(reader["IdComissao"]),
                CodigoPN = reader["CodigoPN"].ToString()!,
                NomeVendedor = reader["NomeVendedor"].ToString()!,
                PercentualComissao = Convert.ToDecimal(reader["PercentualComissao"], CultureInfo.InvariantCulture),
                DataCadastro = DateTime.Parse(reader["DataCadastro"].ToString()!),
                DataUltimaAlteracao = reader["DataUltimaAlteracao"] == DBNull.Value 
                    ? null 
                    : DateTime.Parse(reader["DataUltimaAlteracao"].ToString()!)
            };
        }

        // ============================================================
        // BUSCAR COMISSÃO POR CÓDIGO DO PARCEIRO
        // ============================================================
        public ComissaoVendedor? BuscarPorCodigoPN(string codigoPN)
        {
            using var connection = new SqliteConnection(_connectionString);
            connection.Open();

            string sql = @"
                SELECT 
                    c.IdComissao,
                    c.CodigoPN,
                    p.Nome as NomeVendedor,
                    c.PercentualComissao,
                    c.DataCadastro,
                    c.DataUltimaAlteracao
                FROM ComissoesVendedores c
                INNER JOIN ParceirosNegocio p ON c.CodigoPN = p.CodigoParceiro
                WHERE c.CodigoPN = @CodigoPN
                LIMIT 1
            ";

            using var cmd = new SqliteCommand(sql, connection);
            cmd.Parameters.AddWithValue("@CodigoPN", codigoPN);

            using var reader = cmd.ExecuteReader();

            if (!reader.Read())
                return null;

            return new ComissaoVendedor
            {
                IdComissao = Convert.ToInt32(reader["IdComissao"]),
                CodigoPN = reader["CodigoPN"].ToString()!,
                NomeVendedor = reader["NomeVendedor"].ToString()!,
                PercentualComissao = Convert.ToDecimal(reader["PercentualComissao"], CultureInfo.InvariantCulture),
                DataCadastro = DateTime.Parse(reader["DataCadastro"].ToString()!),
                DataUltimaAlteracao = reader["DataUltimaAlteracao"] == DBNull.Value 
                    ? null 
                    : DateTime.Parse(reader["DataUltimaAlteracao"].ToString()!)
            };
        }

        // ============================================================
        // VERIFICAR SE VENDEDOR JÁ TEM COMISSÃO
        // ============================================================
        public bool VendedorTemComissao(string codigoPN, int? idComissaoAtual = null)
        {
            using var connection = new SqliteConnection(_connectionString);
            connection.Open();

            string sql = @"
                SELECT COUNT(*)
                FROM ComissoesVendedores
                WHERE CodigoPN = @CodigoPN
                AND (@IdComissaoAtual IS NULL OR IdComissao <> @IdComissaoAtual)
            ";

            using var cmd = new SqliteCommand(sql, connection);
            cmd.Parameters.AddWithValue("@CodigoPN", codigoPN);
            cmd.Parameters.AddWithValue("@IdComissaoAtual", (object?)idComissaoAtual ?? DBNull.Value);

            long count = (long)cmd.ExecuteScalar();
            return count > 0;
        }

        // ============================================================
        // ADICIONAR NOVA COMISSÃO
        // ============================================================
        public void Adicionar(ComissaoVendedor comissao)
        {
            using var connection = new SqliteConnection(_connectionString);
            connection.Open();

            string sql = @"
                INSERT INTO ComissoesVendedores
                (CodigoPN, PercentualComissao, DataCadastro, DataUltimaAlteracao)
                VALUES
                (@CodigoPN, @PercentualComissao, @DataCadastro, @DataUltimaAlteracao)
            ";

            using var cmd = new SqliteCommand(sql, connection);
            cmd.Parameters.AddWithValue("@CodigoPN", comissao.CodigoPN);
            cmd.Parameters.AddWithValue("@PercentualComissao", comissao.PercentualComissao);
            cmd.Parameters.AddWithValue("@DataCadastro", comissao.DataCadastro.ToString("yyyy-MM-dd HH:mm:ss"));
            cmd.Parameters.AddWithValue("@DataUltimaAlteracao", DBNull.Value);

            cmd.ExecuteNonQuery();
        }

        // ============================================================
        // ATUALIZAR COMISSÃO EXISTENTE
        // ============================================================
        public void Atualizar(ComissaoVendedor comissao)
        {
            using var connection = new SqliteConnection(_connectionString);
            connection.Open();

            string sql = @"
                UPDATE ComissoesVendedores SET
                    PercentualComissao = @PercentualComissao,
                    DataUltimaAlteracao = @DataUltimaAlteracao
                WHERE IdComissao = @IdComissao
            ";

            using var cmd = new SqliteCommand(sql, connection);
            cmd.Parameters.AddWithValue("@IdComissao", comissao.IdComissao);
            cmd.Parameters.AddWithValue("@PercentualComissao", comissao.PercentualComissao);
            cmd.Parameters.AddWithValue("@DataUltimaAlteracao", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));

            cmd.ExecuteNonQuery();
        }

        // ============================================================
        // EXCLUIR COMISSÃO
        // ============================================================
        public void Excluir(int idComissao)
        {
            using var connection = new SqliteConnection(_connectionString);
            connection.Open();

            string sql = "DELETE FROM ComissoesVendedores WHERE IdComissao = @IdComissao";

            using var cmd = new SqliteCommand(sql, connection);
            cmd.Parameters.AddWithValue("@IdComissao", idComissao);

            cmd.ExecuteNonQuery();
        }

        // ============================================================
        // SALVAR COMISSÃO (INSERE OU ATUALIZA)
        // ============================================================
        public void Salvar(ComissaoVendedor comissao)
        {
            // Validações básicas
            if (string.IsNullOrWhiteSpace(comissao.CodigoPN))
                throw new Exception("É necessário selecionar um vendedor.");

            if (comissao.PercentualComissao <= 0 || comissao.PercentualComissao > 100)
                throw new Exception("O percentual de comissão deve ser maior que 0 e menor ou igual a 100.");

            // Verificar se o Parceiro de Negócio existe e é do tipo Vendedor
            var parceiro = _parceiroRepo.BuscarPorCodigo(comissao.CodigoPN);
            
            if (parceiro == null)
                throw new Exception("Parceiro de Negócio não encontrado.");

            if (parceiro.TipoParceiro != TipoParceiro.Vendedor && parceiro.TipoParceiro != TipoParceiro.Socio)
                throw new Exception("Apenas Parceiros de Negócio do tipo Vendedor podem receber comissão.");

            // Verificar se já existe comissão para este vendedor
            bool novo = comissao.IdComissao == 0;
            
            if (novo)
            {
                if (VendedorTemComissao(comissao.CodigoPN))
                    throw new Exception("Este vendedor já possui uma comissão cadastrada. Edite a comissão existente.");

                comissao.DataCadastro = DateTime.Now;
                Adicionar(comissao);
            }
            else
            {
                if (VendedorTemComissao(comissao.CodigoPN, comissao.IdComissao))
                    throw new Exception("Este vendedor já possui uma comissão cadastrada. Edite a comissão existente.");

                comissao.DataUltimaAlteracao = DateTime.Now;
                Atualizar(comissao);
            }
        }
    }
}
