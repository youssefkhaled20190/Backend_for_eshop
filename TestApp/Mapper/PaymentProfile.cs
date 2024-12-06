using AutoMapper;
using TestApp.DAL.Entities;
using TestApp.ModelClasses;

namespace TestApp.Mapper
{
    public class PaymentProfile : Profile
    {
        public PaymentProfile()
        {
            CreateMap<PaymentModel,PaymentProcess>().ReverseMap();
        }
    }
}
