namespace BankingRabbitMQ.Service.Banking.Application.DTOs
{
    public class AccountTransferDTO
    {
        public Guid FromAccount { get; set; }
        public Guid ToAccount { get; set; }
        public decimal TransferAmount { get; set; }
    }
}
