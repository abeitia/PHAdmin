namespace PHAdmin.API.Models
{
    public class ExpenseForCreationDto
    {

       
        public DateTime ExpenseDate { get; set; }
        public decimal Amount { get; set; }
        public string? Comments { get; set; } = string.Empty;
        public int ExpenseTypeId { get; set; }
        public string FilePath { get; set; } = string.Empty;
        public DateTime CreationDate { get; set; } = DateTime.Now;

        public int CreatedBy { get; set; }
        public string Status { get; set; } = "A";

        
    }
}
