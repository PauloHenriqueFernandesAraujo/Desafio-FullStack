using MongoDB.Driver;
using System;
using System.Linq;
using System.Configuration;
using System.Threading.Tasks;
using DesafioFULL.tools.mongoConnection.model;
using System.Collections.Generic;
using MongoDB.Bson;

namespace DesafioFULL.tools.mongoConnection.service
{
	public class MongoGenericService<T> : IMongoGenericService<T> where T : MongoGenericModel
	{
		public void Dispose() { }

		private IMongoCollection<T> _mongoCollection;

		public IMongoCollection<T> GetCollection() { return _mongoCollection; }

		public MongoGenericService() { this.InitConnection(); }

		private void InitConnection()
		{
			try
			{
				string dataBaseName = ConfigurationManager.AppSettings["mongoDataBaseName"].ToString();
				string connectionString = ConfigurationManager.AppSettings["mongoStringConnection"].ToString();

				var mongoClient = new MongoClient(new MongoUrl(connectionString));

				var dataBase = mongoClient.GetDatabase(dataBaseName);
				_mongoCollection = dataBase.GetCollection<T>(typeof(T).Name);

			} catch (Exception) { throw new Exception("Erro ao estabeler conexão com a base de dados."); }
		}

		public virtual async Task<T> InsertAsync(T obj)
		{
			await this.GetCollection().InsertOneAsync(obj);
			return obj;
		}

		public virtual async Task<T> UpdateAsync(T obj)
		{
			obj._Id = ObjectId.Parse(obj.Id);
			await this.GetCollection().ReplaceOneAsync(a => a._Id == obj._Id, obj);
			return obj;
		}

		public virtual async Task DeleteAsync(string id)
		{
			var objId = ObjectId.Parse(id);
			await this.GetCollection().DeleteOneAsync(a => a._Id == objId);
		}

		public virtual async Task<T> FindOne(string id)
		{
			var objId = ObjectId.Parse(id);
			return (await this.GetCollection().AsQueryable().ToListAsync()).Where(a => a._Id == objId).First();
		}

		public virtual async Task<List<T>> FindAll()
		{
			return await this.GetCollection().AsQueryable().ToListAsync();
		}
	}
}