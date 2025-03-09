using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Service
{
    public interface IAgendamentoService
    {
        /// <summary>
        /// Criar agendamento
        /// </summary>
        /// <param name="agendamento"></param>
        /// <returns></returns>
        uint Create(Agendamento agendamento);

        /// <summary>
        /// Editar um agendamento
        /// </summary>
        /// <param name="agendamento"></param>
        void Edit(Agendamento agendamento);

        /// <summary>
        /// Atualizar agendamento
        /// </summary>
        /// <param name="agendamento"></param>
        void Update(Agendamento agendamento);

        /// <summary>
        /// Deletar um agendamento
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        void Delete(uint id);

        /// <summary>
        /// Listar todos os agendamentos
        /// </summary>
        /// <returns></returns>
        IEnumerable<Agendamento> GetAll();

        /// <summary>
        /// Buscar agendamento por ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Agendamento ? GetById(uint id);

        Task<Agendamento?> ObterPorIdAsync(uint id);
        Task ExcluirAsync(uint id);

        Task<Agendamento> GetByIdAsync(uint id);

        Task<bool> UpdateAsync(Agendamento agendamento);
    }
}
