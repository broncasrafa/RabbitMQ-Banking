using BankingRabbitMQ.Core.Domain.Events;

namespace BankingRabbitMQ.Core.Domain.Commands
{
    public abstract class Command : Message
    {
        public DateTime Timestamp { get; protected set; }

        protected Command()
        {
            Timestamp = DateTime.Now;
        }
    }
}
