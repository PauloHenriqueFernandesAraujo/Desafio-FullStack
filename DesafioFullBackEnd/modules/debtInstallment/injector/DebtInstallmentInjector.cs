using DesafioFULL.modules.debtInstallment.service;
using Ninject.Modules;

namespace DesafioFULL.modules.debtInstallment.injector
{
	public class DebtInstallmentInjector : NinjectModule
    {
        public override void Load()
        {
            Bind<IDebtInstallmentService>().To<DebtInstallmentService>();
        }
    }
}