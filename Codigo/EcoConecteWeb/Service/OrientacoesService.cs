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
    public class OrientacoesService : IOrientacoesService
    {
        private readonly ecoconecteContext context;
        public OrientacoesService(ecoconecteContext context)
        {
            this.context = context;
        }

        /// </summary>
        /// Criar uma orientacoes
        /// <param name="orientacoes"></param>
        /// <returns></returns>
        public uint Create(Orientacoes orientacoes)
        {
            context.Add(orientacoes);
            context.SaveChanges();
            return orientacoes.Id;
        }
        /// <summary>
        /// Remover uma orientacoes
        /// </summary>
        /// <param name="id"></param>
        public void Delete(uint id)
        {
            context.Delete(id);
            context.SaveChanges();
        }
        /// <summary>
        /// Editar uma orientacoes
        /// </summary>
        /// <param name="orientacoes"></param>
        /// <exception cref="NotImplementedException"></exception>
        public void Update(Orientacoes orientacoes)
        {
            context.Update(orientacoes);
            context.SaveChanges();
        }
        /// <summary>
        /// Busca todas as noticias no banco de dados
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Orientacoes> GetAll()
        {
            return context.Orientacoes.AsNoTracking();
        }

        /// <summary>
        /// Busca orientacoes pelo ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Orientacoes? GetById(uint Id)
        {
            return context.Orientacoes.Find(Id);
        }

        public IEnumerable<Orientacoes> GetByTitulo(string titulo)
        {
            var query = from orientacoes in context.Orientacoes
                        where orientacoes.Titulo.StartsWith(titulo)
                        orderby orientacoes.Titulo
                        select new Core.Orientacoes
                        {
                            Id = orientacoes.Id,
                            Titulo = orientacoes.Titulo,
                        };
            return query;
        }

        public void Edit(Orientacoes orientacoes)
        {
            throw new NotImplementedException();
        }
    }
}
