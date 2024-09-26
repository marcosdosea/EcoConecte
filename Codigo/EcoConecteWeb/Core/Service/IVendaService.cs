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

        void Update(Vendamaterial Venda);

        bool Delete(uint Id);

        IEnumerable<Vendamaterial> GetAll();

        Vendamaterial? GetById(uint Id);
    }
}
