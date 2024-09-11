using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Service
{
    public interface IAgendamentoService
    {
        int Create();

        int Edit();

        int Delete();

        Agendamento Get(int id);

        IEnumerable<Agendamento> GetAll();

        Agendamento GetById(int id);
    }
}
