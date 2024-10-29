using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Service
{
    public interface IColetaService
    {
        /// <summary>
        /// Criar uma coleta
        /// </summary>
        /// <param name="coleta"></param>
        /// <returns></returns>
        uint Create(Coleta coleta);

        /// <summary>
        /// Atualizar uma coleta
        /// </summary>
        /// <param name="coleta"></param>
        void Update(Coleta coleta);

        /// <summary>
        /// Editar uma coleta
        /// </summary>
        /// <param name="coleta"></param>
        void Edit(Coleta coleta);

        /// <summary>
        /// Deletar uma Coleta
        /// </summary>
        /// <param name="id"></param>
        void Delete(uint id);

        /// <summary>
        /// Buscar uma Coleta pelo ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Coleta? GetById(uint id);

        /// <summary>
        /// Listar N coletas
        /// </summary>
        /// <returns></returns>
        IEnumerable<Coleta> GetAll();

        /// <summary>
        /// Buscar Coleta pelo lagradouro
        /// </summary>
        /// <param name="lagradouro"></param>
        /// <returns></returns>
        IEnumerable<Coleta> GetByLagradouro(string lagradouro);

        IEnumerable<Coleta> GetByCep(string cep);
    }
}
