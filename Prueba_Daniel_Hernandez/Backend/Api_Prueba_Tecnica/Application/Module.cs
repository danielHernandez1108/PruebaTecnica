using Application.Services;
using Autofac;
using Dominio.Interfaces;

namespace Application
{
    public class Module : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<LoginService>().AsSelf().InstancePerLifetimeScope();
            builder.RegisterType<GenericService>().AsSelf().InstancePerLifetimeScope();
            builder.RegisterType<OrderService>().AsSelf().InstancePerLifetimeScope();
        }
    }
}
