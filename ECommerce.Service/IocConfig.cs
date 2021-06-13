using ECommerce.Service.Implementations;
using ECommerce.Service.Interface;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerce.Service
{
    public static class IocConfig
    {
        public static void ConfigureServices(ref IServiceCollection services)
        {
            services.AddScoped<IProductService, ProductService>();
        }
    }
}
