using Application;
using Infrastructure;
using Serilog;
var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

// builder.Services.AddCors(o =>
// {
//     o.AddPolicy("DevCorsPolicy", b => b.WithOrigins("http://localhost:4200").AllowAnyMethod().AllowAnyHeader().AllowCredentials());
// });
/*
builder.Services.AddApplication();
builder.Services.AddInfrastructureServices(builder.Configuration);
builder.Services.AddHttpContextAccessor();

builder.Services.AddControllers();

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo { Title = "WebAPI", Version = "v1", });
});



// if (env.IsDevelopment())
// {
    //app.UseDeveloperExceptionPage();
   // app.UseCors("DevCorsPolicy");
    //app.UseMigrationsEndPiont();
    //app.UseSwagger();
   // app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "WebAPI v1"));
// }
// else
// {
//     app.UseExceptionHandler("/Error");
//     app.UseHsts();
// }

// app.UseSerilogRequestLogging();
// app.UseStaticFiles();
// app.UseRouting();
//app.UseEndpoints(e => { e.MapControllers(); });
*/
app.MapGet("/", () => "Hello World!");
app.Run();