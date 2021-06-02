using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DesafioFULL.tools.mongoConnection.model;

namespace DesafioFULL.tools.mongoConnection.service
{
	public interface IMongoGenericService<T> : IDisposable where T  : IMongoGenericModel
	{
		Task<T> InsertAsync(T obj);
		Task <T>UpdateAsync(T obj);
		Task DeleteAsync(string id);
		Task<T> FindOne(string id);
		Task<List<T>> FindAll();
	}
}