namespace BankingRabbitMQ.Service.Banking.Application.DTOs
{
    public class AccountDTO
    {
        public Guid Id { get; set; }
        public string AccountType { get; set; }
        public decimal AccountBalance { get; set; }
    }
}
