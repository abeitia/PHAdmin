using AutoMapper;

namespace PHAdmin.API.Profiles
{
    public class RoleProfile: Profile
    {
        public RoleProfile()
        {
            CreateMap<Entities.Role, Models.RoleDto>();
        }
    }
}
