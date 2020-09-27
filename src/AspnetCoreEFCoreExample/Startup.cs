using System.Reflection;
using AspnetCoreEFCoreExample.Automapper;
using AspnetCoreEFCoreExample.DTO;
using AspnetCoreEFCoreExample.Mapping;
using AspnetCoreEFCoreExample.Models;
using AspnetCoreEFCoreExample.Repositories;
using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace AspnetCoreEFCoreExample
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; set; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            var configurationSection = Configuration.GetSection("ConnectionStrings:DefaultConnection");
            services.AddDbContext<DataBaseContext>(options => options.UseSqlServer(configurationSection.Value));
            // Add framework services.
            services.AddAutoMapper(typeof(AutoMapperProfile).GetTypeInfo().Assembly);

            services.AddMvc();
            services.AddScoped<IExampleRepository, ExampleRepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            //AutoMapper.Mapper.Initialize(cfg =>
            //{
            //    cfg.CreateMap<Element, ElementSimpleDto>();
            //    cfg.CreateMap(typeof(Element), typeof(ElementDto<>));
            //    //.ForMember("User", t => t.MapFrom("User"));
            //    cfg.CreateMap<User, UserBasicInfosDto>();
            //    cfg.CreateMap<User, UserMainInfosDto>();
            //    cfg.CreateMap<Category, CategoryMainInfosDto>();
            //    cfg.CreateMap<Category, CategoryBasicInfosDto>();
            //});

            //loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            //loggerFactory.AddDebug();

            //app.UseDefaultFiles();
            //app.UseStaticFiles();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseStaticFiles();
            app.UseRouting();
            app.UseCors();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute("default", "{controller=Home}/{action=Index}");
            });
            //app.UseMvc();
        }
    }
}
