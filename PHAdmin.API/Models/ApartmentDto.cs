using System.ComponentModel.DataAnnotations;

namespace PHAdmin.API.Models
{
    public class ApartmentDto
    {
        public int Id { get; set; }

      
        public int Floor { get; set; }

  
        public string Letter { get; set; } = string.Empty;
        public string? Name { get; set; } 
       
    }
}
