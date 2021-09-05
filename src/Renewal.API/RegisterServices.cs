using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Renewal.API.Extensions.HealthCheck;
using Renewal.Application.Common;
using Renewal.Application.Common.Logging;
using Renewal.Application.Models;
using Renewal.Infrastructure;
using System;
using System.Reflection;

namespace Renewal.API
{
    public static class RegisterServices
    {

        public static void AddProjectModules(this IServiceCollection services, IConfiguration config, IWebHostEnvironment env)
        {
            var connectionString = env.IsDevelopment()
                    ? config[Constants.ConnectionConfig.ConnectionString]
                    : config[config[Constants.ConnectionConfig.ConnectionString]];

            services.AddDbContext<RenewalDbContext>(options =>
            {
                options.UseSqlServer(connectionString,
                    sqlServerOptionsAction: sqlOptions =>
                    {
                        sqlOptions.MigrationsAssembly(typeof(RenewalDbContext).GetTypeInfo().Assembly.GetName().Name);
                        sqlOptions.EnableRetryOnFailure(maxRetryCount: 15, maxRetryDelay: TimeSpan.FromSeconds(30), errorNumbersToAdd: null);
                    });
            },
                ServiceLifetime.Scoped  //Showing explicitly that the DbContext is shared across the HTTP request scope (graph of objects started in the HTTP request)
            );

            if (string.IsNullOrEmpty(config[Constants.HeaderInformation.IntegrationTestKey]))
            {
                services.AddHealthChecks().AddSqlServer(env.IsDevelopment()
                    ? config[Constants.ConnectionConfig.ConnectionString]
                    : config[config[Constants.ConnectionConfig.ConnectionString]], null, "sql server");
            }

            services.AddHealthChecks().AddCheck<IdentityServerHealthCheck>("Identity server");
            services.AddScoped<ITenantRequestModel, TenantRequestModel>();
            services.AddScoped<ICustomLogEnricher, CustomLogEnricher>();
            services.AddHttpContextAccessor();
            services.AddSingleton<IActionContextAccessor, ActionContextAccessor>();
            services.AddAppSettingsConfiguration(config);
        }

        public static void AddApiVersioning(this IServiceCollection services)
        {
            services.AddApiVersioning(
                options =>
                {
                    // reporting api versions will return the headers "api-supported-versions" and "api-deprecated-versions"
                    options.ReportApiVersions = true;
                });

            services.AddVersionedApiExplorer(
                options =>
                {
                    // add the versioned api explorer, which also adds IApiVersionDescriptionProvider service
                    // note: the specified format code will format the version as "'v'major[.minor][-status]"
                    options.GroupNameFormat = "'v'VVV";

                    // note: this option is only necessary when versioning by url segment. the SubstitutionFormat
                    // can also be used to control the format of the API version in route templates
                    options.SubstituteApiVersionInUrl = true;
                });
        }

        private static void AddAppSettingsConfiguration(this IServiceCollection services, Microsoft.Extensions.Configuration.IConfiguration config)
        {
            services.Configure<AppSettingsConfiguration>(config);
        }

    }
}
