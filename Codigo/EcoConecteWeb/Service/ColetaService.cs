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
    public class ColetaService : IColetaService
    {
        private readonly EcoConecteContext context;
        public ColetaService(EcoConecteContext context)
        {
            this.context = context;
        }

        /// </summary>
        /// Criar uma coleta
        /// <param name="coleta"></param>
        /// <returns></returns>
        public uint Create(Coleta coleta)
        {
            context.Add(coleta);
            context.SaveChanges();
            return coleta.Id;
        }
        /// <summary>
        /// Remover uma coleta
        /// </summary>
        /// <param name="id"></param>
        public void Delete(uint id)
        {
            var coleta = context.Coletas.FirstOrDefault(c => c.Id == id);
            if (coleta != null)
            {
                context.Coletas.Remove(coleta);
                context.SaveChanges();
            }
        }
        /// <summary>
        /// Editar uma coleta
        /// </summary>
        /// <param name="coleta"></param>
        /// <exception cref="NotImplementedException"></exception>
        public void Update(Coleta coleta)
        {
            context.Update(coleta);
            context.SaveChanges();
        }
        /// <summary>
        /// Busca todas as coletas no banco de dados
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Coleta> GetAll()
        {
            return context.Coletas.AsNoTracking();
        }

        /// <summary>
        /// Busca coleta pelo ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Coleta? GetById(uint Id)
        {
            return context.Coletas.Find(Id);
        }

        public IEnumerable<Coleta> GetByLagradouro(string lagradouro)
        {
            var query = from coleta in context.Coletas
                        where coleta.Logradouro.StartsWith(lagradouro)
                        orderby coleta.Logradouro
                        select new Core.Coleta
                        {
                            Id = coleta.Id,
                            Logradouro = coleta.Logradouro,
                        };
            return query;
        }
        /// <summary>
        /// Altera os dados de uma coleta no banco de dados
        /// </summary>
        /// <param name="coleta">Dados alterados da pessoa</param>
        public void Edit(Coleta coleta)
        {
            context.Update(coleta);
            context.SaveChanges();
        }

        public IEnumerable<Coleta> GetByCep(string cep)
        {
            return context.Coletas.Where(c => c.Cep == cep).ToList();
        }

        public IEnumerable<Coleta> GetByCooperativaId(uint idCooperativa)
        {
            return context.Coletas
                .AsNoTracking()
                .Where(c => c.IdCooperativa == idCooperativa)
                .ToList();
        }

        public async Task DeleteAsync(uint id)
        {
            var coleta = await context.Coletas.FindAsync(id);
            if (coleta != null)
            {
                context.Coletas.Remove(coleta);
                await context.SaveChangesAsync();
            }
        }

        public async Task<Coleta> GetByIdAsync(uint id)
        {
            return await context.Coletas.FindAsync(id);
        }

        public async Task<bool> UpdateAsync(Coleta coletas)
        {
            context.Coletas.Update(coletas);
            return await context.SaveChangesAsync() > 0;
        }

        async Task<bool> IColetaService.DeleteAsync(uint id)
        {
            var coleta = await context.Coletas.FindAsync(id);
            if (coleta == null)
            {
                return false; // Retorna falso se a coleta não for encontrada
            }

            context.Coletas.Remove(coleta);
            await context.SaveChangesAsync();
            return true; // Retorna verdadeiro se a exclusão for bem-sucedida
        }
    }
}
