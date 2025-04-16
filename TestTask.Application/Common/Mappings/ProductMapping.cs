using AutoMapper;
using VendingMachine.Application.Common.Mappings;
using VendingMachine.Domain.Dto;
using VendingMachine.Domain.Entities;

namespace VendingMachine.Application.Mapping;

public class ProductMapping : IMapWith<Product>
{
    public void Mapping(Profile profile)
    {
        profile.CreateMap<Product, ProductDto>()
            .ForMember(dest => dest.BrandName, opt => opt.MapFrom(src => src.Brand.Name));
    }
}