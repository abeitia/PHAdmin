using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace PHAdmin.API.Entities
{
    public class Payment
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required(ErrorMessage = "You should provide a paymentdate value.")] 
        public DateTime PaymentDate { get; set; } = DateTime.Now;

        [Required]
        public decimal Amount { get; set; }

        [MaxLength(1500)]
        public string? Comments { get; set; }

        [ForeignKey("UserId")]
        public User? User { get; set; }
        public int UserId { get; set; }

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
