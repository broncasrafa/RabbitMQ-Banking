using BankingRabbitMQ.Core.Domain.Events;

namespace BankingRabbitMQ.Core.Domain.Bus
{
    public interface IEventHandler<in TEvent> : IEventHandler where TEvent : Event
    {
        Task Handle(TEvent @event);
    }

    public interface IEventHandler
    {
    }
}
