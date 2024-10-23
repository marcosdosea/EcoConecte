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
    public class CooperativaService : ICooperativaService
    {

        private readonly EcoConecteContext context;

        public CooperativaService(EcoConecteContext context)
        {
            this.context = context;
        }
        
        /// <summary>
        /// Criar uma cooperativa
        /// </summary>
        /// <param name="cooperativa"></param>
        /// <returns></returns>
        public uint Create(Cooperativa cooperativa)
        {
            context.Add(cooperativa);
            context.SaveChanges();
            return cooperativa.Id;
        }

        /// <summary>
        /// Deletar uma cooperativa
        /// </summary>
        /// <param name="id"></param>
        public void Delete(uint id)
        {
            var cooperativa = context.Cooperativas.Find(id);
            if (cooperativa != null)
            {
                context.Remove(cooperativa);
                context.SaveChanges();
            }
        }

       /// <summary>
       /// Atualizar dados cooperativa
       /// </summary>
       /// <param name="cooperativa"></param>
        public void Update(Cooperativa cooperativa)
        {
            context.Update(cooperativa);
            context.SaveChanges();
        }

        /// <summary>
        /// Buscar cooperativa por ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Cooperativa? Get(uint id)
        {
            return context.Cooperativas.Find(id);
        }

        /// <summary>
        /// Listar cooperativas
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Cooperativa> GetAll()
        {
            return context.Cooperativas.AsNoTracking();
        }
    }
}

