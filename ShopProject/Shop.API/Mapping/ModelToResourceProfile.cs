using AutoMapper;
using Shop.API.Domain.Models;
using Shop.API.Resources;

namespace Shop.API.Mapping
{
    public class ModelToResourceProfile : Profile
    {
        public ModelToResourceProfile()
        {
            CreateMap<Category, CategoryResource>();
        }
    }
}