using Autofac;
using PruebaParqueaderoCore.Interfaces;
using PruebaParqueaderoCore.Servicios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaParqueaderoCore
{
    public class DefaultCoreModule:Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<VehiculoService>().As<IVehiculoService>().InstancePerLifetimeScope();
            builder.RegisterType<SupermercadoService>().As<ISupermercadoService>().InstancePerLifetimeScope();
            builder.RegisterType<TipoVehiculoService>().As<ITipoVehiculoService>().InstancePerLifetimeScope();
        }
    }
}
