using AutoMapper;
using statement_service.DTOs;
using Shared.Entities;

namespace statement_service.Mappers
{
    public class StatementMappingProfile : Profile
    {
        public StatementMappingProfile()
        {
            CreateMap<StatementInfo, StatementResponseDto>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.FullName, opt => opt.MapFrom(src => src.Statement.FullName))
                .ForMember(dest => dest.YearBirthday, opt => opt.MapFrom(src => src.Statement.YearBirthday))
                .ForMember(dest => dest.Group, opt => opt.MapFrom(src => src.Statement.Group))
                .ForMember(dest => dest.PhoneNumber, opt => opt.MapFrom(src => src.Statement.PhoneNumber))
                .ForMember(dest => dest.Faculty, opt => opt.MapFrom(src => src.Statement.Faculty))
                .ForMember(dest => dest.TypeOfStatement, opt => opt.MapFrom(src => src.Statement.TypeOfStatement))
                .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.Statement.UserId))
                .ForMember(dest => dest.Status, opt => opt.MapFrom(src => src.StatementStatus.ToString()))
                .ForMember(dest => dest.IsReady, opt => opt.MapFrom(src => src.IsReady));

            CreateMap<StatementDtoRequest, Statement>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())         
                .ForMember(dest => dest.StatementInfo, opt => opt.Ignore()) 
                .ForMember(dest => dest.User, opt => opt.Ignore());        


        }
    }
}
