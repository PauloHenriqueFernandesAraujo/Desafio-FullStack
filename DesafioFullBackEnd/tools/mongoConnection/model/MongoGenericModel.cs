using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using Newtonsoft.Json;

namespace DesafioFULL.tools.mongoConnection.model
{
    [BsonIgnoreExtraElements]
    public class MongoGenericModel : IMongoGenericModel
    {
        [BsonRepresentation(BsonType.ObjectId)]
        [BsonIgnoreIfDefault]
        [BsonId]
        public ObjectId _Id { get; set; }

        public string Id { get; set; }

        [JsonIgnore]
        public string __v { get; set; }
    }
}