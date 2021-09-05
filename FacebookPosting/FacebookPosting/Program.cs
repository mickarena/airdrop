using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace FacebookPosting
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var webDriver = LaunchBrowser();



            var facebookAutomation = new FacebookAutomation(webDriver);
            facebookAutomation.Login("splendid.hacker.04@gmail.com", "fLethuy@341");

            var groupId = 503415990082179;
            webDriver.Url = "https://www.facebook.com/groups/967492099934375";
            facebookAutomation.Post($"This is a test. Generated on {DateTime.Now}");

            CreateHostBuilder(args).Build().Run();
        }

        static IWebDriver LaunchBrowser()
        {
            var options = new ChromeOptions();
            options.AddArgument("10000");
            options.AddArgument("20000");

            var driver = new ChromeDriver(Environment.CurrentDirectory, options);
            return driver;
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
