using BrechoApp.Models;
using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;

namespace BrechoApp.Data
{
    /// <summary>
    /// Repositório responsável por gerenciar lotes de recebimento.
    /// Inclui criação, atualização, aprovação, reabertura, exclusão e consultas.
    /// Agora com normalização de códigos para evitar inconsistências e falhas de FK.
    /// </summary>
    public class LoteRecebimentoRepository
    {
        // ============================================================
        // MÉTODO DE NORMALIZAÇÃO
        //
        // Garante que códigos vindos da UI estejam limpos e consistentes.
        // Remove espaços, quebras de linha e hífens unicode.
        // =====================================================================
        private string NormalizarCodigo(string codigo)
        {
            if (string.IsNullOrWhiteSpace(codigo))
                return ""; // nunca retornar null

            return codigo
                .Trim()
                .Replace("–", "-")
                .Replace("—", "-")
                .Replace("‑", "-")
                .Replace("\r", "")
                .Replace("\n", "");
        }

        // =====================================================================
        // GERA O PRÓXIMO CÓDIGO DO LOTE
        //
        // Formato: PN{Parceiro}-L{Sequencia}
        // Exemplo: PN12-L1, PN12-L2, PN7-L1
        //
        // Agora com normalização para garantir consistência.
        // - Busca o último lote do parceiro
        // - Extrai o número após "-L"
        // - Incrementa para gerar o próximo
        // =====================================================================
        private string GerarProximoCodigoLote(string codigoParceiro)
        {
            codigoParceiro = NormalizarCodigo(codigoParceiro);

            using var conn = Conexao.GetConnection();
            conn.Open();

            string sql = @"
                SELECT CodigoLoteRecebimento
                FROM LoteRecebimento
                WHERE CodigoParceiro = @Parceiro
                ORDER BY CodigoLoteRecebimento DESC
                LIMIT 1;
            ";

            using var cmd = new SqliteCommand(sql, conn);
            cmd.Parameters.AddWithValue("@Parceiro", codigoParceiro);

            var ultimo = cmd.ExecuteScalar()?.ToString();
            int proximoNumero = 1;

            if (!string.IsNullOrWhiteSpace(ultimo))
            {
                ultimo = NormalizarCodigo(ultimo);

                var partes = ultimo.Split("-L");
                if (partes.Length == 2 && int.TryParse(partes[1], out int numero))
                    proximoNumero = numero + 1;
            }

            return $"{codigoParceiro}-L{proximoNumero}";
        }

        // ============================================================
        // CRIA UM NOVO LOTE PARA O PARCEIRO
        //
        // Agora garantindo que o código seja normalizado antes de salvar.
        // =====================================================================
        public LoteRecebimento CriarNovoLote(string codigoParceiro)
        {
            codigoParceiro = NormalizarCodigo(codigoParceiro);

            string codigo = GerarProximoCodigoLote(codigoParceiro);

            var lote = new LoteRecebimento
            {
                CodigoLoteRecebimento = codigo,
                CodigoParceiro = codigoParceiro,
                DataCriacao = DateTime.Now,
                StatusLote = "Aberto",
                Observacoes = "",
                UltimaAtualizacao = DateTime.Now
            };

            CriarLote(lote);
            return lote;
        }

        // =====================================================================
        // INSERE O LOTE NO BANCO
        //
        // Agora com normalização antes de persistir.
        // =====================================================================
        public void CriarLote(LoteRecebimento lote)
        {
            lote.CodigoLoteRecebimento = NormalizarCodigo(lote.CodigoLoteRecebimento);
            lote.CodigoParceiro = NormalizarCodigo(lote.CodigoParceiro);

            using var conn = Conexao.GetConnection();
            conn.Open();

            string sql = @"
                INSERT INTO LoteRecebimento (
                    CodigoLoteRecebimento,
                    CodigoParceiro,
                    DataCriacao,
                    DataRecebimento,
                    DataAprovacao,
                    StatusLote,
                    Observacoes,
                    UltimaAtualizacao
                )
                VALUES (
                    @CodigoLoteRecebimento,
                    @CodigoParceiro,
                    @DataCriacao,
                    @DataRecebimento,
                    @DataAprovacao,
                    @StatusLote,
                    @Observacoes,
                    @UltimaAtualizacao
                )";

            using var cmd = new SqliteCommand(sql, conn);

            cmd.Parameters.AddWithValue("@CodigoLoteRecebimento", lote.CodigoLoteRecebimento);
            cmd.Parameters.AddWithValue("@CodigoParceiro", lote.CodigoParceiro);
            cmd.Parameters.AddWithValue("@DataCriacao", lote.DataCriacao.ToString("yyyy-MM-dd HH:mm:ss"));
            cmd.Parameters.AddWithValue("@DataRecebimento",
                lote.DataRecebimento?.ToString("yyyy-MM-dd HH:mm:ss") ?? (object)DBNull.Value);
            cmd.Parameters.AddWithValue("@DataAprovacao",
                lote.DataAprovacao?.ToString("yyyy-MM-dd HH:mm:ss") ?? (object)DBNull.Value);
            cmd.Parameters.AddWithValue("@StatusLote", lote.StatusLote);
            cmd.Parameters.AddWithValue("@Observacoes", lote.Observacoes ?? "");
            cmd.Parameters.AddWithValue("@UltimaAtualizacao", lote.UltimaAtualizacao.ToString("yyyy-MM-dd HH:mm:ss"));

            cmd.ExecuteNonQuery();
        }

        // =====================================================================
        // ATUALIZA O LOTE COMPLETO
        //
        // Atualiza todos os campos principais do lote.
        // Normaliza códigos antes de persistir.
        // =====================================================================
        public void AtualizarLote(LoteRecebimento lote)
        {
            lote.CodigoLoteRecebimento = NormalizarCodigo(lote.CodigoLoteRecebimento);
            lote.CodigoParceiro = NormalizarCodigo(lote.CodigoParceiro);

            using var conn = Conexao.GetConnection();
            conn.Open();

            string sql = @"
                UPDATE LoteRecebimento SET
                    CodigoParceiro = @CodigoParceiro,
                    DataRecebimento = @DataRecebimento,
                    DataAprovacao = @DataAprovacao,
                    StatusLote = @StatusLote,
                    Observacoes = @Observacoes,
                    UltimaAtualizacao = @UltimaAtualizacao
                WHERE CodigoLoteRecebimento = @CodigoLoteRecebimento";

            using var cmd = new SqliteCommand(sql, conn);

            cmd.Parameters.AddWithValue("@CodigoParceiro", lote.CodigoParceiro);
            cmd.Parameters.AddWithValue("@DataRecebimento",
                lote.DataRecebimento?.ToString("yyyy-MM-dd HH:mm:ss") ?? (object)DBNull.Value);
            cmd.Parameters.AddWithValue("@DataAprovacao",
                lote.DataAprovacao?.ToString("yyyy-MM-dd HH:mm:ss") ?? (object)DBNull.Value);
            cmd.Parameters.AddWithValue("@StatusLote", lote.StatusLote);
            cmd.Parameters.AddWithValue("@Observacoes", lote.Observacoes ?? "");
            cmd.Parameters.AddWithValue("@UltimaAtualizacao", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
            cmd.Parameters.AddWithValue("@CodigoLoteRecebimento", lote.CodigoLoteRecebimento);

            cmd.ExecuteNonQuery();
        }

        // ============================================================
        // ATUALIZA APENAS AS OBSERVAÇÕES
        //
        // Usado quando o usuário altera somente o campo Observações.
        // ============================================================
        public void AtualizarObservacoes(LoteRecebimento lote)
        {
            lote.CodigoLoteRecebimento = NormalizarCodigo(lote.CodigoLoteRecebimento);

            using var conn = Conexao.GetConnection();
            conn.Open();

            string sql = @"
                UPDATE LoteRecebimento SET
                    Observacoes = @Observacoes,
                    UltimaAtualizacao = @UltimaAtualizacao
                WHERE CodigoLoteRecebimento = @CodigoLoteRecebimento";

            using var cmd = new SqliteCommand(sql, conn);

            cmd.Parameters.AddWithValue("@Observacoes", lote.Observacoes ?? "");
            cmd.Parameters.AddWithValue("@UltimaAtualizacao", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
            cmd.Parameters.AddWithValue("@CodigoLoteRecebimento", lote.CodigoLoteRecebimento);

            cmd.ExecuteNonQuery();
        }

        // ============================================================
        // APROVA O LOTE
        //
        // Marca o lote como aprovado e registra a data.
        // ============================================================
        public void AprovarLote(string codigoLote)
        {
            codigoLote = NormalizarCodigo(codigoLote);

            using var conn = Conexao.GetConnection();
            conn.Open();

            string agora = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

            string sql = @"
                UPDATE LoteRecebimento SET
                    StatusLote = 'Aprovado',
                    DataAprovacao = @DataAprovacao,
                    UltimaAtualizacao = @UltimaAtualizacao
                WHERE CodigoLoteRecebimento = @CodigoLoteRecebimento";

            using var cmd = new SqliteCommand(sql, conn);

            cmd.Parameters.AddWithValue("@DataAprovacao", agora);
            cmd.Parameters.AddWithValue("@UltimaAtualizacao", agora);
            cmd.Parameters.AddWithValue("@CodigoLoteRecebimento", codigoLote);

            cmd.ExecuteNonQuery();
        }

        // ============================================================
        // REABRE UM LOTE APROVADO
        //
        // Permite ajustes posteriores.
        // =====================================================================
        public void ReabrirLote(string codigoLote)
        {
            codigoLote = NormalizarCodigo(codigoLote);

            using var conn = Conexao.GetConnection();
            conn.Open();

            string sql = @"
                UPDATE LoteRecebimento SET
                    StatusLote = 'Reaberto',
                    UltimaAtualizacao = @UltimaAtualizacao
                WHERE CodigoLoteRecebimento = @CodigoLoteRecebimento";

            using var cmd = new SqliteCommand(sql, conn);

            cmd.Parameters.AddWithValue("@UltimaAtualizacao", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
            cmd.Parameters.AddWithValue("@CodigoLoteRecebimento", codigoLote);

            cmd.ExecuteNonQuery();
        }

        // ============================================================
        // EXCLUI O LOTE E SEUS ITENS
        //
        // Usa transação para garantir integridade.
        // Agora com normalização do código antes de excluir.
        // ============================================================
        public void ExcluirLote(string codigoLote)
        {
            codigoLote = NormalizarCodigo(codigoLote);

            using var conn = Conexao.GetConnection();
            conn.Open();

            using var trans = conn.BeginTransaction();

            try
            {
                // Remove itens do lote
                string sqlItens = "DELETE FROM ItemLote WHERE CodigoLoteRecebimento = @Codigo";
                using (var cmdItens = new SqliteCommand(sqlItens, conn, trans))
                {
                    cmdItens.Parameters.AddWithValue("@Codigo", codigoLote);
                    cmdItens.ExecuteNonQuery();
                }

                // Remove o lote
                string sqlLote = "DELETE FROM LoteRecebimento WHERE CodigoLoteRecebimento = @Codigo";
                using (var cmdLote = new SqliteCommand(sqlLote, conn, trans))
                {
                    cmdLote.Parameters.AddWithValue("@Codigo", codigoLote);
                    cmdLote.ExecuteNonQuery();
                }

                trans.Commit();
            }
            catch
            {
                trans.Rollback();
                throw;
            }
        }

        // =====================================================================
        // BUSCA UM LOTE PELO CÓDIGO COMPLETO (PNx-Ly)
        //
        // Agora com normalização antes da consulta.
        // =====================================================================
        public LoteRecebimento BuscarPorCodigo(string codigoLote)
        {
            codigoLote = NormalizarCodigo(codigoLote);

            using var conn = Conexao.GetConnection();
            conn.Open();

            string sql = "SELECT * FROM LoteRecebimento WHERE CodigoLoteRecebimento = @Codigo";

            using var cmd = new SqliteCommand(sql, conn);
            cmd.Parameters.AddWithValue("@Codigo", codigoLote);

            using var reader = cmd.ExecuteReader();
            if (reader.Read())
                return Mapear(reader);

            return null;
        }

        // ============================================================
        // LISTA LOTES POR PARCEIRO
        //
        // Agora com normalização do código do parceiro.
        // ============================================================
        public List<LoteRecebimento> ListarPorParceiro(string codigoParceiro)
        {
            codigoParceiro = NormalizarCodigo(codigoParceiro);

            var lista = new List<LoteRecebimento>();

            using var conn = Conexao.GetConnection();
            conn.Open();

            string sql = "SELECT * FROM LoteRecebimento WHERE CodigoParceiro = @Parceiro";

            using var cmd = new SqliteCommand(sql, conn);
            cmd.Parameters.AddWithValue("@Parceiro", codigoParceiro);

            using var reader = cmd.ExecuteReader();
            while (reader.Read())
                lista.Add(Mapear(reader));

            return lista;
        }

        // =====================================================================
        // MAPEA UM REGISTRO DO SQLITE PARA OBJETO LoteRecebimento
        //
        // Normaliza códigos ao carregar do banco.
        // =====================================================================
        private LoteRecebimento Mapear(SqliteDataReader reader)
        {
            return new LoteRecebimento
            {
                CodigoLoteRecebimento = NormalizarCodigo(reader["CodigoLoteRecebimento"].ToString()),
                CodigoParceiro = NormalizarCodigo(reader["CodigoParceiro"].ToString()),

                DataCriacao = Convert.ToDateTime(reader["DataCriacao"]),

                DataRecebimento = reader["DataRecebimento"] == DBNull.Value
                    ? null
                    : Convert.ToDateTime(reader["DataRecebimento"]),

                DataAprovacao = reader["DataAprovacao"] == DBNull.Value
                    ? null
                    : Convert.ToDateTime(reader["DataAprovacao"]),

                StatusLote = reader["StatusLote"].ToString(),
                Observacoes = reader["Observacoes"] == DBNull.Value ? "" : reader["Observacoes"].ToString(),

                UltimaAtualizacao = reader["UltimaAtualizacao"] == DBNull.Value
                    ? DateTime.Now
                    : Convert.ToDateTime(reader["UltimaAtualizacao"])
            };
        }
    }
}
