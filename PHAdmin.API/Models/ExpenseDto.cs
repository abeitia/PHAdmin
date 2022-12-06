namespace PHAdmin.API.Models
{
    public class ExpenseDto
    {
        public int Id { get; set; }
        public DateTime ExpenseDate { get; set; }
        public decimal Amount { get; set; }
        public string? Comments { get; set; } = string.Empty;
        public int ExpenseTypeId { get; set; }

        public DateTime CreationDate { get; set; } = DateTime.Now;
        public string Status { get; set; } = "A";
    }
}
