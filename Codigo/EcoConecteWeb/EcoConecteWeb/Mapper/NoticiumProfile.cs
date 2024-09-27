using AutoMapper;
using Core;
using EcoConecteWeb.Models;

namespace EcoConecteWeb.Mapper
{
    public class NoticiumProfile : Profile
    {
        public NoticiumProfile()
        {
            CreateMap<NoticiumViewModel, Noticium>().ReverseMap();
        }
    }
}
