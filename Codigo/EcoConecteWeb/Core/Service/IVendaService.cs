using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Service
{
    public interface IVendaService
    {

        /// <summary>
        /// Cria uma venda
        /// </summary>
        /// <param name="Venda"></param>
        /// <returns></returns>
        uint Create(venda Venda);

        /// <summary>
        /// Atualiza dados de uma venda
        /// </summary>
        /// <param name="Venda"></param>
        void Update(venda Venda);

        /// <summary>
        /// Deleta uma venda
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        bool Delete(uint Id);
        //Vendamaterial? Get(uint id);

        /// <summary>
        /// Lista N vendas
        /// </summary>
        /// <returns></returns>
        IEnumerable<venda> GetAll();

        /// <summary>
        /// Busca venda pelo ID
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        venda? GetById(uint Id);
    }
}
