

namespace PHAdmin.API.Models
{
    public class ApartmentDto
    {
        public int Id { get; set; }
      
        public int Floor { get; set; }
 
        public string Letter { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public DateTime CreationDate { get; set; } = DateTime.Now;
        public string Status { get; set; } = "A";

    }
}
