using System.Linq;
using AutoMapper;
using Shop.API.Domain.Models;
using Shop.API.Resources;

namespace Shop.API.Mapping
{
    public class ModelToResourceProfile : Profile
    {
        public ModelToResourceProfile()
        {
            CreateMap<Product, ProductResource>();
            CreateMap<Category, CategoryResource>();
            CreateMap<User, UserResource>()
                .ForMember(x => x.Role, y => y.MapFrom(s => s.UserRoles.Select(z => z.Role.Name)));
            
        }
    }
}