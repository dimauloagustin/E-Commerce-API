using Application.Features.User.Commands;
using Application.Features.User.Responses;
using AutoMapper;

namespace Application.Mappings
{
    public class GeneralProfile : Profile
    {
        public GeneralProfile()
        { 
            CreateMap<CreateUserCommand, Domain.Entities.User>(); 
            CreateMap<Domain.Entities.User, UserResponse>();
        }
    }
}
