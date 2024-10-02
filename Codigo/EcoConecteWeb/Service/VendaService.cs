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
    public class VendaService : IVendaService
    {
        private readonly EcoConecteContext context;
        public VendaService(EcoConecteContext context)
        {
            this.context = context;
        }

        public uint Create(Vendamaterial Venda)
        {
            context.Add(Venda);
            context.SaveChanges();
            return Venda.Id;
        }

        public bool Delete(uint Id)
        {
            var Venda = context.Vendamaterials.Find(Id);
            if (Venda == null)
            {
                return false;
            }
            context.Remove(Venda);
            context.SaveChanges();
            return true;
        }

        public IEnumerable<Vendamaterial> GetAll()
        {
            return context.Vendamaterials.AsNoTracking();
        }

        public Vendamaterial? GetById(uint Id)
        {
            return context.Vendamaterials.Find(Id); 
        }

        public void Update(Vendamaterial Venda)
        {
            context.Update(Venda);
            context.SaveChanges();
        }
    }
}
