using BankingRabbitMQ.Service.Transfer.Domain.Models;

namespace BankingRabbitMQ.Service.Transfer.Domain.Interfaces
{
    public interface ITransferRepository
    {
        IEnumerable<TransferLog> GetTransferLogs();
        void Add(TransferLog transferLog);
    }
}
