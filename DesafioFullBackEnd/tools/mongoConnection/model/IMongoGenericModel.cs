using MongoDB.Bson;

namespace DesafioFULL.tools.mongoConnection.model
{
	public interface IMongoGenericModel
	{
		ObjectId _Id { get; set; }
		string Id { get; set; }
		string __v { get; set; }
	}
}