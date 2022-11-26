using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace PHAdmin.API.Entities
{
    public class Holiday
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required(ErrorMessage = "You should provide a date value.")]
        [Column(TypeName = "Date")]
        public DateTime DateValue { get; set; }
       
        [MaxLength(100)]
        public string? Description { get; set; }

        public Holiday(DateTime dateValue)
        {
           DateValue = dateValue;
      
        }
    }
}
