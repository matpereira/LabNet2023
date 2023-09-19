using Lab.EF.Entities;
using Lab.EF.Logic.DTO;
using Lab.EF.Logic;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Lab.EF.MVC.Controllers;
using Lab.EF.MVC;

[assembly: PreApplicationStartMethod(typeof(MvcApplication), "InitModule")]


namespace Lab.EF.MVC
{
    public class MvcApplication : System.Web.HttpApplication
    {
        public static void InitModule()
        {
            RegisterModule(typeof(ServiceScopeModule));
        }
    
        protected void Application_Start()
            {
                var services = new ServiceCollection();
                ConfigureServices(services);
                ServiceScopeModule.SetServiceProvider(services.BuildServiceProvider());
                AreaRegistration.RegisterAllAreas();
                FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
                RouteConfig.RegisterRoutes(RouteTable.Routes);
                BundleConfig.RegisterBundles(BundleTable.Bundles);
                DependencyResolver.SetResolver(new ServiceProviderDependencyResolver());
            }

        private void ConfigureServices(IServiceCollection services)
        {
            //Intente que sea .AddSingleton pero no me funciono porque se rompia el context
            services.AddScoped<IShippersLogic, ShippersLogic>();
            services.AddTransient<ShippersController>();
            services.AddScoped<ICustomersLogic, CustomersLogic>();
            services.AddTransient<CustomersController>();
        }
    }

    internal class ServiceScopeModule : IHttpModule
    {
        private static ServiceProvider _serviceProvider;

        public void Dispose()
        {

        }

        public void Init(HttpApplication context)
        {
            context.BeginRequest += Context_BeginRequest;
            context.EndRequest += Context_EndRequest;
        }

        private void Context_EndRequest(object sender, EventArgs e)
        {
            var context = ((HttpApplication)sender).Context;
            if (context.Items[typeof(IServiceScope)] is IServiceScope scope)
            {
                scope.Dispose();
            }
        }

        private void Context_BeginRequest(object sender, EventArgs e)
        {
            var context = ((HttpApplication)sender).Context;
            context.Items[typeof(IServiceScope)] = _serviceProvider.CreateScope();
        }

        public static void SetServiceProvider(ServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }
    }

    internal class ServiceProviderDependencyResolver : IDependencyResolver
    {
        public object GetService(Type serviceType)
        {
            if (HttpContext.Current?.Items[typeof(IServiceScope)] is IServiceScope scope)
            {
                return scope.ServiceProvider.GetService(serviceType);
            }

            throw new InvalidOperationException("IServiceScope not provided");
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            if (HttpContext.Current?.Items[typeof(IServiceScope)] is IServiceScope scope)
            {
                return scope.ServiceProvider.GetServices(serviceType);
            }

            throw new InvalidOperationException("IServiceScope not provided");
        }
    }
}
