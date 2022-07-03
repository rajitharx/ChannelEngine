//// See https://aka.ms/new-console-template for more information
//Console.WriteLine("Hello, World!");


using ChannelEngine.BusinessService;
using ChannelEngine.BusinessService.Interface;
using ChannelEngine.ServiceManager;
using ChannelEngine.ServiceManager.Interface;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

class Program
{
    static void Main(string[] args)
    {
        //var host = CreateHostBuilder(args).Build();
        //int value = host.Services.GetService<IOrderService>().GetOrderByID(123);

        var test = SetupDI();

        var orderService = test.GetService<IOrderService>();
        int value = orderService.GetOrderByID(123);
    }

    private static IHostBuilder CreateHostBuilder(string[] args)
    {
        var hostBuilder = Host.CreateDefaultBuilder(args)
            .ConfigureAppConfiguration((context, builder) =>
            {
                builder.SetBasePath(Directory.GetCurrentDirectory());
            })
            .ConfigureServices((context, services) =>
            {
                services.AddSingleton<IOrderService, OrderService>()
                .AddSingleton<IOrderAPI, OrderAPI>();
            });

        return hostBuilder;
    }


    private static ServiceProvider SetupDI()
    {
        var serviceProvider = new ServiceCollection()
            .AddSingleton<IOrderService, OrderService>()
            .AddSingleton<IOrderAPI, OrderAPI>()
            .BuildServiceProvider();

        return serviceProvider;
    }

    private static void ConfigureServices(IServiceCollection services)
    {
        //services
        //    .AddSingleton<ITest, Test>();
    }
}