using AutoMapper;

namespace PHAdmin.API.Profiles
{
    public class ExpenseProfile: Profile
    {
        public ExpenseProfile()
        {
            CreateMap<Entities.Expense, Models.ExpenseDto>();
        }
    }
}
