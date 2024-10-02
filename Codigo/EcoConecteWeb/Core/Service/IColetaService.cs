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
        void Update(Coleta coleta);
        void Edit(Coleta coleta);
        void Delete(uint id);
        Coleta? GetById(uint id);
        IEnumerable<Coleta> GetAll();
        IEnumerable<Coleta> GetByLagradouro(string lagradouro);
    }
}
