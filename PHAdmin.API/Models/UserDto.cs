namespace PHAdmin.API.Models
{
    public class UserDto
    {
        public int Id { get; set; }
        public string? Identification { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string? Phone { get; set; } = string.Empty;
        public DateTime CreationDate { get; set; } = DateTime.Now;
        public string Status { get; set; } = "A";
    }
}
