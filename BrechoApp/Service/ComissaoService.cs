using System;
using System.Collections.Generic;
using System.Linq;
using BrechoApp.Models;
using BrechoApp.Data;

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
            // 1) Abrir ou criar período
            var periodo = _periodoRepo.BuscarPeriodo(mes, ano);
            if (periodo == null)
            {
                int id = _periodoRepo.CriarPeriodo(mes, ano);
                periodo = _periodoRepo.BuscarPeriodo(mes, ano);
            }

            // 2) Buscar vendas do período
            var vendas = BuscarVendasDoPeriodo(mes, ano);

            // 3) Calcular comissões por PN
            var comissoes = CalcularComissoes(vendas);

            // 4) Calcular contas a receber (Futuro)
            var contasAReceber = CalcularContasAReceber(vendas);

            // 5) Consolidar por PN
            var saldos = Consolidar(periodo.IdPeriodo, comissoes, contasAReceber);

            // 6) Aplicar compensação automática
            AplicarCompensacao(saldos);

            // 7) Gravar no banco
            foreach (var saldo in saldos)
                _saldoRepo.InserirSaldo(saldo);

            // 8) Fechar período
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

            // Usa o método REAL do seu repositório
            var vendas = _vendaRepo.ListarVendasPorPeriodo(inicio, fim);

            // Carregar itens de cada venda
            foreach (var venda in vendas)
                venda.Itens = _vendaRepo.ListarItensPorVenda(venda.IdVenda);

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
                .Where(v => v.FormaPagamento.Trim().ToLower() == "futuro")
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
            {
                saldo.SaldoCompensado = saldo.SaldoFinal;
            }
        }
    }
}