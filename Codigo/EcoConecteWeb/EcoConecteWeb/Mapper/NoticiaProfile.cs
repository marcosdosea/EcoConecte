using AutoMapper;
using Core;
using EcoConecteWeb.Models;

namespace EcoConecteWeb.Mapper
{
    public class NoticiaProfile : Profile
    {
        public NoticiaProfile()
        {
            CreateMap<NoticiaViewModel, Noticia>().ReverseMap();
        }
    }
}
