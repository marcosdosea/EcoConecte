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
        
        private readonly ecoconecteContext _ecoconecteContext;

        public AgendamentoService(ecoconecteContext ecoconecteContext)
        {
            _ecoconecteContext = ecoconecteContext;
        }

        public uint Create(Agendamento agendamento)
        {
            _ecoconecteContext.Add(agendamento);
            _ecoconecteContext.SaveChanges();
            return agendamento.Id;
        }

        public bool Delete(uint id)
        {
            var agendamento = _ecoconecteContext.Agendamentos.Find(id);
            if (agendamento == null)
            {
                return false;
            }
            _ecoconecteContext.Remove(agendamento);
            _ecoconecteContext.SaveChanges();
            return true;
        }

        public IEnumerable<Agendamento> GetAll()
        {
            return _ecoconecteContext.Agendamentos.AsNoTracking();
        }

        public Agendamento? GetById(uint id)
        {
            return _ecoconecteContext.Agendamentos.Find(id);
        }

        public void Update(Agendamento agendamento)
        {
            _ecoconecteContext.Agendamentos.Update(agendamento);
            _ecoconecteContext.SaveChanges();
        }
    }
}
