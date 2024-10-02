using Core;
using Core.Service;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class NoticiaService : INoticiaServices
    {
        private readonly ecoconecteContext context;
        public NoticiaService (ecoconecteContext context)
        {
            this.context = context;
        }

        /// </summary>
        /// Criar uma notícia
        /// <param name="noticia"></param>
        /// <returns></returns>
        public uint Create(Noticia noticia)
        {
            context.Add(noticia);
            context.SaveChanges();
            return noticia.Id;
        }
        /// <summary>
        /// Remover uma notícia
        /// </summary>
        /// <param name="id"></param>
        public void Delete(uint id)
        {
            context.Delete(id);
            context.SaveChanges();
        }
        /// <summary>
        /// Editar uma notícia
        /// </summary>
        /// <param name="noticia"></param>
        /// <exception cref="NotImplementedException"></exception>
        public void Update(Noticia noticia)
        {
            context.Update(noticia);
            context.SaveChanges();
        }
        /// <summary>
        /// Busca todas as noticias no banco de dados
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Noticia> GetAll()
        {
            return context.Noticia.AsNoTracking();
        }

        /// <summary>
        /// Busca noticia pelo ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Noticia? GetById(uint Id)
        {
            return context.Noticia.Find(Id);
        }

        public IEnumerable<Noticia> GetByTitulo(string titulo)
        {
            var query = from noticia in context.Noticia
                        where noticia.Titulo.StartsWith(titulo)
                        orderby noticia.Titulo
                        select new Core.Noticia
                        {
                            Id = noticia.Id,
                            Titulo = noticia.Titulo,
                        };
            return query;
        }
        /// <summary>
        /// Altera os dados de uma noticia no banco de dados
        /// </summary>
        /// <param name="noticia">Dados alterados da pessoa</param>
        public void Edit(Noticia noticia)
        {
            context.Update(noticia);
            context.SaveChanges();
        }
    }
}
