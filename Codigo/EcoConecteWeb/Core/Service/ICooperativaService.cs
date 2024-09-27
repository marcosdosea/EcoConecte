using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Service
{
    public interface ICooperativaService
    {

        void Update(Cooperativa cooperativa);

        uint Create(Cooperativa cooperativa);

        Cooperativa? Get(uint Id);

        void Delete(uint Id);

    }
}
