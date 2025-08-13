using AutoMapper;
using MSMA.Models;
using MSMA.Models.DTO;
namespace MSMA

{
    public class DTOProfile : Profile
    {
        public DTOProfile()
        {
            CreateMap<Users, UsersDTO>();


            CreateMap<Gifts, GiftsDTO>();
            CreateMap<Cards, CardsDTO>();
            CreateMap<Donors, DonorsDTO>();
            CreateMap<UsersDTO, Users>();
            CreateMap<Orders, OrdersDTO>();
            CreateMap<OrdersDTO, Orders>();

            CreateMap<GiftsDTO, Gifts>();
            CreateMap<CardsDTO, Cards>();
            CreateMap<DonorsDTO, Donors>();

        }
    }
}
