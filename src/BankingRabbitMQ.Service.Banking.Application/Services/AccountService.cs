using BankingRabbitMQ.Core.Domain.Bus;
using BankingRabbitMQ.Service.Banking.Application.DTOs;
using BankingRabbitMQ.Service.Banking.Application.Interfaces;
using BankingRabbitMQ.Service.Banking.Domain.Commands;
using BankingRabbitMQ.Service.Banking.Domain.Interfaces;

namespace BankingRabbitMQ.Service.Banking.Application.Services
{
    public class AccountService : IAccountService
    {
        private readonly IAccountRepository _accountRepository;
        private readonly IEventBus _eventBus;

        public AccountService(IAccountRepository accountRepository, IEventBus eventBus)
        {
            _accountRepository = accountRepository;
            _eventBus = eventBus;
        }



        public IEnumerable<AccountDTO> GetAccounts()
        {
            var data = _accountRepository.GetAccounts();
            var result = data.Select(c => new AccountDTO { Id = c.Id, AccountType = c.AccountType, AccountBalance = c.AccountBalance }).ToList();
            return result;
        }

        public void Transfer(AccountTransferDTO accountTransfer)
        {
            var createTransferCommand = new CreateTransferCommand(
                from: accountTransfer.FromAccount,
                to: accountTransfer.ToAccount,
                amount: accountTransfer.TransferAmount);

            _eventBus.SendCommand(createTransferCommand);           
        }
    }
}
