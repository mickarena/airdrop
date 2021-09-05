using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Azure.KeyVault.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Clients.ActiveDirectory;
using Microsoft.Extensions.Logging;
using Serilog;
using System;

namespace Renewal.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            try
            {
                CreateWebHostBuilder(args).Build().Run();
            }
            catch (KeyVaultErrorException kve)
            {
                Log.Logger.Fatal(kve, "Failed to connect to Key Vault");
            }
            catch (AdalServiceException ase)
            {
                Log.Logger.Fatal(ase, "Key Vault Config error");
            }
            catch (Exception ex)
            {
                Log.Logger.Fatal(ex, "CreateWebHostBuilder failed.");
                throw;
            }
            finally
            {
                Log.CloseAndFlush();
            }
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
                .ConfigureAppConfiguration((builderContext, config) =>
                {
                    config.AddEnvironmentVariables();

                    config.AddUserSecrets<Startup>(true);

                    var configuration = config.Build();

                    Log.Logger = new LoggerConfiguration()
                        .ReadFrom.Configuration(configuration)
                        .CreateLogger();

                    config.AddAzureKeyVault(
                        configuration["AzureKeyVault:Url"],
                        configuration["AzureKeyVault:ApplicationId"],
                        configuration["AzureKeyVault:ApplicationSecret"]);
                })
                .ConfigureLogging((ctx, cfg) =>
                {
                    cfg.ClearProviders();
                })
                .UseSerilog(dispose: true);
    }
}
