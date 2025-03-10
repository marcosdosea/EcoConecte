using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Service
{
    public interface INoticiaService
    {
        /// <summary>
        /// Criar uma notícia
        /// </summary>
        /// <param name="noticia"></param>
        /// <returns></returns>
        uint Create(Noticia noticia);

        /// <summary>
        /// Atualizar uma notícia
        /// </summary>
        /// <param name="noticia"></param>
        void Update(Noticia noticia);

        /// <summary>
        /// Editar uma notícia
        /// </summary>
        /// <param name="noticia"></param>
        void Edit(Noticia noticia);

        /// <summary>
        /// Deletar uma notícia
        /// </summary>
        /// <param name="id"></param>
        void Delete(uint id);

        /// <summary>
        /// Buscar notícia por ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Noticia? GetById(uint id);

        /// <summary>
        /// Listar todas as notícias
        /// </summary>
        /// <returns></returns>
        IEnumerable<Noticia> GetAll();

        /// <summary>
        /// Buscar notícia por um titulo
        /// </summary>
        /// <param name="titulo"></param>
        /// <returns></returns>
        IEnumerable<Noticia> GetByTitulo(string titulo);

        Task<Noticia> GetNoticiaForEditAsync(int id);

        Task<bool> EditNoticiaAsync(Noticia model);
    }
}
