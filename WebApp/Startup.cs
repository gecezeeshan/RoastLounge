using Microsoft.Extensions.Configuration;
using Serilog;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Infrastructure.Persistence;
using Application;
using Infrastructure;
using Microsoft.AspNetCore.Builder;


namespace WeebAPI
{
    public class Startup
    {
        private readonly ILogger _logger;
        private IConfiguration Configuration;
        
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
            _logger = new LoggerConfiguration().ReadFrom.Configuration(configuration).CreateLogger();
            _logger.Information("Executing startup..");
        }

        public void ConfigureServices(IServiceCollection services){
            services.AddCors(o => {
                o.AddPolicy("DevCorsPolicy", b => b.WithOrigins("http://localhost:4200").AllowAnyMethod().AllowAnyHeader().AllowCredentials());
            });

            services.AddApplication();
            services.AddInfrastructureServices(Configuration);
            services.AddHttpContextAccessor();

            // services.AddHealthChecks().AddDbContextCheck<ApplicationDbContext>()
            // .AddCheck<CustomHealthCheck>(CustomerHealthCheck.HealthCheckName);

            //services.AddDatabseDeveloperPageExceptionFilter();

            //services.AddControllers(options => 
            //{
                    //options.Filters.Add<ApiExceptionFilterAttribue>().AddFluentValidation();
            //});
            services.AddControllers();

            services.AddSwaggerGen(c => {
                c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo {Title = "WebAPI", Version="v1",});
            });

        }


        public void Configure(IApplicationBuilder app, IWebHostEnvironment env){
                if(env.IsDevelopment()){
                    app.UseDeveloperExceptionPage();
                    app.UseCors("DevCorsPolicy");
                    //app.UseMigrationsEndPiont();
                    app.UseSwagger();
                    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "WebAPI v1"));
                }
                else{
                    app.UseExceptionHandler("/Error");
                    app.UseHsts();
                }

                app.UseSerilogRequestLogging();
                app.UseRouting();
                app.UseEndpoints(e => {e.MapControllers();});



        }
    }
    
}