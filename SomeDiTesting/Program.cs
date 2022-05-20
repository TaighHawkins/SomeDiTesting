using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SomeDiTesting.Apis;
using SomeDiTesting.Helper;
using SomeDiTesting.PretendWorker;
using SomeDiTesting.Process;
using System;
using System.Threading.Tasks;

namespace SomeDiTesting
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var builder = Host.CreateDefaultBuilder();
            builder.ConfigureServices((_, services) =>
            {
                services.AddScoped<IApi, HappyApi>();
                services.AddScoped<IApi, SadApi>();
                services.AddScoped<IApi, MehApi>();
                services.AddScoped<Processor>();
                services.AddScoped<Supervisor>();
                services.AddScoped<LessThanEffectiveHelper>();
                services.AddSingleton<Worker>();
            });

            IHost host = builder.Build();
            Worker app = host.Services.GetRequiredService<Worker>();
            app.WorkerLoop();
            await host.RunAsync();
        }
    }
}
