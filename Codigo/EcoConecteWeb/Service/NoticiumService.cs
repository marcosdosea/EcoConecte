using Core;
using Core.Service;
using Microsoft.EntityFrameworkCore;

namespace Service
{
    class NoticiumService : INoticiumServices
    {
        private readonly ecoconecteContext context;
        public NoticiumService (ecoconecteContext context)
        {
            this.context = context;
        }

        /// </summary>
        /// Criar uma notícia
        /// <param name="noticium"></param>
        /// <returns></returns>
        public uint Inserir(Noticium noticium)
        {
            context.Add(noticium);
            context.SaveChanges();
            return noticium.Id;
        }
        /// <summary>
        /// Remover uma notícia
        /// </summary>
        /// <param name="idNoticium"></param>
        public void Remover(uint idNoticium)
        {
            var _noticium = context.Noticia.Find(idNoticium);
            context.Noticia.Remove(_noticium);
            context.SaveChanges();
        }
        /// <summary>
        /// Editar uma notícia
        /// </summary>
        /// <param name="noticium"></param>
        /// <exception cref="NotImplementedException"></exception>
        public void Editar(Noticium noticium)
        {
            context.Update(noticium);
            context.SaveChanges();
        }
        /// <summary>
        /// Busca todas as noticias no banco de dados
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Noticium> GetAll()
        {
            return context.Noticia.AsNoTracking();
        }

        /// <summary>
        /// Busca noticia pelo ID
        /// </summary>
        /// <param name="idNoticium"></param>
        /// <returns></returns>
        public Noticium? GetById(uint Id)
        {
            return context.Noticia.Find(Id);
        }

        public IEnumerable<Noticium> GetByTitulo(string titulo)
        {
            var query = from noticium in context.Noticia
                        where noticium.Titulo.StartsWith(titulo)
                        orderby noticium.Titulo
                        select new Core.Noticium
                        {
                            Id = noticium.Id,
                            Titulo = noticium.Titulo,
                        };
            return query;
        }
    }
}
