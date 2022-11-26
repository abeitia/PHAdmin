using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PHAdmin.API.Entities
{
    [Table("Roles")]
    public class Role
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }


        [Required(ErrorMessage = "You should provide a rolename value.")]
        [MaxLength(100)]
        public string RoleName { get; set; }

        public ICollection<User> Users { get; set; }
               = new List<User>();

        public Role(string roleName)
        {
           
            RoleName = roleName;    
        }
    }
}
