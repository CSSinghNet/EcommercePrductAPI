using ECommerce.Repository.Implementations;
using ECommerce.Repository.Interface;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerce.Repository
{
    public static class IocConfig
    {
        public static void ConfigureServices(ref IServiceCollection services)
        {
            services.AddScoped<IProductRepository, ProductRepository>();
        }
    }
}
