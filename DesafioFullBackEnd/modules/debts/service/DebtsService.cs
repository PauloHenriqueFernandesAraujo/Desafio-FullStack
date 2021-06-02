using DesafioFULL.modules.debtInstallment.service;
using DesafioFULL.modules.debts.model;
using DesafioFULL.modules.debts.viewModel;
using DesafioFULL.tools.mongoConnection.service;
using DesafioFULL.tools.ninject;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using DesafioFULL.modules.debtInstallment.model;
using System;

namespace DesafioFULL.modules.debts.service
{
	public class DebtsService : MongoGenericService<Debts>, IDebtsService
	{
		public async Task<List<TableDebtsViewModel>> GetTable()
		{
			using (var debtInstallmentService = Factory.InstanceOf<IDebtInstallmentService>())
			{
				var list = new List<TableDebtsViewModel>();
				var allBebts = await this.FindAll();

				foreach (var debts in allBebts)
				{
					var debtInstallment = (await debtInstallmentService.FindAll()).Where(a => a.DebtsId == debts._Id.ToString()).ToList();
					list.Add(new TableDebtsViewModel()
					{
						Id = debts._Id.ToString(),
						NumeroTitulo = debts.NumeroDotitulo.ToString(),
						NomeDevedor = debts.NomeDoDevedor,
						QuantidadeParcelas = debtInstallment.Count().ToString(),
						ValorOriginal = debtInstallment.Sum(a => a.ValorDaParcela).ToString(),
						ValorAtualizado = debtInstallment.Sum(a => this.CaclValorAtualizado(debts, debtInstallment)).ToString()
					});
				}

				return list;
			}
		}

		//Sobre o valor total
		private float CaclValorAtualizado(Debts debts, List<DebtInstallment> debtInstallment)
		{
			//multa sobre o valor total como no exemplo
			float multa = float.Parse(debts.Multa.ToString()) / 100 * debtInstallment.Sum(a => a.ValorDaParcela);

			float juros = 0;
			foreach (var part in debtInstallment)
			{
				//Juros mensal sobre o valor da parcela como no exemplo
				if (part.DataDeVencimento <= DateTime.Now)
				{
					var dias = Math.Abs(part.DataDeVencimento.Subtract(DateTime.Now).Days);
					juros += (float.Parse(debts.Multa.ToString()) / 100 * part.ValorDaParcela) * (float.Parse(dias.ToString()) / 30 );
				}
			}

			return debtInstallment.Sum(a => a.ValorDaParcela) + multa + juros;
		}
	}
}