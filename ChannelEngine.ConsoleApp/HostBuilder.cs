using ChannelEngine.BusinessService;
using ChannelEngine.BusinessService.Interface;
using ChannelEngine.ServiceManager;
using ChannelEngine.ServiceManager.Interface;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace ChannelEngine.ConsoleApp
{
    internal static class HostBuilder
    {
        /// <summary>
        /// CreateHostBuilder
        /// </summary>
        /// <param name="args">Console arguments</param>
        /// <returns>IHostBuilder response</returns>
        public static IHostBuilder CreateHostBuilder(string[] args)
        {
            var hostBuilder = Host.CreateDefaultBuilder(args)
                .ConfigureAppConfiguration((context, builder) =>
                {
                    builder.SetBasePath(Directory.GetCurrentDirectory());
                })
                .ConfigureServices((context, services) =>
                {
                    services.AddSingleton<IOrderService, OrderService>()
                    .AddSingleton<IOrderService, OrderService>()
                    .AddSingleton<IProductService, ProductService>()
                    .AddSingleton<IOrderAPI, OrderAPI>()
                    .AddSingleton<IInProgressService, InProgressService>()
                    .AddSingleton<IProductAPI, ProductAPI>();

                })
                .ConfigureAppConfiguration(app =>
                {
                    app.AddJsonFile("appsettings.json");
                });

            return hostBuilder;
        }
    }
}
