using Core;
using Core.Dto;
using Core.Service;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class PessoaService : IPessoaService
    {
        private readonly EcoConecteContext context;
        public PessoaService(EcoConecteContext context)
        {
            this.context = context;
        }

        /// <summary>
        /// Criar uma nova pessoa na base de dados
        /// </summary>
        /// <param name="pessoa">dados da pessoa</param>
        /// <returns>id da pessoa</returns>
        public uint Create(Pessoa pessoa)
        {
            context.Add(pessoa);
            context.SaveChanges();
            return pessoa.Id;
        }

        /// <summary>
        /// Apagar uma pessoa do banco de dados
        /// </summary>
        /// <param name="id">Id da pessoa</param>
        public void Delete(uint id)
        {
            var pessoa = context.Pessoas.Find(id);
            if (pessoa != null)
            {
                context.Remove(pessoa);
                context.SaveChanges();
            }
        }

        /// <summary>
        /// Altera os dados de uma pessoa no banco de dados
        /// </summary>
        /// <param name="pessoa">Dados alterados da pessoa</param>
        public void Edit(Pessoa pessoa)
        {
            context.Update(pessoa);
            context.SaveChanges();
        }

        /// <summary>
        /// Busca uma pessoa na base de dados
        /// </summary>
        /// <param name="id">Id da pessoa</param>
        /// <returns>Dados da pessoa</returns>
        public Pessoa? Get(uint id)
        {
            return context.Pessoas.Find(id);
        }

        /// <summary>
        /// Busca todas as pessoas do banco de dados
        /// </summary>
        /// <returns>Uma lista de pessoas</returns>
        public IEnumerable<Pessoa> GetAll()
        {
            return context.Pessoas.AsNoTracking();
        }

        /// <summary>
        /// Busca pessoas pelo nome no banco de dados
        /// </summary>
        /// <param name="name">Nome da pessoa</param>
        /// <returns>Uma lista de pessoas</returns>
        public IEnumerable<PessoaDto> GetByName(string name)
        {
            var query = from pessoa in context.Pessoas
                         where pessoa.Nome.StartsWith(name)
                         orderby pessoa.Nome
                         select new Core.Dto.PessoaDto
                         {
                             IdPessoa = pessoa.Id,
                             Nome = pessoa.Nome
                         };
            return query;
        }
    }
}
