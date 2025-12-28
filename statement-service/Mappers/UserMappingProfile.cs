using AutoMapper;
using Shared.Entities;
using statement_service.DTOs;

namespace statement_service.Mapper
{
    public class UserMappingProfile : Profile
    {
        public UserMappingProfile()
        {            
            CreateMap<User, UserResponseDto>()
                .ForMember(dest => dest.Statements, opt => opt.MapFrom(src => src.Statements));

            CreateMap<UserRequestDto, User>()
                .ForMember(dest => dest.UserId, opt => opt.Ignore()) // Id генерується базою
                .ForMember(dest => dest.Statements, opt => opt.Ignore()); // Список заявок не мапимо тут
        }
    }
}
