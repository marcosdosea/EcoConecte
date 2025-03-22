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
        private readonly EcoConecteContext context;
        public OrientacoesService(EcoConecteContext context)
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
            var orientacao = context.Orientacoes.FirstOrDefault(o => o.Id == id);
            if (orientacao != null)
            {
                context.Remove(orientacao);
                context.SaveChanges();
            }
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

        /// <summary>
        /// Buscar orientaçoes pelo titulo
        /// </summary>
        /// <param name="titulo"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Editar uma Orientaçao
        /// </summary>
        /// <param name="orientacoes"></param>
        /// <exception cref="NotImplementedException"></exception>
        public void Edit(Orientacoes orientacoes)
        {
            context.Update(orientacoes);
            context.SaveChanges();
        }

        public async Task<Orientacoes> ObterPorIdAsync(uint id)
        {
            var orientacao = await context.Orientacoes.FindAsync(id);
            if (orientacao == null) return null;

            return new Orientacoes
            {
                Id = orientacao.Id,
                Titulo = orientacao.Titulo,
                Descricao = orientacao.Descricao,
                IdCooperativa = orientacao.IdCooperativa
            };
        }

        public async Task<bool> AtualizarAsync(Orientacoes model)
        {
            var orientacao = await context.Orientacoes.FindAsync(model.Id);
            if (orientacao == null) return false;

            orientacao.Titulo = model.Titulo;
            orientacao.Descricao = model.Descricao;

            context.Orientacoes.Update(orientacao);
            return await context.SaveChangesAsync() > 0;
        }

        public async Task<bool> ExcluirAsync(uint id)
        {
            var orientacao = await context.Orientacoes.FindAsync(id);
            if (orientacao == null) return false;

            context.Remove(orientacao);
            return await context.SaveChangesAsync() > 0;
        }

    }
}
