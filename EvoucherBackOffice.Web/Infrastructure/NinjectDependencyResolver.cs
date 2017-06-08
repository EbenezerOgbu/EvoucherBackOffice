using EvoucherBackOffice.Services;
using EvoucherBackOffice.Web.Models;
using Ninject;
using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace EvoucherBackOffice.Web.Infrastructure
{
    public class NinjectDependencyResolver : IDependencyResolver
    {
        private IKernel kernel;
        public NinjectDependencyResolver(IKernel kernelParam)
        {
            kernel = kernelParam;
            AddBindings();
        }
        public object GetService(Type serviceType)
        {
            return kernel.TryGet(serviceType);
        }
        public IEnumerable<object> GetServices(Type serviceType)
        {
            return kernel.GetAll(serviceType);
        }
        private void AddBindings()
        {
            kernel.Bind<IAccountService>().To<AccountService>().WithConstructorArgument("baseUrl", Properties.Settings.Default.ApiUrl);
            kernel.Bind<IExperienceService>().To<ExperienceService>().WithConstructorArgument("baseUrl", Properties.Settings.Default.ApiUrl);
            kernel.Bind<IVoucherService>().To<VoucherService>().WithConstructorArgument("baseUrl", Properties.Settings.Default.VoucherUrl);
            kernel.Bind<ICart>().To<Cart>().InSingletonScope();
        }
    }
}