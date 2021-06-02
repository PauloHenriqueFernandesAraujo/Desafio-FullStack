using DesafioFULL.tools.mongoConnection.service;
using Ninject.Modules;

namespace DesafioFULL.tools.mongoConnection.injector
{
	public class MongoInjector : NinjectModule
    {
        public override void Load()
        {
            Bind(typeof(IMongoGenericService<>)).To(typeof(MongoGenericService<>));
        }
    }
}