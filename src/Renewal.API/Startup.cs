using HealthChecks.UI.Client;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Renewal.API.Extensions.Swagger;
using Renewal.API.Filters;
using Renewal.Application;
using Renewal.Application.Common;
using Renewal.Application.Common.Logging;
using Renewal.Infrastructure;
using Swashbuckle.AspNetCore.Swagger;
using Swashbuckle.AspNetCore.SwaggerGen;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.Extensions.Hosting;

namespace Renewal.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration, IWebHostEnvironment env)
        {
            Configuration = configuration;
            CurrentEnvironment = env;
        }

        public IConfiguration Configuration { get; }
        private IWebHostEnvironment CurrentEnvironment { get; set; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddApiVersioning();
            services.AddApplication();
            services.AddInfrastructure();
            services.AddMvc(options => {
                options.Filters.Add(new ApiExceptionFilter());
                options.Filters.Add(typeof(HeaderFilterAttribute));
                options.Filters.Add(typeof(ModelValidatorFilterAttribute));
            })
            .AddFluentValidation(o =>
            {
                o.RegisterValidatorsFromAssemblyContaining<IModelValidator>();
                o.ImplicitlyValidateChildProperties = true;
            });

            services.AddTransient<IConfigureOptions<SwaggerGenOptions>, ConfigureSwaggerOptions>();
            services.AddSwaggerGen(c =>
            {
                //c.SwaggerDoc("v1", new OpenApiInfo { Title = "Renewal API", Version = "v1" });
                c.OperationFilter<SwaggerDefaultValues>();
                c.OperationFilter<SwaggerHeaderFilterAttribute>();
                c.AddFluentValidationRules();
                c.CustomSchemaIds(type => type.ToString());
            });
            services.AddMvc();

            services.AddProjectModules(Configuration, CurrentEnvironment);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            CustomLogEnricher.ServiceProvider = app.ApplicationServices;
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Renewal API V1");
            });
            app.UseHealthChecks(Constants.Urls.HealthCheck, new HealthCheckOptions()
            {
                Predicate = _ => true,
                ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
            });
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
