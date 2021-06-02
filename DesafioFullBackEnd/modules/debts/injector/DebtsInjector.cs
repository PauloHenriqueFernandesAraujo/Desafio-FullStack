using DesafioFULL.modules.debts.service;
using Ninject.Modules;

namespace DesafioFULL.modules.debts.injector
{
    public class DebtsInjector : NinjectModule
    {
        public override void Load()
        {
            Bind<IDebtsService>().To<DebtsService>();
        }
    }
}
