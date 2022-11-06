using BankingRabbitMQ.Core.Domain.Events;

namespace BankingRabbitMQ.Service.Banking.Domain.Events
{
    public class TransferCreatedEvent : Event
    {
        public Guid FromAccount { get; private set; }
        public Guid ToAccount { get; private set; }
        public decimal TransferAmount { get; private set; }

        public TransferCreatedEvent(Guid from, Guid to, decimal amount)
        {
            FromAccount = from;
            ToAccount = to;
            TransferAmount = amount;
        }
    }
}
