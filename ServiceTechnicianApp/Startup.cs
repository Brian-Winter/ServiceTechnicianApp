using Autofac;
using Autofac.Integration.Mvc;
using Microsoft.Owin;
using Owin;
using Service.Contracts;
using Service.Services;
using System.Web.Mvc;

[assembly: OwinStartupAttribute(typeof(ServiceTechnicianApp.Startup))]
namespace ServiceTechnicianApp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            var builder = new ContainerBuilder();
            builder.RegisterControllers(typeof(MvcApplication).Assembly);
            // OPTIONAL: Register web abstractions like HttpContextBase.
            builder.RegisterModule<AutofacWebTypesModule>();
            builder.RegisterType<MachineService>().As<IMachineService>();
            builder.RegisterType<CustomerService>().As<ICustomerService>();
            builder.RegisterType<PartService>().As<IMachinePartService>();
            builder.RegisterType<ServiceFormService>().As<IServiceFormService>();
            // Set the dependency resolver to be Autofac.
            var container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }
    }
}
