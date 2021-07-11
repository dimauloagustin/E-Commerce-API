using Application.Commands.Categories;
using Application.Commands.Users;
using Application.Features.Product;
using AutoMapper;

namespace Application.Mappings
{
    public class GeneralProfile : Profile
    {
        public GeneralProfile()
        { 
            CreateMap<CreateUser, Domain.Entities.User>(); 

            CreateMap<CreateCategory, Domain.Entities.Category>();

            CreateMap<CreateProduct, Domain.Entities.Product>();
            CreateMap<UpdateProduct, Domain.Entities.Product>();
        }
    }
}
