using BankingRabbitMQ.Service.Transfer.Domain.Models;

namespace BankingRabbitMQ.Service.Transfer.Application.Interfaces
{
    public interface ITransferService
    {
        IEnumerable<TransferLog> GetTransferLogs();
    }
}
