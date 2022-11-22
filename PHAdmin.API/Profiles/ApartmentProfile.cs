using AutoMapper;

namespace PHAdmin.API.Profiles
{
    public class ApartmentProfile: Profile
    {
        public ApartmentProfile()
        {
            CreateMap<Entities.Apartment, Models.ApartmentDto>();
        }
    }
}
