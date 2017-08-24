using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Autofac;
using Autofac.Integration.WebApi;
using Exploratory.Repository.RepoCore;
using Exploratory.Repository.Repositories;
using MongoDB.Driver;

namespace ExploratoryAPI
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            //GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            var builder = new ContainerBuilder();

            var config = GlobalConfiguration.Configuration;

            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());

            RegisterMongoProvider(builder);

            RegisterRepositories(builder);
            var container = builder.Build();
            config.DependencyResolver = new AutofacWebApiDependencyResolver(container);

        }

        private static void RegisterMongoProvider(ContainerBuilder builder)
        {
            builder.Register<IMongoProvider>(context =>
            {
                var mongoDatabase = new MongoClient("mongodb://localhost:27017").GetDatabase("explorator");
                return new MongoProvider(mongoDatabase);
            }).As<IMongoProvider>();
        }

        private static void RegisterRepositories(ContainerBuilder builder)
        {
            builder.RegisterType<ReportRepository>().As<IReportRepository>();
        }
    }
}
