using BankingRabbitMQ.Core.Domain.Commands;

namespace BankingRabbitMQ.Service.Banking.Domain.Commands
{
    public abstract class TransferCommand : Command
    {
        public Guid FromAccount { get; protected set; }
        public Guid ToAccount { get; protected set; }
        public decimal TransferAmount { get; protected set; }
    }
}
