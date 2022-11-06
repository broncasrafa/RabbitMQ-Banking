namespace BankingRabbitMQ.Service.Banking.Domain.Commands
{
    public class CreateTransferCommand : TransferCommand
    {
        public CreateTransferCommand(Guid from, Guid to, decimal amount)
        {
            FromAccount = from;
            ToAccount = to;
            TransferAmount = amount;
        }
    }
}
