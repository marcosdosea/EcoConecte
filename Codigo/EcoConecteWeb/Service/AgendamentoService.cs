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
    public class AgendamentoService : IAgendamentoService
    {

        private readonly EcoConecteContext _EcoConecteContext;

        public AgendamentoService(EcoConecteContext EcoConecteContext)
        {
            _EcoConecteContext = EcoConecteContext;
        }

        /// <summary>
        /// Criar agendamento
        /// </summary>
        /// <param name="agendamento"></param>
        /// <returns></returns>
        public uint Create(Agendamento agendamento)
        {
            _EcoConecteContext.Add(agendamento);
            _EcoConecteContext.SaveChanges();
            return agendamento.Id;
        }

        /// <summary>
        /// Deletar agendamento
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public void Delete(uint id)
        {
            var agendamento = _EcoConecteContext.Agendamentos.Find(id);
            if (agendamento != null)
                _EcoConecteContext.Remove(agendamento);
                _EcoConecteContext.SaveChanges();
        }

        public void Edit(Agendamento agendamento)
        {
            _EcoConecteContext.Update(agendamento);
            _EcoConecteContext.SaveChanges();
        }


        /// <summary>
        /// Listar agendamentos
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Agendamento> GetAll()
        {
            return _EcoConecteContext.Agendamentos.AsNoTracking();
        }

        /// <summary>
        /// Buscar agendamento por ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Agendamento? GetById(uint id)
        {
            return _EcoConecteContext.Agendamentos.Find(id);
        }

        /// <summary>
        /// Atualizar agendamento
        /// </summary>
        /// <param name="agendamento"></param>
        public void Update(Agendamento agendamento)
        {
            _EcoConecteContext.Agendamentos.Update(agendamento);
            _EcoConecteContext.SaveChanges();
        }
    }
}
