using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Renewal.Application.Common;
using Renewal.Application.DatabaseServices.Interfaces;
using Renewal.Domain.Repositories;
using Renewal.Infrastructure.DatabaseServices;
using Renewal.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace Renewal.Infrastructure
{
    public static class RegisterServices
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            services.AddTransient<IClientDataService, ClientDataService>();
            services.AddTransient<IProcessingDataService, ProcessingDataService>();
            services.AddTransient<IOnlineRenewalsStatusService, OnlineRenewalsStatusService>();
            services.AddTransient<IPolicyService, PolicyService>();

            services.AddTransient<IClientRepository, ClientRepository>();
            services.AddTransient<IProcessingDataRepository, ProcessingDataRepository>();
            services.AddTransient<IRenewalInvitesRepository, RenewalInvitesRepository>();
            services.AddTransient<IOnlineRenewalsStatusRepository, OnlineRenewalsStatusRepository>();

            return services;
        }
    }
}
