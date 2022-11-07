namespace BankingRabbitMQ.Service.Transfer.Application.DTOs
{
    public class TransferLogDTO
    {
        public Guid Id { get; private set; }
        public Guid FromAccount { get; private set; }
        public Guid ToAccount { get; private set; }
        public decimal TransferAmount { get; private set; }

        public TransferLogDTO(Guid id, Guid fromAccount, Guid toAccount, decimal transferAmount)
        {
            Id = id;
            FromAccount = fromAccount;
            ToAccount = toAccount;
            TransferAmount = transferAmount;
        }
    }
}
