using AutoMapper;

namespace PHAdmin.API.Profiles
{
    public class ExpenseProfile: Profile
    {
        public ExpenseProfile()
        {
            CreateMap<Models.ExpenseForCreationDto, Entities.Expense>();

            CreateMap<Models.ExpenseDto, Entities.Expense>();
            CreateMap<Models.ExpenseDto, Models.ExpenseForCreationDto>();
            CreateMap<Models.ExpenseForCreationDto, Models.ExpenseDto>();


            CreateMap<Entities.Expense, Models.ExpenseDto>();
            CreateMap<Entities.Expense, Models.ExpenseForCreationDto>();
        }
    }
}
