using Autofac;
using MediatR;
using PruebaParqueaderoCompartido.Eventos;
using PruebaParqueaderoCompartido.Interfaces;
using PruebaParqueaderoCore.Interfaces;
using PruebaParqueaderoCore.Servicios;
using PruebaParqueaderoInfraestructura.Datos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaParqueaderoInfraestructura
{
    public class DefaultInfraestructureModule : Module
    {
        public delegate object ServiceFactory(Type serviceFactory);
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<StoredProcedureRepository>().As<IStoredProcedureRepository>().InstancePerLifetimeScope();
            builder.RegisterType<TipoVehiculoRepositorio>().As<ITipoVehiculoRepositorio>().InstancePerLifetimeScope();
            builder.RegisterType<SupermercadoRepositorio>().As<ISupermercadoRepositorio>().InstancePerLifetimeScope();

            builder.RegisterType<Mediator>().As<IMediator>().InstancePerLifetimeScope();
            builder.RegisterType<DomainEventDispatcher>().As<IDomainEventDispatcher>().InstancePerLifetimeScope();
            builder.Register<ServiceFactory>(context =>
            {
                var c = context.Resolve<IComponentContext>();
                return t => c.Resolve(t);
            });
            
        }
    }
}
