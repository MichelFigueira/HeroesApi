using AutoMapper;
using HeroesApi.Data.Dtos;
using HeroesApi.Models;

namespace HeroesApi.Profiles
{
    public class HeroesProfile : Profile
    {
        public HeroesProfile()
        {
            CreateMap<HeroDto, Hero>().ReverseMap();
        }
    }
}
