using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace PHAdmin.API.Entities
{
    public class Expense
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required(ErrorMessage = "You should provide a expensedate value.")]
        public DateTime ExpenseDate { get; set; } = DateTime.Now;

        [Required]
        public decimal Amount { get; set; }

        public string? Comments { get; set; }

        public byte[]? Document { get; set; }

        [ForeignKey("ExpenseTypeId")]
        public ExpenseType? ExpenseType { get; set; }
        public int ExpenseTypeId { get; set; }
        //public string ExpenseTypeName { get; set; } = string.Empty;

        [Required(ErrorMessage = "You should provide a creationdate value.")]
        public DateTime CreationDate { get; set; } = DateTime.Now;

        public DateTime? UpdateDate { get; set; } = null;

        public int? CreatedBy { get; set; } = null;

        public int? UpdatedBy { get; set; } = null;

        [Required(ErrorMessage = "You should provide a status value.")]
        [StringLength(1)]
        [Column(TypeName = "char(1)")]
        public string Status { get; set; } = "A";

    }
}
