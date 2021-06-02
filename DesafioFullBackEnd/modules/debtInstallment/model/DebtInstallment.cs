using System;
using DesafioFULL.tools.mongoConnection.model;

namespace DesafioFULL.modules.debtInstallment.model
{
	public class DebtInstallment : MongoGenericModel
	{
		public string DebtsId { get; set; }
		public int NumeroDaParcela { get; set; }
		public DateTime DataDeVencimento { get; set; }
		public float ValorDaParcela { get; set; }
	}
}