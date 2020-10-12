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
            CreateMap<User, UserResource>();
        }
    }
}