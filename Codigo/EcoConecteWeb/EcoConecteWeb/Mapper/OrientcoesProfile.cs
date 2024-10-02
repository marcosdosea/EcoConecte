using AutoMapper;
using Core;
using EcoConecteWeb.Models;

namespace EcoConecteWeb.Mapper
{
    public class OrientcoesProfile : Profile
    {
        public OrientcoesProfile()
        {
            CreateMap<OrientacoesViewModel, Orientacoes>().ReverseMap();
        }
    }
}
