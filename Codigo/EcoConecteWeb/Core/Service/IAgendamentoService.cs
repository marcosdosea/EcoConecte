using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Service
{
    public interface IAgendamentoService
    {
        uint Create(Agendamento agendamento);

        void Update(Agendamento agendamento);

        bool Delete(uint id);

        IEnumerable<Agendamento> GetAll();

        Agendamento ? GetById(uint id);
    }
}
