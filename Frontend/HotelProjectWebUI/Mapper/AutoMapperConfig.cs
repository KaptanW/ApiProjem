using AutoMapper;
using HotelProjectEntityLayer.Concrete;
using HotelProjectWebUI.Dtos.AboutDto;
using HotelProjectWebUI.Dtos.BookingDto;
using HotelProjectWebUI.Dtos.LoginDto;
using HotelProjectWebUI.Dtos.RegisterDto;
using HotelProjectWebUI.Dtos.ServicesDto;
using HotelProjectWebUI.Dtos.SubscribeDto;

namespace HotelProjectWebUI.Mapper
{
    public class AutoMapperConfig:Profile
    {
        public AutoMapperConfig()
        {
            CreateMap<ResultServiceDto, Service>().ReverseMap();
            CreateMap<CreateServiceDto, Service>().ReverseMap();

            CreateMap<CreateNewUserDto, AppUser>().ReverseMap();
            CreateMap<LoginUserDto, AppUser>().ReverseMap();

            CreateMap<ResultAboutDto, About>().ReverseMap();
            CreateMap<UpdateAboutDto, About>().ReverseMap();

            CreateMap<CreateSubscribeDto, Subscribe>().ReverseMap();

            CreateMap<CreateBookingDto, Booking>().ReverseMap();
            CreateMap<ResultBookingDto, Booking>().ReverseMap();

            CreateMap<ApproveReservationDto, Booking>().ReverseMap();

        }
    }
}
