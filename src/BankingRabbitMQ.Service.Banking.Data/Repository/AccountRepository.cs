using BankingRabbitMQ.Service.Banking.Data.Context;
using BankingRabbitMQ.Service.Banking.Domain.Interfaces;
using BankingRabbitMQ.Service.Banking.Domain.Models;

namespace BankingRabbitMQ.Service.Banking.Data.Repository
{
    public class AccountRepository : IAccountRepository
    {
        private readonly BankingDbContext _context;

        public AccountRepository(BankingDbContext context)
        {
            _context = context;
        }


        public IEnumerable<Account> GetAccounts()
        {
            return _context.Accounts;
        }
    }
}
