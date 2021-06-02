using DesafioFULL.modules.debtInstallment.model;
using DesafioFULL.tools.mongoConnection.service;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;

namespace DesafioFULL.modules.debtInstallment.service
{
	public class DebtInstallmentService : MongoGenericService<DebtInstallment>, IDebtInstallmentService
	{
		public async Task<List<DebtInstallment>> GetTable(string id)
		{
				return (await this.FindAll()).Where(a => a.DebtsId == id).ToList();
		}
	}
}