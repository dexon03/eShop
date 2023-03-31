using AutoMapper;
using Domain.Entities;

namespace Application.Core;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Category, Category>();
        CreateMap<Vendor, Vendor>();
        CreateMap<Product, Product>();
    }
}