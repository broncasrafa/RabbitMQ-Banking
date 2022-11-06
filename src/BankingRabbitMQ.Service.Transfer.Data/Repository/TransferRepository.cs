using BankingRabbitMQ.Service.Transfer.Data.Context;
using BankingRabbitMQ.Service.Transfer.Domain.Interfaces;
using BankingRabbitMQ.Service.Transfer.Domain.Models;

namespace BankingRabbitMQ.Service.Transfer.Data.Repository
{
    public class TransferRepository : ITransferRepository
    {
        private readonly TransferDbContext _context;

        public TransferRepository(TransferDbContext context)
        {
            _context = context;
        }


        public void Add(TransferLog transferLog)
        {
            _context.TransferLogs.Add(transferLog);
            _context.SaveChanges();
        }

        public IEnumerable<TransferLog> GetTransferLogs()
        {
            return _context.TransferLogs;
        }
    }
}
