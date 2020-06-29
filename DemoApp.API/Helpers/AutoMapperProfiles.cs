using AutoMapper;
using DemoApp.API.Dtos;
using DemoApp.API.Models;

namespace DemoApp.API.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<User, UserLoginDto>();
            CreateMap<User, UserRegisterDto>();
            CreateMap<User, UserListDto>();
        }
    }
}