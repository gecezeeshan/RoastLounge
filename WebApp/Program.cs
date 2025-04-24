using Application;
using Infrastructure;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Diagnostics.EntityFrameworkCore;


using Serilog;
using Application.Common.Interfaces;
using Infrastructure.Persistence;
using Web.Services;
using FluentValidation.AspNetCore;
var builder = WebApplication.CreateBuilder(args);


// builder.Services.AddCors(o =>
// {
//     o.AddPolicy("DevCorsPolicy", b => b.WithOrigins("http://localhost:4200").AllowAnyMethod().AllowAnyHeader().AllowCredentials());
// });



builder.Services.AddApplication();
builder.Services.AddInfrastructureServices(builder.Configuration);
builder.Services.AddControllers();
builder.Services.AddFluentValidationAutoValidation().AddFluentValidationClientsideAdapters();

builder.Services.AddHttpContextAccessor();

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo { Title = "WebAPI", Version = "v1", });
});

builder.Services.AddDbContext<ApplicationDbContext>();
builder.Services.AddScoped<ICurrentUserService,CurrentUserService>();

var app = builder.Build();

// if (env.IsDevelopment())
// {
//     app.UseDeveloperExceptionPage();
//    app.UseCors("DevCorsPolicy");
//     app.UseMigrationsEndPiont();
//     app.UseSwagger();
//    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "WebAPI v1"));
// }
// else
// {
//     app.UseExceptionHandler("/Error");
//     app.UseHsts();
// }
app.UseMigrationsEndPoint();
  app.UseDeveloperExceptionPage();
   app.UseSwagger();
   app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "WebAPI v1"));
app.UseStaticFiles();
app.UseRouting();
app.UseEndpoints(e => { e.MapControllers(); });
//app.UseSerilogRequestLogging();
app.MapGet("/", () => "Hello World!");
app.Run();