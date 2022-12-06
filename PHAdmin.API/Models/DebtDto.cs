namespace PHAdmin.API.Models
{
    public class DebtDto
    {
        public int Id { get; set; }
        public int ApartmentId { get; set; }
        public int PaymentTypeId { get; set; }
        public DateTime DueDate { get; set; }
        public decimal Amount { get; set; }
        public decimal AmountPaid { get; set; }
        public string? Comments { get; set; } = string.Empty;

        public DateTime CreationDate { get; set; }
        public string Status { get; set; } = "A";
    }
}
