//// See https://aka.ms/new-console-template for more information
//Console.WriteLine("Hello, World!");


using ChannelEngine.BusinessService;
using ChannelEngine.BusinessService.Interface;
using ChannelEngine.ServiceManager;
using ChannelEngine.ServiceManager.Interface;
using ChannelEngine.Shared.Entity;
using ChannelEngine.Shared.Enumerations;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting; 

class Program
{
    public static IConfigurationRoot configuration;
    static void Main(string[] args)
    {
        var host = CreateHostBuilder(args).Build();
        var orderService = host.Services.GetService<IOrderService>();
        orderService.GetAllOrdersByStatus(OrderStatusEnum.IN_PROGRESS);


        CollectionOfMerchantOrderResponse response = new CollectionOfMerchantOrderResponse();

        Console.ReadLine();
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
                .AddSingleton<IOrderService, OrderService>()
                .AddSingleton<IProductService, ProductService>()
                .AddSingleton<IOrderAPI, OrderAPI>()
                .AddSingleton<IProductAPI, ProductAPI>();

            })
            .ConfigureAppConfiguration(app =>
            {
                app.AddJsonFile("appsettings.json");
            });

        return hostBuilder;
    }



    private static ServiceProvider SetupDI()
    {
        
        var serviceProvider = new ServiceCollection()
            .AddSingleton<IOrderService, OrderService>()
            .AddSingleton<IOrderAPI, OrderAPI>()
            .BuildServiceProvider();

        configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetParent(AppContext.BaseDirectory).FullName)
            .AddJsonFile("appsettings.json", false)
            .Build();

        // Add access to generic IConfigurationRoot
        //  serviceProvider.AddSingleton<IConfigurationRoot>(configuration);

        return serviceProvider;
    }

    private static void ConfigureServices(IServiceCollection services)
    {
        //services
        //    .AddSingleton<ITest, Test>();
    }
}