using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using TronScan.Options;

namespace TronScan
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            IHostBuilder builder = Host.CreateDefaultBuilder(args)
                .ConfigureAppConfiguration(config =>
                {
                    config.AddJsonFile("appsettings.json");
                })
                .ConfigureServices((context, services) =>
                {
                    services.Configure<TronScanApiOptions>(context.Configuration
                        .GetSection(TronScanApiOptions.TronScanApi));
                    services.AddSingleton<HttpClient>();
                    services.AddSingleton<ITronScan, TronScan>();
                    services.AddSingleton<Worker>();
                });

            var app = builder.Build();
            await app.Services.GetRequiredService<Worker>().Run();
        }
    }
}
