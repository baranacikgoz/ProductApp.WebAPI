using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ProductApp.Application.Interfaces.Repositories;
using ProductApp.Persistence.Context;
using ProductApp.Persistence.RepositoryImpl;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProductApp.Persistence
{
    public static class ServiceRegistration
    {
        public static void AddPersistenceServices(this IServiceCollection services)
        {
            services.AddDbContext<ApplicationDbContext>(opt => opt.UseInMemoryDatabase("memoryDb"));

            services.AddTransient<IProductRepositoryAsync, ProductRepositoryAsync>();
        }
    }
}
    