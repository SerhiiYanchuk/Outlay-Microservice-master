using CardMicroservice.DBContexts;
using CardMicroservice.Handlers;
using CardMicroservice.Models;
using CardMicroservice.UoW;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CardMicroservice
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            //services.AddSingleton<IHostedService, KafkaConsumerHandler>();
            // services.AddEntityFrameworkSqlServer().AddDbContext<MyDbContext>(x => x.UseSqlServer(Configuration.GetConnectionString("OutlayDB")));

            //services.AddDbContext<MyDbContext>(options =>
            //{
            //    options.UseSqlServer(Configuration.GetConnectionString("OutlayDB"));
            //});

            var server = Configuration["DBServer"] ?? "ms-sql-server";
            var port = Configuration["DBPort"] ?? "1433";
            //var port = Configuration["DBPort"] ?? "8080";
            var user = Configuration["DBUser"] ?? "SA";
            var password = Configuration["DBPassword"] ?? "Pa55w0rd2019";
            var database = Configuration["Database"] ?? "Outlays";

            services.AddDbContext<MyDbContext>(options =>
                options.UseSqlServer($"Server={server},{port};Initial Catalog={database};User ID = {user}; Password={password}")
            );

            services.AddTransient<IUnitOfWork, UnitOfWork>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            //using (var serviceScope = app.ApplicationServices.CreateScope())
            //{
            //    var context = serviceScope.ServiceProvider.GetService<MyDbContext>();

            //    DbInitializer.Seed(context);
            //}

            PrepDB.PrepPopulation(app);

        }
    }
}
