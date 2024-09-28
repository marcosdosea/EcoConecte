using AutoMapper;
using Core;
using EcoConecteWeb.Models;

namespace EcoConecteWeb.Mapper
{
    public class ColetaProfile : Profile
    {
        public ColetaProfile()
        {
            CreateMap<ColetaViewModel, Coleta>().ReverseMap();
        }
    }
}