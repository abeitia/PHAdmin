namespace PHAdmin.API.Models
{
    public class ExpenseForUpdateDto
    {
        public DateTime ExpenseDate { get; set; }
        public decimal Amount { get; set; }
        public string? Comments { get; set; } = string.Empty;
        public int ExpenseTypeId { get; set; }
        public DateTime UpdateDate { get; set; } = DateTime.Now;
        public int UpdateBy { get; set; }
        public string Status { get; set; } = "";
    }
}
