using AutoMapper;
using VendingMachine.Application.Common.Mappings;
using VendingMachine.Domain.Dto;
using VendingMachine.Domain.Entities;

namespace VendingMachine.Application.Mapping;

public class CoinMapping : IMapWith<Coin>
{
    public void Mapping(Profile profile)
    {
        profile.CreateMap<Coin, CoinDto>();
    }
}