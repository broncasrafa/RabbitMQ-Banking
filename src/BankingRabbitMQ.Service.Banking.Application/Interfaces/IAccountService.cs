using BankingRabbitMQ.Service.Banking.Application.DTOs;

namespace BankingRabbitMQ.Service.Banking.Application.Interfaces
{
    public interface IAccountService
    {
        IEnumerable<AccountDTO> GetAccounts();
        void Transfer(AccountTransferDTO accountTransfer);
    }
}
