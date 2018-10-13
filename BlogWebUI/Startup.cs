using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using BlogWebUI.Dao;
using BlogWebUI.DaoImpl;
using BlogWebUI.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace BlogWebUI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public IServiceProvider ConfigureServices(IServiceCollection services)
        {


            

            //Access control allow origin'e izin vermek için(tüm sitelere izin vermek için bu şekilde yaparız,belirli sitelere izin vermek
            //içinse sadece services.AddCors() dedikten sonra Configure fonksyionunda istediğimiz siteleri tanımlarız.)
            services.AddCors(o => o.AddPolicy("policy", builder =>
            {
                builder.AllowAnyOrigin()
                .AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader();
            }));
            services.AddMvc();
            //IoC start
            var builders = new ContainerBuilder();
            builders.Populate(services);

            builders.RegisterType<DataContext>().SingleInstance();
            builders.RegisterType<CategoryDaoImpl>().As<ICategoryDao>().SingleInstance();


            var container = builders.Build();
            return new AutofacServiceProvider(container);
            //IoC end

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseCors(
                options => options.WithOrigins("*").AllowAnyMethod().AllowAnyHeader()
            );
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();
        }
    }
}
