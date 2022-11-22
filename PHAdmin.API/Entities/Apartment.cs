using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PHAdmin.API.Entities
{
    public class Apartment
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]   
        public int Id { get; set; }

        [Required(ErrorMessage = "You should provide a floor value.")]
        public int Floor { get; set; }

        [Required(ErrorMessage = "You should provide a letter value.")]
        [MaxLength(1)]
        [Column(TypeName = "char(1)")]
        public string Letter { get; set; } = string.Empty;

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public string Name { get; private set; }

        [Required(ErrorMessage = "You should provide a creationdate value.")]
        public DateTime CreationDate { get; set; } = DateTime.Now;

        public DateTime? UpdateDate { get; set; } = null;

        public int? CreatedBy { get; set; } = null;

        public int? UpdatedBy { get; set; } = null;

        [Required(ErrorMessage = "You should provide a status value.")]
        [MaxLength(1)]
        [MinLength(1)]
        [Column(TypeName = "char(1)")]
        public string Status { get; set; } = "A";






      
    }
}
