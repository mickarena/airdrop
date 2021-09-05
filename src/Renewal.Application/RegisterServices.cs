using FluentValidation;
using System.Reflection;
using Microsoft.Extensions.DependencyInjection;
using AutoMapper;
using Renewal.Application.ExtensionService.IService;
using Renewal.Application.ExtensionService.Service;
using Renewal.Application.Mappings.ProcessingData;
using Renewal.Application.Services;

namespace Renewal.Application
{
    public static class RegisterServices
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddAutoMapper(cfg =>
            {
                cfg.AddProfile(new ProcessingDataMapperProfile());

            }, Assembly.GetExecutingAssembly());
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
            services.AddScoped<IPingService, HttpClientPingService>();
            services.AddScoped<IResourceDataService, ResourceDataService>();
            services.AddScoped<IPaymentService, PaymentService>();
            services.AddHttpClient();
            return services;
        }
    }
}
