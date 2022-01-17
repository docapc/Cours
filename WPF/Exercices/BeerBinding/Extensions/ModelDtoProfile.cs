using AutoMapper;
using Dtos;
using Models;

namespace Extensions
{
    public class ModelDtoProfile : Profile
    {
        public ModelDtoProfile()
        {
            CreateMap<BeerDto, BeerModel>().ReverseMap();
        }
    }
}