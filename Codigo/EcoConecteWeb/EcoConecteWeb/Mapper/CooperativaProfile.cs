﻿using AutoMapper;
using Core;
using EcoConecteWeb.Models;

namespace EcoConecteWeb.Mapper
{
    public class CooperativaProfile : Profile
    {
        public CooperativaProfile()
        {
            CreateMap<NoticiaViewModel, Noticia>().ReverseMap();
        }
    }
}
