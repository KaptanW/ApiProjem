using AutoMapper;
using HotelProjectEntityLayer.Concrete;
using HotelProjectWebUI.Dtos.LoginDto;
using HotelProjectWebUI.Dtos.RegisterDto;
using HotelProjectWebUI.Dtos.ServicesDto;

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
        }
    }
}
