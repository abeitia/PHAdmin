using AutoMapper;

namespace PHAdmin.API.Profiles
{
    public class HolidayProfile: Profile
    {
        public HolidayProfile()
        {
            CreateMap<Entities.Holiday, Models.HolidayDto>();
        }
    }
}
