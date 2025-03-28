using System;
using System.Diagnostics.CodeAnalysis;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration.Json;

namespace Atlantic.Api
{
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
    [ExcludeFromCodeCoverage]
    public static class Program
    {
        public static void Main(string[] args)
        {
            BuildWebHost(args).Run();
        }

        public static IWebHost BuildWebHost(string[] args)
        {
            var webHost = WebHost.CreateDefaultBuilder(args)
                                .ConfigureAppConfiguration(x =>
                                {
                                    var environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
                                    x.Sources.Clear();
                                    x.Sources.Add(new JsonConfigurationSource()
                                    {
                                        Path = !string.IsNullOrWhiteSpace(environment) ? $"appsettings.{environment}.json" : "appsettings.json",
                                        ReloadOnChange = true
                                    });
                                })
                                .UseStartup<Startup>()
                                .UseKestrel()
                                .Build();

            
            return webHost;
        }
    }
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
}
