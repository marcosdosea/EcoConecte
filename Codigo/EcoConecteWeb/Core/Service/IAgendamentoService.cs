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
        /// Atualizar agendamento
        /// </summary>
        /// <param name="agendamento"></param>
        void Update(Agendamento agendamento);

        /// <summary>
        /// Deletar um agendamento
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        bool Delete(uint id);

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
    }
}
