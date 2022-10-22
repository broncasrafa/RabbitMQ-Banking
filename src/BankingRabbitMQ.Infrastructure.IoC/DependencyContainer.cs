using Microsoft.Extensions.DependencyInjection;
using BankingRabbitMQ.Core.Domain.Bus;
using BankingRabbitMQ.Infrastructure.Bus;
using BankingRabbitMQ.Service.Banking.Application.Services;
using BankingRabbitMQ.Service.Banking.Application.Interfaces;
using BankingRabbitMQ.Service.Banking.Domain.Interfaces;
using BankingRabbitMQ.Service.Banking.Data.Repository;
using BankingRabbitMQ.Service.Banking.Data.Context;
using MediatR;

namespace BankingRabbitMQ.Infrastructure.IoC
{
    public class DependencyContainer
    {
        public static void RegisterServices(IServiceCollection services)
        {
            //Domain Bus
            services.AddSingleton<IEventBus, RabbitMQBus>(sp =>
            {
                var scopeFactory = sp.GetRequiredService<IServiceScopeFactory>();
                return new RabbitMQBus(sp.GetService<IMediator>(), scopeFactory);
            });

            //Application Services
            services.AddTransient<IAccountService, AccountService>();

            //Persistence
            services.AddTransient<IAccountRepository, AccountRepository>();
            services.AddTransient<BankingDbContext>();
        }
    }
}