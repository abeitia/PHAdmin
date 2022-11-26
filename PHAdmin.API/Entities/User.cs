using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace PHAdmin.API.Entities
{
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [MaxLength(50)] 
        public string? Identification { get; set; } = string.Empty;

        [Required(ErrorMessage = "You should provide a name value.")]
        [MaxLength(100)]
        public string Name { get; set; } = string.Empty;

        [Required(ErrorMessage = "You should provide a email value.")]
        [MaxLength(100)] 
        public string Email { get; set; } = string.Empty;

        [MaxLength(50)] 
        public string? Phone { get; set; } = string.Empty;

        [MaxLength(100)] 
        public string? Password { get; set; } = string.Empty;

        [ForeignKey("RoleId")]
        public Role? Role { get; set; }
        public int RoleId { get; set; }

        [Required(ErrorMessage = "You should provide a creationdate value.")]
        public DateTime CreationDate { get; set; } = DateTime.Now;

        public DateTime? UpdateDate { get; set; } = null;

        public int? CreatedBy { get; set; } = null;

        public int? UpdatedBy { get; set; } = null;

        [Required(ErrorMessage = "You should provide a status value.")]
        [StringLength(1)]
        [Column(TypeName = "char(1)")]
        public string Status { get; set; } = "A";

        public User(string name)
        {
            Name = name;
        }

    }
}
