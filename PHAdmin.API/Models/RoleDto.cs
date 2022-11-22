using AutoMapper;
using PHAdmin.API.Services;

namespace PHAdmin.API.Models
{
    public class RoleDto
    {
        public int Id { get; set; }
        public string RoleName { get; set; }

        public RoleDto(IPHAdminRepository phAdminRepository,
            IMapper mapper)
        {

        }
    }
}
