using AutoMapper;
using PHAdmin.API.Services;

namespace PHAdmin.API.Models
{
    public class RoleDto
    {
        public int Id { get; set; }
        public string RoleName { get; set; }= string.Empty;

        public ICollection<UserDto> Users { get; set; }
            = new List<UserDto>();
    }
}
