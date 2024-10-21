using AutoMapper;
using Core;
using EcoConecteWeb.Models;

namespace EcoConecteWeb.Mapper
{
    public class VendaProfile : Profile
    {
        public VendaProfile() 
        {
            CreateMap<VendaViewModel, venda>().ReverseMap();
        }
    }
}
