using Autofac;
using Dominio.Interfaces;
using Infraestructure.ConnectionBd;
using Infraestructure.Repositorys;

namespace Infraestructure
{
    public class Module : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<LoginRepository>().As<IloginRepository>().SingleInstance();
            builder.RegisterType<GenericRepository>().As<IGenericRepository>().SingleInstance();
            builder.RegisterType<OrdersRepository>().As<IOrdersRepository>().SingleInstance();
            builder.RegisterType<DapperContext>().AsSelf().InstancePerLifetimeScope();

        }
    }
}
