using System;
using System.Collections.Generic;
using Microsoft.Data.Sqlite;
using BrechoApp.Models;

namespace BrechoApp.Data
{
    public class MovimentacaoFinanceiraRepository
    {
        private readonly string _connectionString = DatabaseConfig.ConnectionString;

        // ============================================================
        // LISTAR MOVIMENTAÇÕES POR PERÍODO
        // ============================================================
        public List<MovimentacaoFinanceira> Listar(DateTime inicio, DateTime fim)
        {
            var lista = new List<MovimentacaoFinanceira>();

            using (var conn = new SqliteConnection(_connectionString))
            {
                conn.Open();

                var cmd = conn.CreateCommand();
                cmd.CommandText =
                @"SELECT * FROM MovimentacoesFinanceiras
                  WHERE date(Data) BETWEEN date($inicio) AND date($fim)
                  ORDER BY Data DESC";

                cmd.Parameters.AddWithValue("$inicio", inicio);
                cmd.Parameters.AddWithValue("$fim", fim);

                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        lista.Add(new MovimentacaoFinanceira
                        {
                            IdMovimentacao = reader.GetInt32(0),
                            Data = reader.GetDateTime(1),
                            Tipo = reader.GetString(2),
                            Valor = reader.GetDecimal(3),
                            IdCentroOrigem = reader.IsDBNull(4) ? null : reader.GetInt32(4),
                            IdCentroDestino = reader.IsDBNull(5) ? null : reader.GetInt32(5),
                            Categoria = reader.IsDBNull(6) ? "" : reader.GetString(6),
                            Descricao = reader.IsDBNull(7) ? "" : reader.GetString(7),
                            IdVenda = reader.IsDBNull(8) ? null : reader.GetInt32(8),
                            IdParceiro = reader.IsDBNull(9) ? null : reader.GetString(9),
                            Previsto = reader.GetBoolean(10)
                        });
                    }
                }
            }

            return lista;
        }

        // ============================================================
        // INSERIR MOVIMENTAÇÃO + ATUALIZAR SALDOS
        // ============================================================
        public void Inserir(MovimentacaoFinanceira m)
        {
            using (var conn = new SqliteConnection(_connectionString))
            {
                conn.Open();

                var cmd = conn.CreateCommand();
                cmd.CommandText =
                @"INSERT INTO MovimentacoesFinanceiras
                  (Data, Tipo, Valor, IdCentroOrigem, IdCentroDestino, Categoria, Descricao, IdVenda, IdParceiro, Previsto)
                  VALUES ($data, $tipo, $valor, $origem, $destino, $categoria, $descricao, $idVenda, $idParceiro, $previsto)";

                cmd.Parameters.AddWithValue("$data", m.Data);
                cmd.Parameters.AddWithValue("$tipo", m.Tipo);
                cmd.Parameters.AddWithValue("$valor", m.Valor);
                cmd.Parameters.AddWithValue("$origem", (object)m.IdCentroOrigem ?? DBNull.Value);
                cmd.Parameters.AddWithValue("$destino", (object)m.IdCentroDestino ?? DBNull.Value);
                cmd.Parameters.AddWithValue("$categoria", m.Categoria);
                cmd.Parameters.AddWithValue("$descricao", m.Descricao);
                cmd.Parameters.AddWithValue("$idVenda", (object)m.IdVenda ?? DBNull.Value);
                cmd.Parameters.AddWithValue("$idParceiro", (object)m.IdParceiro ?? DBNull.Value);
                cmd.Parameters.AddWithValue("$previsto", m.Previsto);

                cmd.ExecuteNonQuery();
            }

            // ============================================================
            // ATUALIZAR SALDOS AUTOMATICAMENTE
            // ============================================================
            var repoCentros = new CentroFinanceiroRepository();

            if (m.Tipo == "Entrada")
            {
                repoCentros.SomarSaldo(m.IdCentroDestino.Value, m.Valor);
            }
            else if (m.Tipo == "Saida")
            {
                repoCentros.SubtrairSaldo(m.IdCentroOrigem.Value, m.Valor);
            }
            else if (m.Tipo == "Transferencia")
            {
                repoCentros.SubtrairSaldo(m.IdCentroOrigem.Value, m.Valor);
                repoCentros.SomarSaldo(m.IdCentroDestino.Value, m.Valor);
            }
        }
    }
}