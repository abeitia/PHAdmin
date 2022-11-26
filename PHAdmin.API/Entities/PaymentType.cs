using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace PHAdmin.API.Entities
{
    public class PaymentType
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }


        [Required(ErrorMessage = "You should provide a paymentname value.")]
        [MaxLength(100)]
        public string PaymentName { get; set; }

        public PaymentType(string paymentName)
        {
        
            PaymentName = paymentName;  
        }
    }
}
