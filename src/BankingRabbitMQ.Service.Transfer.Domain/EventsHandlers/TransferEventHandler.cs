using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BankingRabbitMQ.Core.Domain.Bus;
using BankingRabbitMQ.Service.Transfer.Domain.Events;
using BankingRabbitMQ.Service.Transfer.Domain.Interfaces;

namespace BankingRabbitMQ.Service.Transfer.Domain.EventsHandlers
{
    public class TransferEventHandler : IEventHandler<TransferCreatedEvent>
    {
        private readonly ITransferRepository _transferRepository;

        public TransferEventHandler(ITransferRepository transferRepository)
        {
            _transferRepository = transferRepository;
        }


        public Task Handle(TransferCreatedEvent @event)
        {
            _transferRepository.Add(new Models.TransferLog
            {
                FromAccount = @event.FromAccount,
                ToAccount = @event.ToAccount,
                TransferAmount = @event.TransferAmount,
            });

            return Task.CompletedTask;
        }
    }
}
