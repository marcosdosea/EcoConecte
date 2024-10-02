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

        public uint Create(Agendamento agendamento)
        {
            _EcoConecteContext.Add(agendamento);
            _EcoConecteContext.SaveChanges();
            return agendamento.Id;
        }

        public bool Delete(uint id)
        {
            var agendamento = _EcoConecteContext.Agendamentos.Find(id);
            if (agendamento == null)
            {
                return false;
            }
            _EcoConecteContext.Remove(agendamento);
            _EcoConecteContext.SaveChanges();
            return true;
        }

        public IEnumerable<Agendamento> GetAll()
        {
            return _EcoConecteContext.Agendamentos.AsNoTracking();
        }

        public Agendamento? GetById(uint id)
        {
            return _EcoConecteContext.Agendamentos.Find(id);
        }

        public void Update(Agendamento agendamento)
        {
            _EcoConecteContext.Agendamentos.Update(agendamento);
            _EcoConecteContext.SaveChanges();
        }
    }
}
