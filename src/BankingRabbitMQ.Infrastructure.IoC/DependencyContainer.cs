using Microsoft.Extensions.DependencyInjection;
using BankingRabbitMQ.Core.Domain.Bus;
using BankingRabbitMQ.Infrastructure.Bus;
using BankingRabbitMQ.Service.Banking.Application.Services;
using BankingRabbitMQ.Service.Banking.Application.Interfaces;
using BankingRabbitMQ.Service.Banking.Domain.Interfaces;
using BankingRabbitMQ.Service.Banking.Domain.CommandHandlers;
using BankingRabbitMQ.Service.Banking.Domain.Commands;
using BankingRabbitMQ.Service.Banking.Data.Repository;
using BankingRabbitMQ.Service.Banking.Data.Context;
using BankingRabbitMQ.Service.Transfer.Data.Context;
using BankingRabbitMQ.Service.Transfer.Data.Repository;
using BankingRabbitMQ.Service.Transfer.Application.Interfaces;
using BankingRabbitMQ.Service.Transfer.Application.Services;
using BankingRabbitMQ.Service.Transfer.Domain.Interfaces;
using BankingRabbitMQ.Service.Transfer.Domain.EventsHandlers;
using BankingRabbitMQ.Service.Transfer.Domain.Events;
using MediatR;


namespace BankingRabbitMQ.Infrastructure.IoC
{
    public class DependencyContainer
    {
        public static void RegisterServices(IServiceCollection services)
        {
            // Domain Bus
            services.AddSingleton<IEventBus, RabbitMQBus>(sp =>
            {
                var scopeFactory = sp.GetRequiredService<IServiceScopeFactory>();
                return new RabbitMQBus(sp.GetService<IMediator>(), scopeFactory);
            });

            // Subscriptions
            services.AddTransient<TransferEventHandler>();

            // Domain Events
            services.AddTransient<IEventHandler<TransferCreatedEvent>, TransferEventHandler>();

            // Domain Banking Commands
            services.AddTransient<IRequestHandler<CreateTransferCommand, bool>, TransferCommandHandler>();

            // Application Services
            services.AddTransient<IAccountService, AccountService>();
            services.AddTransient<ITransferService, TransferService>();

            // Data
            services.AddTransient<IAccountRepository, AccountRepository>();
            services.AddTransient<ITransferRepository, TransferRepository>();
            services.AddTransient<BankingDbContext>();
            services.AddTransient<TransferDbContext>();
        }
    }
}