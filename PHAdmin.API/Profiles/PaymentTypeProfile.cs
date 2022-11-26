using AutoMapper;

namespace PHAdmin.API.Profiles
{
    public class PaymentTypeProfile: Profile
    {
        public PaymentTypeProfile()
        {
            CreateMap<Entities.PaymentType, Models.PaymentTypeDto>();
        }
    }
}
