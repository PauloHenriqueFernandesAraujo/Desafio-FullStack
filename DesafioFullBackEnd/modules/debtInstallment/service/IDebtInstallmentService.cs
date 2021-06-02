using DesafioFULL.modules.debtInstallment.model;
using DesafioFULL.tools.mongoConnection.service;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DesafioFULL.modules.debtInstallment.service
{
	public interface IDebtInstallmentService : IMongoGenericService<DebtInstallment>
	{
		Task<List<DebtInstallment>> GetTable(string id);
	}
}