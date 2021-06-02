
using DesafioFULL.tools.mongoConnection.model;

namespace DesafioFULL.modules.debts.model
{
	public class Debts : MongoGenericModel
	{
		public int NumeroDotitulo { get; set; }
		public string NomeDoDevedor { get; set; }
		public string CPFDoDevedor { get; set; }
		public int Juros { get; set; }
		public int Multa { get; set; }
	}
}