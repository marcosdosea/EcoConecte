using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Service
{
    public interface IColetaService
    {
        uint Create(Coleta coleta);
        bool Delete(uint id);
        IEnumerable<Coleta> GetAll();
        Coleta? GetById(uint id);
        void Update(Coleta coleta);
    }
}
