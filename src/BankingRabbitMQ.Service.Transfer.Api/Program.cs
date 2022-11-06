using Microsoft.EntityFrameworkCore;
using BankingRabbitMQ.Infrastructure.IoC;
using BankingRabbitMQ.Service.Transfer.Api.Extensions;
using BankingRabbitMQ.Service.Transfer.Data.Context;
using MediatR;


namespace BankingRabbitMQ.Service.Transfer.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            IConfiguration configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{Environments.Development}.json", optional: true, reloadOnChange: true)
                .AddEnvironmentVariables()
                .Build();

            #region [ Services: Add services to the container ]
            // Add services to the container.
            builder.Services.AddDbContext<TransferDbContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("TransferDbConnection"));
            });

            builder.Services.AddSwaggerOpenAPI();
            builder.Services.AddControllerAndJsonConfigurations();
            builder.Services.AddMediatR(typeof(Program));
            builder.Services.AddHttpContextAccessor();
            builder.Services.AddHealthChecks();
            builder.Services.AddEndpointsApiExplorer();

            RegisterServices(builder.Services);
            #endregion

            #region [ Configuration app: Configure the HTTP request pipeline ]
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseSwaggerConfigure();
            app.UseHttpsRedirection();
            app.UseAuthorization();
            app.UseHealthChecks("/health");
            app.UseStaticFiles();
            app.MapControllers();

            app.Run();
            #endregion
        }


        private static void RegisterServices(IServiceCollection services)
        {
            DependencyContainer.RegisterServices(services);
        }
    }
}