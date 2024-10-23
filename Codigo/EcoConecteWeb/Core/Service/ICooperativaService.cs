using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Service
{
    public interface ICooperativaService
    {
        /// <summary>
        /// Atualizar cooperativa
        /// </summary>
        /// <param name="cooperativa"></param>
        void Update(Cooperativa cooperativa);

        /// <summary>
        /// Criar uma cooperativa
        /// </summary>
        /// <param name="cooperativa"></param>
        /// <returns></returns>
        uint Create(Cooperativa cooperativa);

        /// <summary>
        /// Buscar cooperativa por ID
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        Cooperativa? Get(uint Id);

        /// <summary>
        /// Deletar uma cooperativa
        /// </summary>
        /// <param name="Id"></param>
        void Delete(uint Id);

        /// <summary>
        /// Lista todas as cooperativas
        /// </summary>
        /// <returns></returns>
        IEnumerable<Cooperativa> GetAll();

    }
}
