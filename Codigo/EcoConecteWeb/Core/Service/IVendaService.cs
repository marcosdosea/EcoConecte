using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Service
{
    public interface IVendaService
    {
        uint Create(Vendamaterial Venda);

        void Edit(Vendamaterial Venda);

        void Delete(uint Id);
        Vendamaterial? Get(uint id);

        IEnumerable<Vendamaterial> GetAll();

        Vendamaterial? GetById(uint Id);
    }
}
