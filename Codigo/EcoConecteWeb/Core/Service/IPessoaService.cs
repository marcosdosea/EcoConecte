using Core.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Service
{
    public interface IPessoaService
    {
        /// <summary>
        /// Cria cadastro pessoa
        /// </summary>
        /// <param name="pessoa"></param>
        /// <returns></returns>
        uint Create(Pessoa pessoa);

        /// <summary>
        /// Edita cadastro pessoa
        /// </summary>
        /// <param name="pessoa"></param>
        void Edit(Pessoa pessoa);

        /// <summary>
        /// Deleta cadastro pessoa
        /// </summary>
        /// <param name="id"></param>
        void Delete(uint id);

        /// <summary>
        /// Busca pessoa pelo ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Pessoa? Get(uint id);

        /// <summary>
        /// Lista N cadastro pessoa
        /// </summary>
        /// <returns></returns>
        IEnumerable<Pessoa> GetAll();

        /// <summary>
        /// Busca pessoa pelo nome
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        IEnumerable<PessoaDto> GetByName(string name);

    }
}
