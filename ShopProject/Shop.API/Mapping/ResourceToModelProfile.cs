using AutoMapper;
using Shop.API.Domain.Models;
using Shop.API.Resources;

namespace Shop.API.Mapping
{
    public class ResourceToModelProfile : Profile
    {
        public ResourceToModelProfile()
        {
            CreateMap<SaveCategoryResource, Category>()
                    .ForMember(x => x.CategoryName, y => y.MapFrom(x => x.Name));

            CreateMap<SaveProductResource, Product>();
            CreateMap<SaveUserResource, User>();
                                   
        }
    }
}