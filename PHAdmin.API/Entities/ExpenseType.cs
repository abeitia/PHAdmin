using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace PHAdmin.API.Entities
{
    public class ExpenseType
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }


        [Required(ErrorMessage = "You should provide a expensename value.")]
        [MaxLength(100)]
        public string ExpenseName { get; set; }

        public ExpenseType( string expenseName)
        {
            ExpenseName = expenseName;  
        }
    }
}
