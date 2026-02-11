using BrechoApp.Models;
using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;

namespace BrechoApp.Data
{
    /// <summary>
    /// Repositório responsável por gerenciar os itens de um lote.
    /// Inclui operações de CRUD e mapeamento para o modelo ItemLote.
    /// Agora com normalização de códigos para evitar falhas de FK.
    /// </summary>
    public class ItemLoteRepository
    {
        // ============================================================
        // MÉTODO DE NORMALIZAÇÃO
        //
        // Garante que códigos vindos da UI estejam limpos e consistentes.
        // Remove espaços, quebras de linha e hífens unicode.
        // ============================================================
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

        // ============================================================
        // VERIFICA SE O LOTE EXISTE (PROTEÇÃO DE FK)
        // ============================================================
        private bool LoteExiste(string codigoLote)
        {
            if (string.IsNullOrWhiteSpace(codigoLote))
                return false;

            using var conn = Conexao.GetConnection();
            conn.Open();

            string sql = "SELECT COUNT(*) FROM LoteRecebimento WHERE CodigoLoteRecebimento = @Codigo";

            using var cmd = new SqliteCommand(sql, conn);
            cmd.Parameters.AddWithValue("@Codigo", codigoLote);

            long count = (long)cmd.ExecuteScalar();
            return count > 0;
        }

        // ============================================================
        // LISTAR ITENS POR LOTE
        //
        // Retorna todos os itens associados a um lote específico.
        // Ordena por Id para manter a ordem de inserção.
        // ============================================================
        public List<ItemLote> ListarItensPorLote(string codigoLote)
        {
            codigoLote = NormalizarCodigo(codigoLote);

            var lista = new List<ItemLote>();

            using var conn = Conexao.GetConnection();
            conn.Open();

            string sql = @"
                SELECT 
                    Id,
                    CodigoLoteRecebimento,
                    CodigoParceiro,
                    NomeDoItem,
                    MarcaDoItem,
                    CategoriaDoItem,
                    TamanhoCorDoItem,
                    ObservacaoDoItem,
                    PrecoSugeridoDoItem,
                    PrecoVendaDoItem,
                    StatusItem,
                    CodigoProdutoGerado,
                    DataCriacao,
                    UltimaAtualizacao
                FROM ItemLote
                WHERE CodigoLoteRecebimento = @CodigoLoteRecebimento
                ORDER BY Id
            ";

            using var cmd = new SqliteCommand(sql, conn);
            cmd.Parameters.AddWithValue("@CodigoLoteRecebimento", codigoLote);

            using var reader = cmd.ExecuteReader();
            while (reader.Read())
                lista.Add(Mapear(reader));

            return lista;
        }

        // ============================================================
        // BUSCAR POR ID
        //
        // Usado para edição ou carregamento de item específico.
        // ============================================================
        public ItemLote? BuscarPorId(int id)
        {
            using var conn = Conexao.GetConnection();
            conn.Open();

            string sql = @"
                SELECT 
                    Id,
                    CodigoLoteRecebimento,
                    CodigoParceiro,
                    NomeDoItem,
                    MarcaDoItem,
                    CategoriaDoItem,
                    TamanhoCorDoItem,
                    ObservacaoDoItem,
                    PrecoSugeridoDoItem,
                    PrecoVendaDoItem,
                    StatusItem,
                    CodigoProdutoGerado,
                    DataCriacao,
                    UltimaAtualizacao
                FROM ItemLote
                WHERE Id = @Id
            ";

            using var cmd = new SqliteCommand(sql, conn);
            cmd.Parameters.AddWithValue("@Id", id);

            using var reader = cmd.ExecuteReader();
            if (reader.Read())
                return Mapear(reader);

            return null;
        }
        // ============================================================
        // ADICIONAR ITEM
        //
        // Insere um novo item no lote.
        // CodigoProdutoGerado deve ser vazio até a aprovação do lote.
        // Agora com normalização do código do lote e do parceiro.
        // ============================================================
        public void AdicionarItem(ItemLote item)
        {
            item.CodigoLoteRecebimento = NormalizarCodigo(item.CodigoLoteRecebimento);
            item.CodigoParceiro = NormalizarCodigo(item.CodigoParceiro);

            if (!LoteExiste(item.CodigoLoteRecebimento))
                throw new Exception("O lote informado não existe. Não é possível inserir o item.");

            using var conn = Conexao.GetConnection();
            conn.Open();

            string sql = @"
                INSERT INTO ItemLote (
                    CodigoLoteRecebimento,
                    CodigoParceiro,
                    NomeDoItem,
                    MarcaDoItem,
                    CategoriaDoItem,
                    TamanhoCorDoItem,
                    ObservacaoDoItem,
                    PrecoSugeridoDoItem,
                    PrecoVendaDoItem,
                    StatusItem,
                    CodigoProdutoGerado,
                    DataCriacao,
                    UltimaAtualizacao
                )
                VALUES (
                    @CodigoLoteRecebimento,
                    @CodigoParceiro,
                    @NomeDoItem,
                    @MarcaDoItem,
                    @CategoriaDoItem,
                    @TamanhoCorDoItem,
                    @ObservacaoDoItem,
                    @PrecoSugeridoDoItem,
                    @PrecoVendaDoItem,
                    @StatusItem,
                    @CodigoProdutoGerado,
                    @DataCriacao,
                    @UltimaAtualizacao
                )
            ";

            using var cmd = new SqliteCommand(sql, conn);

            cmd.Parameters.AddWithValue("@CodigoLoteRecebimento", item.CodigoLoteRecebimento);
            cmd.Parameters.AddWithValue("@CodigoParceiro", item.CodigoParceiro);
            cmd.Parameters.AddWithValue("@NomeDoItem", item.NomeDoItem);
            cmd.Parameters.AddWithValue("@MarcaDoItem", item.MarcaDoItem);
            cmd.Parameters.AddWithValue("@CategoriaDoItem", item.CategoriaDoItem);
            cmd.Parameters.AddWithValue("@TamanhoCorDoItem", item.TamanhoCorDoItem);
            cmd.Parameters.AddWithValue("@ObservacaoDoItem", item.ObservacaoDoItem ?? "");

            cmd.Parameters.AddWithValue("@PrecoSugeridoDoItem", item.PrecoSugeridoDoItem);
            cmd.Parameters.AddWithValue("@PrecoVendaDoItem", item.PrecoVendaDoItem);

            cmd.Parameters.AddWithValue("@StatusItem", item.StatusItem);

            // FK opcional → usar DBNull.Value
            if (string.IsNullOrWhiteSpace(item.CodigoProdutoGerado))
                cmd.Parameters.AddWithValue("@CodigoProdutoGerado", DBNull.Value);
            else
                cmd.Parameters.AddWithValue("@CodigoProdutoGerado", item.CodigoProdutoGerado);

            cmd.Parameters.AddWithValue("@DataCriacao", item.DataCriacao.ToString("yyyy-MM-dd HH:mm:ss"));
            cmd.Parameters.AddWithValue("@UltimaAtualizacao", item.UltimaAtualizacao.ToString("yyyy-MM-dd HH:mm:ss"));

            cmd.ExecuteNonQuery();
        }

        // ============================================================
        // ATUALIZAR ITEM
        //
        // Atualiza dados do item ou registra o produto gerado.
        // Normaliza códigos antes de atualizar.
        // ============================================================
        public void AtualizarItem(ItemLote item)
        {
            item.CodigoParceiro = NormalizarCodigo(item.CodigoParceiro);
            item.CodigoLoteRecebimento = NormalizarCodigo(item.CodigoLoteRecebimento);

            using var conn = Conexao.GetConnection();
            conn.Open();

            string sql = @"
                UPDATE ItemLote SET
                    CodigoParceiro = @CodigoParceiro,
                    NomeDoItem = @NomeDoItem,
                    MarcaDoItem = @MarcaDoItem,
                    CategoriaDoItem = @CategoriaDoItem,
                    TamanhoCorDoItem = @TamanhoCorDoItem,
                    ObservacaoDoItem = @ObservacaoDoItem,
                    PrecoSugeridoDoItem = @PrecoSugeridoDoItem,
                    PrecoVendaDoItem = @PrecoVendaDoItem,
                    StatusItem = @StatusItem,
                    CodigoProdutoGerado = @CodigoProdutoGerado,
                    UltimaAtualizacao = @UltimaAtualizacao
                WHERE Id = @Id
            ";

            using var cmd = new SqliteCommand(sql, conn);

            cmd.Parameters.AddWithValue("@Id", item.Id);
            cmd.Parameters.AddWithValue("@CodigoParceiro", item.CodigoParceiro);
            cmd.Parameters.AddWithValue("@NomeDoItem", item.NomeDoItem);
            cmd.Parameters.AddWithValue("@MarcaDoItem", item.MarcaDoItem);
            cmd.Parameters.AddWithValue("@CategoriaDoItem", item.CategoriaDoItem);
            cmd.Parameters.AddWithValue("@TamanhoCorDoItem", item.TamanhoCorDoItem);
            cmd.Parameters.AddWithValue("@ObservacaoDoItem", item.ObservacaoDoItem ?? "");

            cmd.Parameters.AddWithValue("@PrecoSugeridoDoItem", item.PrecoSugeridoDoItem);
            cmd.Parameters.AddWithValue("@PrecoVendaDoItem", item.PrecoVendaDoItem);

            cmd.Parameters.AddWithValue("@StatusItem", item.StatusItem);

            if (string.IsNullOrWhiteSpace(item.CodigoProdutoGerado))
                cmd.Parameters.AddWithValue("@CodigoProdutoGerado", DBNull.Value);
            else
                cmd.Parameters.AddWithValue("@CodigoProdutoGerado", item.CodigoProdutoGerado);

            cmd.Parameters.AddWithValue("@UltimaAtualizacao", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));

            cmd.ExecuteNonQuery();
        }

        // ============================================================
        // EXCLUIR ITEM
        //
        // Remove um item do lote pelo Id.
        // ============================================================
        public void ExcluirItem(int id)
        {
            using var conn = Conexao.GetConnection();
            conn.Open();

            string sql = "DELETE FROM ItemLote WHERE Id = @Id";

            using var cmd = new SqliteCommand(sql, conn);
            cmd.Parameters.AddWithValue("@Id", id);
            cmd.ExecuteNonQuery();
        }

        // ============================================================
        // SALVAR ITEM
        //
        // Encapsula a lógica de inserir ou atualizar.
        // ============================================================
        public void SalvarItem(ItemLote item)
        {
            if (item.Id == 0)
                AdicionarItem(item);
            else
                AtualizarItem(item);
        }

        // =====================================================================
        // MAPEAR SQLITE → OBJETO ItemLote
        //
        // Converte um registro do banco em um objeto ItemLote.
        // =====================================================================
        private ItemLote Mapear(SqliteDataReader reader)
        {
            return new ItemLote
            {
                Id = reader.GetInt32(0),
                CodigoLoteRecebimento = NormalizarCodigo(reader.GetString(1)),
                CodigoParceiro = NormalizarCodigo(reader.GetString(2)),

                NomeDoItem = reader.GetString(3),
                MarcaDoItem = reader.GetString(4),
                CategoriaDoItem = reader.GetString(5),
                TamanhoCorDoItem = reader.GetString(6),

                ObservacaoDoItem = reader.IsDBNull(7) ? "" : reader.GetString(7),

                PrecoSugeridoDoItem = reader.GetDouble(8),
                PrecoVendaDoItem = reader.GetDouble(9),

                StatusItem = reader.GetString(10),
                CodigoProdutoGerado = reader.IsDBNull(11) ? null : reader.GetString(11),

                DataCriacao = Convert.ToDateTime(reader["DataCriacao"]),
                UltimaAtualizacao = Convert.ToDateTime(reader["UltimaAtualizacao"])
            };
        }
    }
}
