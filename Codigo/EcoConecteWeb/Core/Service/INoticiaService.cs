﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Service
{
    public interface INoticiaServices
    {
        uint Create(Noticia noticium);
        void Update(Noticia noticium);
        void Edit(Noticia noticia);
        void Delete(uint id);
        Noticia? GetById(uint id);
        IEnumerable<Noticia> GetAll();
        IEnumerable<Noticia> GetByTitulo(string titulo);

    }
}