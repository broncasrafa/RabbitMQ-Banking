using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace BankingRabbitMQ.Service.Transfer.Domain.Models
{
    public class TransferLog
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        public Guid FromAccount { get; set; }
        public Guid ToAccount { get; set; }
        public decimal TransferAmount { get; set; }
    }
}
