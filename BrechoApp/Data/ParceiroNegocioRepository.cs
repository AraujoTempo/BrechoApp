using BrechoApp.Models;
using BrechoApp.Utils;
using BrechoApp.Enums;
using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace BrechoApp.Data
{
    /// <summary>
    /// Repositório responsável por todas as operações de banco
    /// relacionadas ao Parceiro de Negócio (PN).
    /// 
    /// Substitui completamente o antigo FornecedorRepository.
    /// Usa a tabela "ParceirosNegocio".
    /// 
    /// Padrão de código:
    ///     PN1, PN2, PN3...
    /// </summary>
    public class ParceiroNegocioRepository
    {
        private readonly string _connectionString = DatabaseConfig.ConnectionString;

        // CPF/CNPJ dummy usado quando o parceiro não deseja informar CPF/CNPJ real
        private const string CPFCNPJ_DUMMY = "123.456.789-09";

        public ParceiroNegocioRepository()
        {
            // Garante que a base esteja criada/atualizada
            DatabaseInitializer.Initialize();
        }

        // ============================================================
        //  HELPER: PARSE TIPO PARCEIRO
        // ============================================================
        private TipoParceiro ParseTipoParceiroOrDefault(object value)
        {
            return Enum.TryParse<TipoParceiro>(value?.ToString(), out var tipo) 
                ? tipo 
                : TipoParceiro.Outro;
        }

        // ============================================================
        //  GERA PRÓXIMO CÓDIGO PN (PN1, PN2, PN3...)
        // ============================================================
        private string GerarProximoCodigo()
        {
            using var connection = new SqliteConnection(_connectionString);
            connection.Open();

            string sql = @"
                SELECT CodigoParceiro
                FROM ParceirosNegocio
                WHERE CodigoParceiro LIKE 'PN%'
                ORDER BY CAST(SUBSTR(CodigoParceiro, 3) AS INTEGER) DESC
                LIMIT 1;
            ";

            using var cmd = new SqliteCommand(sql, connection);
            var result = cmd.ExecuteScalar()?.ToString();

            if (string.IsNullOrWhiteSpace(result))
                return "PN1";

            string numeroStr = result.Length > 2 ? result.Substring(2) : "0";

            if (int.TryParse(numeroStr, out int numero))
                return $"PN{numero + 1}";

            return "PN1";
        }

        // ============================================================
        //  VERIFICA SE PARCEIRO EXISTE PELO CÓDIGO
        // ============================================================
        private bool ParceiroExiste(string codigo)
        {
            using var connection = new SqliteConnection(_connectionString);
            connection.Open();

            string sql = "SELECT COUNT(*) FROM ParceirosNegocio WHERE CodigoParceiro = @Codigo";

            using var cmd = new SqliteCommand(sql, connection);
            cmd.Parameters.AddWithValue("@Codigo", codigo);

            long count = (long)cmd.ExecuteScalar();
            return count > 0;
        }

        // ============================================================
        //  CPF/CNPJ DUPLICADO (AGORA PÚBLICO)
        // ============================================================
        public bool DocumentoExiste(string documento, string codigoAtual = null)
        {
            using var connection = new SqliteConnection(_connectionString);
            connection.Open();

            string sql = @"
                SELECT COUNT(*)
                FROM ParceirosNegocio
                WHERE CpfCnpj = @Documento
                AND (@CodigoAtual IS NULL OR CodigoParceiro <> @CodigoAtual)
            ";

            using var cmd = new SqliteCommand(sql, connection);
            cmd.Parameters.AddWithValue("@Documento", documento);
            cmd.Parameters.AddWithValue("@CodigoAtual", (object?)codigoAtual ?? DBNull.Value);

            long count = (long)cmd.ExecuteScalar();
            return count > 0;
        }

        // Mantido para compatibilidade com código existente
        public bool CpfExiste(string cpf, string codigoAtual = null)
        {
            return DocumentoExiste(cpf, codigoAtual);
        }

        // ============================================================
        //  APELIDO DUPLICADO
        // ============================================================
        private bool ApelidoExiste(string apelido, string codigoAtual = null)
        {
            using var connection = new SqliteConnection(_connectionString);
            connection.Open();

            string sql = @"
                SELECT COUNT(*)
                FROM ParceirosNegocio
                WHERE Apelido = @Apelido
                AND (@CodigoAtual IS NULL OR CodigoParceiro <> @CodigoAtual)
            ";

            using var cmd = new SqliteCommand(sql, connection);
            cmd.Parameters.AddWithValue("@Apelido", apelido);
            cmd.Parameters.AddWithValue("@CodigoAtual", (object?)codigoAtual ?? DBNull.Value);

            long count = (long)cmd.ExecuteScalar();
            return count > 0;
        }

        // ============================================================
        //  LISTAR TODOS OS PARCEIROS
        // ============================================================
        public List<ParceiroNegocio> ListarParceiros()
        {
            var lista = new List<ParceiroNegocio>();

            using var connection = new SqliteConnection(_connectionString);
            connection.Open();

            string sql = @"
                SELECT CodigoParceiro, Nome, TipoParceiro, CpfCnpj, Apelido, Telefone, Endereco, Email,
                       Banco, Agencia, Conta, Pix, PercentualComissao, AutorizaDoacao,
                       Observacao, Aniversario, SaldoCredito
                FROM ParceirosNegocio
                ORDER BY CAST(SUBSTR(CodigoParceiro, 3) AS INTEGER)
            ";

            using var cmd = new SqliteCommand(sql, connection);
            using var reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                lista.Add(new ParceiroNegocio
                {
                    CodigoParceiro = reader["CodigoParceiro"].ToString()!,
                    Nome = reader["Nome"].ToString()!,
                    TipoParceiro = ParseTipoParceiroOrDefault(reader["TipoParceiro"]),
                    CpfCnpj = reader["CpfCnpj"].ToString()!,
                    Apelido = reader["Apelido"].ToString()!,
                    Telefone = reader["Telefone"].ToString()!,

                    Endereco = reader["Endereco"]?.ToString(),
                    Email = reader["Email"]?.ToString(),
                    Banco = reader["Banco"]?.ToString(),
                    Agencia = reader["Agencia"]?.ToString(),
                    Conta = reader["Conta"]?.ToString(),
                    Pix = reader["Pix"]?.ToString(),

                    PercentualComissao = reader["PercentualComissao"] == DBNull.Value
                        ? 0
                        : Convert.ToDouble(reader["PercentualComissao"], CultureInfo.InvariantCulture),

                    AutorizaDoacao = Convert.ToInt32(reader["AutorizaDoacao"]) == 1,

                    Observacao = reader["Observacao"]?.ToString(),
                    Aniversario = reader["Aniversario"]?.ToString(),

                    SaldoCredito = reader["SaldoCredito"] == DBNull.Value
                        ? 0
                        : Convert.ToDouble(reader["SaldoCredito"], CultureInfo.InvariantCulture)
                });
            }

            return lista;
        }

        // ============================================================
        //  BUSCAR POR CÓDIGO
        // ============================================================
        public ParceiroNegocio BuscarPorCodigo(string codigo)
        {
            using var connection = new SqliteConnection(_connectionString);
            connection.Open();

            string sql = @"
                SELECT CodigoParceiro, Nome, TipoParceiro, CpfCnpj, Apelido, Telefone, Endereco, Email,
                       Banco, Agencia, Conta, Pix, PercentualComissao, AutorizaDoacao,
                       Observacao, Aniversario, SaldoCredito
                FROM ParceirosNegocio
                WHERE CodigoParceiro = @Codigo
                LIMIT 1;
            ";

            using var cmd = new SqliteCommand(sql, connection);
            cmd.Parameters.AddWithValue("@Codigo", codigo);

            using var reader = cmd.ExecuteReader();

            if (!reader.Read())
                return null;

            return new ParceiroNegocio
            {
                CodigoParceiro = reader["CodigoParceiro"].ToString()!,
                Nome = reader["Nome"].ToString()!,
                TipoParceiro = ParseTipoParceiroOrDefault(reader["TipoParceiro"]),
                CpfCnpj = reader["CpfCnpj"].ToString()!,
                Apelido = reader["Apelido"].ToString()!,
                Telefone = reader["Telefone"].ToString()!,

                Endereco = reader["Endereco"]?.ToString(),
                Email = reader["Email"]?.ToString(),
                Banco = reader["Banco"]?.ToString(),
                Agencia = reader["Agencia"]?.ToString(),
                Conta = reader["Conta"]?.ToString(),
                Pix = reader["Pix"]?.ToString(),

                PercentualComissao = reader["PercentualComissao"] == DBNull.Value
                    ? 0
                    : Convert.ToDouble(reader["PercentualComissao"], CultureInfo.InvariantCulture),

                AutorizaDoacao = Convert.ToInt32(reader["AutorizaDoacao"]) == 1,

                Observacao = reader["Observacao"]?.ToString(),
                Aniversario = reader["Aniversario"]?.ToString(),

                SaldoCredito = reader["SaldoCredito"] == DBNull.Value
                    ? 0
                    : Convert.ToDouble(reader["SaldoCredito"], CultureInfo.InvariantCulture)
            };
        }

        // ============================================================
        //  BUSCA EM TODOS OS CAMPOS (filtro textual)
        // ============================================================
        public List<ParceiroNegocio> Buscar(string termo)
        {
            termo = termo.ToLower();

            return ListarParceiros()
                .Where(p =>
                    (p.Nome?.ToLower().Contains(termo) ?? false) ||
                    (p.Apelido?.ToLower().Contains(termo) ?? false) ||
                    (p.CpfCnpj?.ToLower().Contains(termo) ?? false) ||
                    (p.Telefone?.ToLower().Contains(termo) ?? false) ||
                    (p.Email?.ToLower().Contains(termo) ?? false) ||
                    (p.Endereco?.ToLower().Contains(termo) ?? false) ||
                    (p.Banco?.ToLower().Contains(termo) ?? false) ||
                    (p.Agencia?.ToLower().Contains(termo) ?? false) ||
                    (p.Conta?.ToLower().Contains(termo) ?? false) ||
                    (p.Pix?.ToLower().Contains(termo) ?? false) ||
                    (p.Observacao?.ToLower().Contains(termo) ?? false)
                )
                .ToList();
        }

        // ============================================================
        //  INSERIR NOVO PARCEIRO
        // ============================================================
        public void AdicionarParceiro(ParceiroNegocio p)
        {
            using var connection = new SqliteConnection(_connectionString);
            connection.Open();

            string sql = @"
                INSERT INTO ParceirosNegocio
                (CodigoParceiro, Nome, TipoParceiro, CpfCnpj, Apelido, Telefone, Endereco, Email, Banco, Agencia, Conta, Pix,
                 PercentualComissao, AutorizaDoacao, Observacao, Aniversario, SaldoCredito,
                 DataCriacao, UltimaAtualizacao)
                VALUES
                (@Codigo, @Nome, @TipoParceiro, @CpfCnpj, @Apelido, @Telefone, @Endereco, @Email, @Banco, @Agencia, @Conta, @Pix,
                 @Comissao, @Doacao, @Obs, @Aniversario, @Saldo,
                 @DataCriacao, @UltimaAtualizacao)
            ";

            using var cmd = new SqliteCommand(sql, connection);

            cmd.Parameters.AddWithValue("@Codigo", p.CodigoParceiro);
            cmd.Parameters.AddWithValue("@Nome", p.Nome);
            cmd.Parameters.AddWithValue("@TipoParceiro", p.TipoParceiro.ToString());
            cmd.Parameters.AddWithValue("@CpfCnpj", p.CpfCnpj);
            cmd.Parameters.AddWithValue("@Apelido", p.Apelido);
            cmd.Parameters.AddWithValue("@Telefone", p.Telefone);

            cmd.Parameters.AddWithValue("@Endereco", (object?)p.Endereco ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@Email", (object?)p.Email ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@Banco", (object?)p.Banco ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@Agencia", (object?)p.Agencia ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@Conta", (object?)p.Conta ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@Pix", (object?)p.Pix ?? DBNull.Value);

            cmd.Parameters.AddWithValue("@Comissao", p.PercentualComissao);
            cmd.Parameters.AddWithValue("@Doacao", p.AutorizaDoacao ? 1 : 0);
            cmd.Parameters.AddWithValue("@Obs", (object?)p.Observacao ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@Aniversario", (object?)p.Aniversario ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@Saldo", p.SaldoCredito);

            cmd.Parameters.AddWithValue("@DataCriacao", p.DataCriacao.ToString("yyyy-MM-dd HH:mm:ss"));
            cmd.Parameters.AddWithValue("@UltimaAtualizacao", p.UltimaAtualizacao.ToString("yyyy-MM-dd HH:mm:ss"));

            cmd.ExecuteNonQuery();
        }

        // ============================================================
        //  ATUALIZAR PARCEIRO EXISTENTE
        // ============================================================
        public void AtualizarParceiro(ParceiroNegocio p)
        {
            using var connection = new SqliteConnection(_connectionString);
            connection.Open();

            string sql = @"
                UPDATE ParceirosNegocio SET
                    Nome=@Nome,
                    TipoParceiro=@TipoParceiro,
                    CpfCnpj=@CpfCnpj,
                    Apelido=@Apelido,
                    Telefone=@Telefone,
                    Endereco=@Endereco,
                    Email=@Email,
                    Banco=@Banco,
                    Agencia=@Agencia,
                    Conta=@Conta,
                    Pix=@Pix,
                    PercentualComissao=@Comissao,
                    AutorizaDoacao=@Doacao,
                    Observacao=@Obs,
                    Aniversario=@Aniversario,
                    SaldoCredito=@Saldo,
                    UltimaAtualizacao=@UltimaAtualizacao
                WHERE CodigoParceiro=@Codigo
            ";

            using var cmd = new SqliteCommand(sql, connection);

            cmd.Parameters.AddWithValue("@Codigo", p.CodigoParceiro);
            cmd.Parameters.AddWithValue("@Nome", p.Nome);
            cmd.Parameters.AddWithValue("@TipoParceiro", p.TipoParceiro.ToString());
            cmd.Parameters.AddWithValue("@CpfCnpj", p.CpfCnpj);
            cmd.Parameters.AddWithValue("@Apelido", p.Apelido);
            cmd.Parameters.AddWithValue("@Telefone", p.Telefone);

            cmd.Parameters.AddWithValue("@Endereco", (object?)p.Endereco ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@Email", (object?)p.Email ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@Banco", (object?)p.Banco ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@Agencia", (object?)p.Agencia ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@Conta", (object?)p.Conta ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@Pix", (object?)p.Pix ?? DBNull.Value);

            cmd.Parameters.AddWithValue("@Comissao", p.PercentualComissao);
            cmd.Parameters.AddWithValue("@Doacao", p.AutorizaDoacao ? 1 : 0);
            cmd.Parameters.AddWithValue("@Obs", (object?)p.Observacao ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@Aniversario", (object?)p.Aniversario ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@Saldo", p.SaldoCredito);

            cmd.Parameters.AddWithValue("@UltimaAtualizacao", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));

            cmd.ExecuteNonQuery();
        }

        // ============================================================
        //  EXCLUSÃO BLOQUEADA (regra de negócio)
        // ============================================================
        public void ExcluirParceiro(string codigo)
        {
            throw new Exception("Não é permitido excluir Parceiros de Negócio. Esta operação é bloqueada pelo sistema.");
        }

        // ============================================================
        //  SALVAR PARCEIRO (INSERE OU ATUALIZA)
        // ============================================================
        public void SalvarParceiro(ParceiroNegocio p)
        {
            bool novo = string.IsNullOrWhiteSpace(p.CodigoParceiro);

            // Se for novo → gera código PNx
            if (novo)
            {
                p.CodigoParceiro = GerarProximoCodigo();
                p.DataCriacao = DateTime.Now;
            }

            p.UltimaAtualizacao = DateTime.Now;

            // ------------------------------
            // VALIDAÇÕES BÁSICAS
            // ------------------------------
            if (string.IsNullOrWhiteSpace(p.Nome))
                throw new Exception("O campo Nome é obrigatório.");

            if (string.IsNullOrWhiteSpace(p.CpfCnpj))
                throw new Exception("O campo CPF/CNPJ é obrigatório.");

            if (string.IsNullOrWhiteSpace(p.Apelido))
                throw new Exception("O campo Apelido é obrigatório.");

            if (p.PercentualComissao < 0)
                throw new Exception("O Percentual de Comissão não pode ser negativo.");

            // ------------------------------
            // TRATAMENTO ESPECIAL PARA CPF/CNPJ DUMMY
            // ------------------------------
            if (p.CpfCnpj != CPFCNPJ_DUMMY)
            {
                if (DocumentoExiste(p.CpfCnpj, novo ? null : p.CodigoParceiro))
                    throw new Exception("Já existe um parceiro cadastrado com este CPF/CNPJ.");

                if (!ValidadorBrasil.DocumentoValido(p.CpfCnpj))
                    throw new Exception("CPF/CNPJ inválido.");
            }

            // ------------------------------
            // VALIDAÇÕES ADICIONAIS
            // ------------------------------
            if (!string.IsNullOrWhiteSpace(p.Email) && !ValidadorBrasil.EmailValido(p.Email))
                throw new Exception("E-mail inválido.");

            if (!string.IsNullOrWhiteSpace(p.Telefone) && !ValidadorBrasil.TelefoneValido(p.Telefone))
                throw new Exception("Telefone inválido.");

            if (!string.IsNullOrWhiteSpace(p.Agencia) && !ValidadorBrasil.AgenciaValida(p.Agencia))
                throw new Exception("Agência inválida.");

            if (!string.IsNullOrWhiteSpace(p.Conta) && !ValidadorBrasil.ContaValida(p.Conta))
                throw new Exception("Conta bancária inválida.");

            if (!string.IsNullOrWhiteSpace(p.Pix) && !ValidadorBrasil.PixValido(p.Pix))
                throw new Exception("Chave PIX inválida.");

            // ------------------------------
            // APELIDO DUPLICADO
            // ------------------------------
            if (ApelidoExiste(p.Apelido, novo ? null : p.CodigoParceiro))
                throw new Exception("Já existe um parceiro cadastrado com este Apelido.");

            // ------------------------------
            // DECISÃO ENTRE INSERIR OU ATUALIZAR
            // ------------------------------
            if (ParceiroExiste(p.CodigoParceiro))
                AtualizarParceiro(p);
            else
                AdicionarParceiro(p);
        }

        // ============================================================
        //  LISTAR VENDEDORES
        //  Retorna apenas PNs com TipoParceiro = Vendedor
        // ============================================================
        public List<ParceiroNegocio> ListarVendedores()
        {
            return ListarParceiros()
                .Where(p => p.TipoParceiro == TipoParceiro.Vendedor)
                .ToList();
        }
    }
}