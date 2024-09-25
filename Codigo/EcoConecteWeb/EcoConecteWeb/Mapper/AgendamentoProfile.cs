using AutoMapper;
using Core;
using EcoConecteWeb.Models;

namespace EcoConecteWeb.Mapper
{
    public class AgendamentoProfile : Profile
    {
        public AgendamentoProfile()
        {
            CreateMap<AgendamentoViewModel, Agendamento>().ReverseMap();
        }
    }
}
