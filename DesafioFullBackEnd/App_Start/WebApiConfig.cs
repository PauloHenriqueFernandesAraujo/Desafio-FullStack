using DesafioFULL.tools.ninject;
using DesafioFULL.tools.routes;
using Ninject;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Web.Http;
using System.Web.Http.Cors;

namespace DesafioFULL
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            config.MapHttpAttributeRoutes(new CustomDirectRouteProvider());

            var cors = new EnableCorsAttribute("*", "*", "*");
            config.EnableCors(cors);

            InitNinject(config);
        }

        public static void InitNinject(HttpConfiguration config)
        {
            IKernel kernel = new StandardKernel();
            kernel.Load(LoadNinjectModules());
            config.DependencyResolver = new DependencyInjector(kernel);
        }

        public static IEnumerable<Assembly> LoadNinjectModules() { return AppDomain.CurrentDomain.GetAssemblies(); }
    }
}
