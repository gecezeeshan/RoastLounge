﻿using Application.Common.Interfaces;
using Infrastructure.Persistence;
using Infrastructure.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;


namespace Infrastructure;
public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration){
       
        if(configuration.GetValue<bool>("UseInMemoryDatabase"))        {
                services.AddDbContext<ApplicationDbContext>(options => options.UseInMemoryDatabase("SampleDB"));
        }
        else{

                services.AddDbContext<ApplicationDbContext>(options => 
                options.UseSqlServer(
                    configuration.GetConnectionString("DefaultConnection"),
                    b =>{
                         b.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName);
                       b.EnableRetryOnFailure(5, TimeSpan.FromSeconds(10), null);}
                ));
        }

        services.AddScoped<IApplicationDbContext>(provider =>
         provider.GetService<ApplicationDbContext>()
         );
         
        services.AddTransient<IDateTime, DateTimeService>();
        return services;
    }

}
