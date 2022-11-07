using BankingRabbitMQ.Service.Transfer.Application.DTOs;
using BankingRabbitMQ.Service.Transfer.Domain.Models;

namespace BankingRabbitMQ.Service.Transfer.Application.Interfaces
{
    public interface ITransferService
    {
        IEnumerable<TransferLogDTO> GetTransferLogs();
    }
}
