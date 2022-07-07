using ChannelEngine.BusinessService;
using ChannelEngine.BusinessService.Interface;
using ChannelEngine.ServiceManager;
using ChannelEngine.ServiceManager.Interface;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// declare dependencies
builder.Services.AddSingleton<IOrderService, OrderService>()
                    .AddSingleton<IOrderService, OrderService>()
                    .AddSingleton<IProductService, ProductService>()
                    .AddSingleton<IOrderAPI, OrderAPI>()
                    .AddSingleton<IInProgressService, InProgressService>()
                    .AddSingleton<IProductAPI, ProductAPI>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
