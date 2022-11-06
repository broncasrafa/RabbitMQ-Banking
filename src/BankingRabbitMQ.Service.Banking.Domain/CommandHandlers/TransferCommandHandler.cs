using BankingRabbitMQ.Core.Domain.Bus;
using BankingRabbitMQ.Service.Banking.Domain.Commands;
using BankingRabbitMQ.Service.Banking.Domain.Events;
using MediatR;

namespace BankingRabbitMQ.Service.Banking.Domain.CommandHandlers
{
    public class TransferCommandHandler : IRequestHandler<CreateTransferCommand, bool>
    {
        private readonly IEventBus _eventBus;

        public TransferCommandHandler(IEventBus eventBus)
        {
            _eventBus = eventBus;
        }


        public Task<bool> Handle(CreateTransferCommand request, CancellationToken cancellationToken)
        {
            //publish event to RabbitMQ
            _eventBus.Publish(new TransferCreatedEvent(request.FromAccount, request.ToAccount, request.TransferAmount));
            return Task.FromResult(true);
        }
    }
}
