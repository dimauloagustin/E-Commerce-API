using Application.Features.Category.Commands;
using Application.Features.Product;
using Application.Features.User.Commands;
using AutoMapper;

namespace Application.Mappings
{
    public class GeneralProfile : Profile
    {
        public GeneralProfile()
        { 
            CreateMap<CreateUserCommand, Domain.Entities.User>(); 

            CreateMap<CreateCategoryCommand, Domain.Entities.Category>();

            CreateMap<CreateProduct, Domain.Entities.Product>();
            CreateMap<UpdateProduct, Domain.Entities.Product>();
        }
    }
}
