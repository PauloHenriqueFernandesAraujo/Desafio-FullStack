using DesafioFULL.modules.debts.model;
using DesafioFULL.modules.debts.viewModel;
using DesafioFULL.tools.mongoConnection.service;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DesafioFULL.modules.debts.service
{
	public interface IDebtsService : IMongoGenericService<Debts>
	{
		Task<List<TableDebtsViewModel>> GetTable();
	}
}