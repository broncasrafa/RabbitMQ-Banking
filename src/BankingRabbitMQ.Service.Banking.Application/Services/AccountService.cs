using BankingRabbitMQ.Service.Banking.Application.DTOs;
using BankingRabbitMQ.Service.Banking.Application.Interfaces;
using BankingRabbitMQ.Service.Banking.Domain.Interfaces;

namespace BankingRabbitMQ.Service.Banking.Application.Services
{
    public class AccountService : IAccountService
    {
        private readonly IAccountRepository _accountRepository;

        public AccountService(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
        }



        public IEnumerable<AccountDTO> GetAccounts()
        {
            var data = _accountRepository.GetAccounts();
            var result = data.Select(c => new AccountDTO { Id = c.Id, AccountType = c.AccountType, AccountBalance = c.AccountBalance }).ToList();
            return result;
        }

        public void Transfer(AccountTransferDTO accountTransfer)
        {
            throw new NotImplementedException();
        }
    }
}
