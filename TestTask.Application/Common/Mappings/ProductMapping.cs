using AutoMapper;
using VendingMachine.Application.Common.Mappings;
using VendingMachine.Domain.Entities;
using VendingMachine.Domain.Dto;

namespace VendingMachine.Application.Mapping;

public class ProductMapping : IMapWith<Product>
{
    public void Mapping(Profile profile)
    {
        profile.CreateMap<Product, ProductDto>()
            .ForMember(dest => dest.BrandName, opt => opt.MapFrom(src => src.Brand.Name));
    }
}