using ECommerce.EF.Contexts;
using ECommerce.Service;
using ECommerce.Service.MapperProfiles;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;


namespace ECommorceAPI
{
    public class Startup
    {
        private const string CorsPolicy = "CorsPolicy";
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            //  ConfigureCORSPolicy(ref services);
            services.AddCors(options =>
            {
                options.AddPolicy(CorsPolicy, builder =>
                {
                    builder
                    .AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader();
                });
            });
            ConfigureDbConnection(ref services, Configuration);
            ConfigureAutoMapper(ref services);

            IocConfig.ConfigureServices(ref services);
            ECommerce.Repository.IocConfig.ConfigureServices(ref services);

            services.AddControllers().AddNewtonsoftJson(o =>
            {
                o.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
            });

            ConfigureSwagger(ref services);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                // Enable middleware to serve generated Swagger as a JSON endpoint.
                app.UseSwagger();

                // specifying the Swagger JSON endpoint.
                app.UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "ECommerce API");
                });
            }
            app.UseCors(CorsPolicy);
            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
            app.UseSwagger();
        }


        public static void ConfigureDbConnection(ref IServiceCollection services, IConfiguration Configuration)
        {
            services.AddDbContext<ECommerceContext>(ctx => ctx.UseSqlServer(Configuration.GetConnectionString("EcommorceConnectionStrings")));
        }

        public static void ConfigureAutoMapper(ref IServiceCollection services)
        {
            services.AddAutoMapper(typeof(ProductProfile));
        }

        private static void ConfigureSwagger(ref IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
            {
                Title = "ECommerce API",
                Version = "v1",
            })

            );
        }
    }
}
