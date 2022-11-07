using BankingRabbitMQ.Core.Domain.Events;

namespace BankingRabbitMQ.Service.Transfer.Domain.Events
{
    public class TransferCreatedEvent : Event
    {
        public Guid FromAccount { get; set; }
        public Guid ToAccount { get; set; }
        public decimal TransferAmount { get; set; }
    }
}
