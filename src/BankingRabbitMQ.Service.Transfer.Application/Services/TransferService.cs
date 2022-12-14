using BankingRabbitMQ.Core.Domain.Bus;
using BankingRabbitMQ.Service.Transfer.Application.DTOs;
using BankingRabbitMQ.Service.Transfer.Application.Interfaces;
using BankingRabbitMQ.Service.Transfer.Domain.Interfaces;


namespace BankingRabbitMQ.Service.Transfer.Application.Services
{
    public class TransferService : ITransferService
    {
        private readonly ITransferRepository _transferRepository;
        private readonly IEventBus _eventBus;

        public TransferService(ITransferRepository transferRepository, IEventBus eventBus)
        {
            _transferRepository = transferRepository;
            _eventBus = eventBus;
        }



        public IEnumerable<TransferLogDTO> GetTransferLogs()
        {
            return _transferRepository.GetTransferLogs()
                                        .Select(c => new TransferLogDTO(c.Id, c.FromAccount, c.ToAccount, c.TransferAmount));
        }
    }
}
