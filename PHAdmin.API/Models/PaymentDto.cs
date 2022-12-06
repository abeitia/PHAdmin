using PHAdmin.API.Entities;

namespace PHAdmin.API.Models
{
    public class PaymentDto
    {
        public int Id { get; set; }
        public DateTime PaymentDate { get; set; }
        public decimal Amount { get; set; }
        public string? Comments { get; set; } = string.Empty;
      
        public DateTime CreationDate { get; set; } = DateTime.Now;
        public string Status { get; set; } = "A";
    }
}
