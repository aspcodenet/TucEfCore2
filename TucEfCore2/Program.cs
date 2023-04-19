using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Hosting;
using TucEfCore2;
using TucEfCore2.Data;

var env = System.Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
if (env == null)
    env = System.Environment.GetEnvironmentVariable("DOTNET_ENVIRONMENT");

var builder = new ConfigurationBuilder()
    .SetBasePath(Directory.GetCurrentDirectory())
    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
    .AddJsonFile($"appsettings.{env}.json", optional: true)
    .AddEnvironmentVariables();

IConfiguration config = builder.Build();

var services = new ServiceCollection(); 
var connectionString = config.GetConnectionString("DefaultConnection");
    services.AddDbContext<ApplicationDbContext>(options =>
        options.UseSqlServer(connectionString));


services.AddTransient<DataInitializer>();
services.AddTransient<App>();
services.AddTransient<AdoNetApp>();

var serviceProvider = services.BuildServiceProvider(true);

using (var scope = serviceProvider.CreateScope())
{
    //var dataInitializer = scope.ServiceProvider.GetService<DataInitializer>();
    //dataInitializer.SeedData();
    //var app = scope.ServiceProvider.GetService<App>();
    if (Assembly.GetEntryAssembly() == Assembly.GetExecutingAssembly())
    {
        scope.ServiceProvider.GetService<AdoNetApp>().Run();
        //scope.ServiceProvider.GetService<App>().Run();
    }
}

