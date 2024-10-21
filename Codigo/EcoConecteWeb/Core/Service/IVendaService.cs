using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Service
{
    public interface IVendaService
    {
        uint Create(venda Venda);

        void Update(venda Venda);

        bool Delete(uint Id);
        //Vendamaterial? Get(uint id);

        IEnumerable<venda> GetAll();

        venda? GetById(uint Id);
    }
}
