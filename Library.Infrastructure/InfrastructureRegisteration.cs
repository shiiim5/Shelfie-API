using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library.Core.Interfaces;
using Library.Core.Services;
using Library.Infrastructure.Data;
using Library.Infrastructure.Repositories;
using Library.Infrastructure.Repositories.Service;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;

namespace Library.Infrastructure
{
    public static class InfrastructureRegisteration
    {

        public static IServiceCollection infrastructureRegisteration(this IServiceCollection services,IConfiguration configuration)
        {
            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddSingleton<IImageManagementService,ImageManagementService>();
            services.AddSingleton<IFileProvider>(new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot")));
         
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            services.AddDbContext<LibraryDBContext>(op=>
            op.UseSqlServer(configuration.GetConnectionString("connectionString"))
            );
            return services;
        }
    }
}
