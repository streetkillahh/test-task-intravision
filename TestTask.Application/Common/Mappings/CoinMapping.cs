using AutoMapper;
using VendingMachine.Application.Common.Mappings;
using VendingMachine.Domain.Entities;
using VendingMachine.Domain.Dto;

namespace VendingMachine.Application.Mapping;

public class CoinMapping : IMapWith<Coin>
{
    public void Mapping(Profile profile)
    {
        profile.CreateMap<Coin, CoinDto>();
    }
}