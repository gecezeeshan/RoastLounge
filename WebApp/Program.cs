using Microsoft.Extensions.Configuration;
using Serilog;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.DependencyInjection;
using Infrastructure.Persistence;


namespace WeebAPI
{
    public class Program
    {
        public async static Task Main(string[] args){
            var configuration = new ConfigurationBuilder().AddJsonFile("appsetting.json").Build();
            Log.Logger = new LoggerConfiguration().ReadFrom.Configuration(configuration).CreateLogger();

            Log.Information("Application starting up!");

            var host = CreateHostBuilder(args).Build();
            using (var scope = host.Services.CreateScope()){
                    var services = scope.ServiceProvider;
                try
                {
                    var context = services.GetRequiredService<ApplicationDbContext>();
                    if(context.Database.IsSqlServer())
                    {}
                }
                catch (System.Exception ex)
                {
                    
                    
                }

            }

        }

        public static IHostBuilder CreateHostBuilder(string[] args) => 
        Host.CreateDefaultBuilder(args).UseSerilog().ConfigureWebHostDefaults(webBuilder => {webBuilder.UseStartup<Startup>();
        
        } );

    }
    
}