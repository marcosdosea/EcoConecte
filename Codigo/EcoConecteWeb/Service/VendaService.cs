using Core;
using Core.Service;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Service
{
    public class VendaService : IVendaService
    {
        private readonly EcoConecteContext context;
        public VendaService(EcoConecteContext context)
        {
            this.context = context;
        }

        /// <summary>
        /// Criar uma venda
        /// </summary>
        /// <param name="Venda"></param>
        /// <returns></returns>
        public uint Create(Venda Venda)
        {
            context.Add(Venda);
            context.SaveChanges();
            return Venda.Id;
        }

        /// <summary>
        /// Apagar uma venda
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Listar vendas
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Venda> GetAll()
        {
            return context.Vendamaterials.AsNoTracking();
        }

        /// <summary>
        /// Buscar venda pelo ID
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public Venda? GetById(uint Id)
        {
            return context.Vendamaterials.Find(Id); 
        }

        /// <summary>
        /// Atualizar uma venda
        /// </summary>
        /// <param name="Venda"></param>
        public void Update(Venda Venda)
        {
            context.Update(Venda);
            context.SaveChanges();
        }

        public async Task<Venda> ObterPorIdAsync(uint id)
        {
            var vendas = await context.Vendamaterials.FindAsync(id);
            if (vendas == null) return null;

            return new Venda
            {
                Id = vendas.Id,
                Tipo = vendas.Tipo,
                Valor = vendas.Valor,
                Quantidade = vendas.Quantidade,
                Data = vendas.Data,
                IdPessoa = vendas.IdPessoa
            };
        }

        public async Task<bool> AtualizarAsync(Venda venda)
        {
            var vendas = await context.Vendamaterials.FindAsync(venda.Id);
            if (vendas == null) return false;

            vendas.Tipo = venda.Tipo;
            vendas.Valor = venda.Valor;
            vendas.Quantidade = venda.Quantidade;
            vendas.Data = venda.Data;
            vendas.IdPessoa = venda.IdPessoa;

            context.Vendamaterials.Update(vendas);
            return await context.SaveChangesAsync() > 0;
        }

        public async Task<bool> ExcluirAsync(uint id)
        {
            var vendas = await context.Vendamaterials.FindAsync(id);
            if (vendas == null) return false;

            context.Remove(vendas);
            return await context.SaveChangesAsync() > 0;
        }

    }
}
