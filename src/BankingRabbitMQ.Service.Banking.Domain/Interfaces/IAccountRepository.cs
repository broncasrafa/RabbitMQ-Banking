using BankingRabbitMQ.Service.Banking.Domain.Models;

namespace BankingRabbitMQ.Service.Banking.Domain.Interfaces
{
    public interface IAccountRepository
    {
        IEnumerable<Account> GetAccounts();
    }
}
