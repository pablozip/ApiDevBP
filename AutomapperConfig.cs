using ApiDevBP.Application.CreateUser;
using ApiDevBP.Entities;
using ApiDevBP.Models;

using AutoMapper;

namespace ApiDevBP;

public class AutomapperConfig : Profile
{
    public AutomapperConfig()
    {
        CreateMap<CreateUserCommand, UserModel>();
        CreateMap<UserModel, UserEntity>()
            .ForMember(m => m.Name, o => o.MapFrom(x => x.Name))
            .ForMember(m => m.Lastname, o => o.MapFrom(x => x.Lastname));
    }
}
