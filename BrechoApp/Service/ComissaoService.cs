using System;
using System.Collections.Generic;
using System.Linq;
using BrechoApp.Models;
using BrechoApp.Data;
using BrechoApp.Enums;

namespace BrechoApp.Services
{
    public class ComissaoService
    {
        private readonly ComissaoPeriodoRepository _periodoRepo;
        private readonly ComissaoSaldoPNRepository _saldoRepo;
        private readonly VendaRepository _vendaRepo;
        private readonly ParceiroNegocioRepository _pnRepo;

        public ComissaoService()
        {
            _periodoRepo = new ComissaoPeriodoRepository();
            _saldoRepo = new ComissaoSaldoPNRepository();
            _vendaRepo = new VendaRepository();
            _pnRepo = new ParceiroNegocioRepository();
        }

        // ============================================================
        // FECHAR PERÍODO
        // ============================================================
        public List<ComissaoSaldoPN> FecharPeriodo(int mes, int ano)
        {
            var periodo = _periodoRepo.BuscarPeriodo(mes, ano);
            if (periodo == null)
            {
                int id = _periodoRepo.CriarPeriodo(mes, ano);
                periodo = _periodoRepo.BuscarPeriodo(mes, ano);
            }

            var vendas = BuscarVendasDoPeriodo(mes, ano);

            var comissoes = CalcularComissoes(vendas);

            var contasAReceber = CalcularContasAReceber(vendas);

            var saldos = Consolidar(periodo.IdPeriodo, comissoes, contasAReceber);

            AplicarCompensacao(saldos);

            foreach (var saldo in saldos)
                _saldoRepo.InserirSaldo(saldo);

            _periodoRepo.FecharPeriodo(periodo.IdPeriodo);

            return saldos;
        }

        // ============================================================
        // BUSCAR VENDAS DO PERÍODO
        // ============================================================
        private List<Venda> BuscarVendasDoPeriodo(int mes, int ano)
        {
            DateTime inicio = new DateTime(ano, mes, 1);
            DateTime fim = inicio.AddMonths(1).AddDays(-1);

            var vendas = _vendaRepo.ListarVendasPorPeriodo(inicio, fim);

            foreach (var venda in vendas)
            {
                venda.Itens = _vendaRepo.ListarItensPorVenda(venda.IdVenda);

                // IMPORTANTE: carregar pagamentos também
                venda.Pagamentos = _vendaRepo.ListarPagamentosPorVenda(venda.IdVenda);
            }

            return vendas;
        }

        // ============================================================
        // CALCULAR COMISSÕES POR PN
        // ============================================================
        private Dictionary<string, double> CalcularComissoes(List<Venda> vendas)
        {
            var resultado = new Dictionary<string, double>();

            foreach (var venda in vendas)
            {
                foreach (var item in venda.Itens)
                {
                    string pn = item.IdFornecedor;

                    var parceiro = _pnRepo.BuscarPorCodigo(pn);
                    if (parceiro == null)
                        continue;

                    double percentual = parceiro.PercentualComissao;
                    double comissao = item.PrecoFinalNegociado * (percentual / 100);

                    if (!resultado.ContainsKey(pn))
                        resultado[pn] = 0;

                    resultado[pn] += comissao;
                }
            }

            return resultado;
        }

        // ============================================================
        // CALCULAR CONTAS A RECEBER (FUTURO)
        // ============================================================
        private Dictionary<string, double> CalcularContasAReceber(List<Venda> vendas)
        {
            var resultado = new Dictionary<string, double>();

            var vendasFuturo = vendas
                .Where(v => v.Pagamentos.Any(p => p.Tipo == TipoPagamento.Futuro))
                .ToList();

            foreach (var venda in vendasFuturo)
            {
                foreach (var item in venda.Itens)
                {
                    string pn = item.IdFornecedor;

                    if (!resultado.ContainsKey(pn))
                        resultado[pn] = 0;

                    resultado[pn] += item.PrecoFinalNegociado;
                }
            }

            return resultado;
        }

        // ============================================================
        // CONSOLIDAR POR PN
        // ============================================================
        private List<ComissaoSaldoPN> Consolidar(
            int idPeriodo,
            Dictionary<string, double> comissoes,
            Dictionary<string, double> contasAReceber)
        {
            var saldos = new List<ComissaoSaldoPN>();

            var todosPNs = comissoes.Keys
                .Union(contasAReceber.Keys)
                .Distinct();

            foreach (var pn in todosPNs)
            {
                double valorComissao = comissoes.ContainsKey(pn) ? comissoes[pn] : 0;
                double valorFuturo = contasAReceber.ContainsKey(pn) ? contasAReceber[pn] : 0;

                var saldo = new ComissaoSaldoPN
                {
                    IdPeriodo = idPeriodo,
                    CodigoPN = pn,
                    ComissoesAPagar = valorComissao,
                    ContasAReceber = valorFuturo,
                    SaldoFinal = valorComissao - valorFuturo,
                    SaldoCompensado = valorComissao - valorFuturo,
                    Status = "Aberto"
                };

                saldos.Add(saldo);
            }

            return saldos;
        }

        // ============================================================
        // COMPENSAÇÃO AUTOMÁTICA
        // ============================================================
        private void AplicarCompensacao(List<ComissaoSaldoPN> saldos)
        {
            foreach (var saldo in saldos)
                saldo.SaldoCompensado = saldo.SaldoFinal;
        }
    }
}