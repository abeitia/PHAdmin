using AutoMapper;
namespace PHAdmin.API.Profiles
{
    public class PaymentProfile : Profile
    {
        public PaymentProfile()
        {
            CreateMap<Entities.Payment, Models.PaymentDto>();
        }
    }
}
