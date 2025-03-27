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
        uint Create(Venda Venda);

        /// <summary>
        /// Atualiza dados de uma venda
        /// </summary>
        /// <param name="Venda"></param>
        void Update(Venda Venda);

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
        IEnumerable<Venda> GetAll();

        /// <summary>
        /// Busca venda pelo ID
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        Venda? GetById(uint Id);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<Venda> ObterPorIdAsync(uint id);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="venda"></param>
        /// <returns></returns>
        Task<bool> AtualizarAsync(Venda venda);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<bool> ExcluirAsync(uint id);
    }
}
