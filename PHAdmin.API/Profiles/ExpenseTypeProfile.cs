using AutoMapper;

namespace PHAdmin.API.Profiles
{
    public class ExpenseTypeProfile: Profile
    {

        public ExpenseTypeProfile()
        {
            CreateMap<Entities.ExpenseType, Models.ExpenseTypeDto>();
        }
        
    }
}
