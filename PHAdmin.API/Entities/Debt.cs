using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace PHAdmin.API.Entities
{
    public class Debt
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [ForeignKey("ApartmentId")]
        public Apartment? Apartment { get; set; }
        public int ApartmentId { get; set; }

        [ForeignKey("PaymentTypeId")]
        public PaymentType? PaymentType { get; set; }
        public int PaymentTypeId { get; set; }

        [Required(ErrorMessage = "You should provide a duedate value.")]
        public DateTime DueDate { get; set; } = DateTime.Now;

        [Required]
        public decimal Amount { get; set; }

        [Required]
        public decimal AmountPaid { get; set; } = 0;

        [MaxLength(1500)]
        public string? Comments { get; set; }

       

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
