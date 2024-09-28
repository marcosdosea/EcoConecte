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

        private readonly ecoconecteContext context;

        public CooperativaService(ecoconecteContext context)
        {
            this.context = context;
        }
        
        public uint Create(Cooperativa cooperativa)
        {
            context.Add(cooperativa);
            context.SaveChanges();
            return cooperativa.Id;
        }

        
        public void Delete(uint id)
        {
            var cooperativa = context.Cooperativas.Find(id);
            if (cooperativa != null)
            {
                context.Remove(cooperativa);
                context.SaveChanges();
            }
        }

       
        public void Update(Cooperativa cooperativa)
        {
            context.Update(cooperativa);
            context.SaveChanges();
        }

        
        public Cooperativa? Get(uint id)
        {
            return context.Cooperativas.Find(id);
        }

        public IEnumerable<Cooperativa> GetAll()
        {
            return context.Cooperativas.AsNoTracking();
        }
    }
}

