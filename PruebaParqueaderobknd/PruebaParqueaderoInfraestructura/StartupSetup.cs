using Autofac.Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.DependencyInjection;
using PruebaParqueaderoInfraestructura.Datos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace PruebaParqueaderoInfraestructura
{
    public static class StartupSetup
    {
        public static void AddDbContext(this IServiceCollection  services)
        {
         
            services.AddDbContext<ParqueaderoDbContext>((sp, options) =>
            {
                options.UseSqlServer("Data Source=LILIANAVARELA\\SQLEXPRESS;Initial Catalog=PruebaParqueadero;Integrated Security=True;TrustServerCertificate=True;");
            });
        }
        
    }
}
