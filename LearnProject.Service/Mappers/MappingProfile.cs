using AutoMapper;
using LearnProject.Domain.Entities;
using LearnProject.Service.DTOs;

namespace LearnProject.Service.Mappers;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<User,UserForCreationDto>().ReverseMap();
        CreateMap<User,UserForResultDto>().ReverseMap();
        CreateMap<User,UserForUpdateDto>().ReverseMap();
    }
}
