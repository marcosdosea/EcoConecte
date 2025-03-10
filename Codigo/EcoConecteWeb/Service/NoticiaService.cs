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
    public class NoticiaService : INoticiaService
    {
        private readonly EcoConecteContext context;
        public NoticiaService (EcoConecteContext context)
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
            var noticia = context.Noticia.Find(id);
            if (noticia != null)
            {
                context.Noticia.Remove(noticia);
                context.SaveChanges();
            }
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

        /// <summary>
        /// Buscar notícia pelo titulo
        /// </summary>
        /// <param name="titulo"></param>
        /// <returns></returns>
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

        public async Task<Noticia> GetNoticiaForEditAsync(int id)
        {
            var noticia = await context.Noticia
                .Where(n => n.Id == id)
                .Select(n => new Noticia
                {
                    Id = n.Id,
                    Titulo = n.Titulo,
                    Conteudo = n.Conteudo,
                    Data = n.Data
                })
                .FirstOrDefaultAsync();

            return noticia;
        }

        public async Task<bool> EditNoticiaAsync(Noticia model)
        {
            var noticia = await context.Noticia.FindAsync(model.Id);
            if (noticia == null)
            {
                return false;
            }

            // Atualizando os campos do objeto Noticia com os dados do NoticiaViewModel
            noticia.Titulo = model.Titulo;
            noticia.Conteudo = model.Conteudo;
            noticia.Data = model.Data;

            // Salvando as mudanças no banco de dados
            context.Noticia.Update(noticia);
            await context.SaveChangesAsync();

            return true;
        }

        public async Task<Noticia> ObterPorIdAsync(int id)
        {
            var noticia = await context.Noticia
                .Where(n => n.Id == id)
                .Select(n => new Noticia
                {
                    Id = n.Id,
                    Titulo = n.Titulo,
                    Conteudo = n.Conteudo,
                    Data = n.Data
                })
                .FirstOrDefaultAsync();

            return noticia;
        }

        public async Task<bool> ApagarNoticiaAsync(int id)
        {
            var noticia = await context.Noticia.FirstOrDefaultAsync(n => n.Id == id);
            if (noticia == null)
                return false;

            context.Remove(noticia);
            await context.SaveChangesAsync();
            return true;
        }
    }
}
