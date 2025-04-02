using AutoMapper;
using test.Dtos.Order;
using test.Entities;

namespace test.Mapping
{
	public class Profiles : Profile
	{
        public Profiles()
        {
            CreateMap<CreateOrderDto, Order>().ReverseMap();
            CreateMap<Order, OrderResponseDto>()
                .ForMember(dest => dest.UserName,opt=> opt.MapFrom(src => src.User.Name))
                .ForMember(dest => dest.ProductName,opt=> opt.MapFrom(src => src.Product.Name))
                .ReverseMap();  
        }
    }
}
