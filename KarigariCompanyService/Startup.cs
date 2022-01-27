using Contracts;
using Contracts.DataContracts;
using Data;
using Domain;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using NLog;
using System;
using System.IO;
using Utility.GlobalErrorHandling;
using Utility.LoggerService;

namespace KarigariCompanyService
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            LogManager.LoadConfiguration(String.Concat(Directory.GetCurrentDirectory(), "/nlog.config"));
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddSingleton<IConfiguration>(Configuration);

            //Logger Service
            services.AddSingleton<ILoggerManager, LoggerManager>();

            //Repository Contracts Registration
            services.AddScoped<ICompany, CompanyDomain>();
            services.AddScoped<IJobPost, JobPostDomain>();
            services.AddScoped<IWorkerSearch, WorkerSearchDomain>();

            //Data Contracts registration
            services.AddScoped<ICompanyData, CompanyData>();
            services.AddScoped<IJobPostData, JobPostData>();
            services.AddScoped<IWorkerSearchData, WorkerSearchData>();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "KarigariCompanyService", Version = "v1" });
            });

            services.AddCors();
            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILoggerManager logger)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "KarigariCompanyService v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            //app.UseCors(MyAllowSpecificOrigins);
            app.UseCors(x => x
               .AllowAnyOrigin()
               .AllowAnyMethod()
               .AllowAnyHeader()); // allow credentials

            app.ConfigureExceptionHandler(logger);

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
