using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation.AspNetCore;
using kr.bbon.AspNetCore;
using kr.bbon.AspNetCore.Filters;
using kr.bbon.AspNetCore.Options;

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using SimpleAccountBook.App.Infrastructure.Errors;
using SimpleAccountBook.Data;
using SimpleAccountBook.Domains;

namespace SimpleAccountBook.App
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
            var defaultConnectionString = Configuration.GetConnectionString("Default");

            services.AddDependencies();

            services.AddDbContext<ApplicationDbContext>(options =>
            {
                options.UseSqlServer(defaultConnectionString, sqlServerOptions =>
                {
                    sqlServerOptions.MigrationsAssembly($"{typeof(ApplicationDbContext).Namespace}.SqlServer");
                })
                .EnableDetailedErrors()
                .EnableSensitiveDataLogging();
            });

            services.AddDomainServices();
            services.AddAutoMapper(this.GetType().Assembly);

            var defaultApiVersion = new ApiVersion(1, 0);

            services.Configure<AppOptions>(Configuration.GetSection(AppOptions.Name));

            services.AddCors();
            services
                .AddControllers(configure => {
                    configure.Filters.Add<ApiExceptionHandlerFilter>();
                    
                })                
                .AddJsonOptions(opt =>
                {
                    opt.JsonSerializerOptions.IgnoreNullValues = true;
                })
                .AddFluentValidation(config =>
                {
                    config.RegisterValidatorsFromAssembly(typeof(DomainsPlaceHolder).Assembly);
                });

            services.AddApiVersioningAndSwaggerGen(defaultApiVersion);

            services.AddAutoMapperProfiles();
            services.AddMediator();
            services.AddFluentValidation();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddSerilogLogging();
            //app.UseMiddleware<ErrorHandlingMiddleware>();

            app.UseDatabaseMigrations(false, true);
            app.UseCors(builder =>
            builder
             .AllowAnyOrigin()
             .AllowAnyHeader()
             .AllowAnyMethod());

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwaggerUIWithApiVersioning();
            }        

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
