using AutoMapper;

namespace PHAdmin.API.Profiles
{
    public class DebtProfile: Profile
    {
        public DebtProfile()
        {
            CreateMap<Entities.Debt, Models.DebtDto>();
        }
    }
}
