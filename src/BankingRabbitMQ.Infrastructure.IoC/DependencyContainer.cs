using Microsoft.Extensions.DependencyInjection;
using BankingRabbitMQ.Core.Domain.Bus;
using BankingRabbitMQ.Infrastructure.Bus;
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
        }
    }
}