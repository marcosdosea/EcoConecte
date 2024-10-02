using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Service
{
    public interface IOrientacoesService
    {
        uint Create(Orientacoes orientacoes);
        void Update(Orientacoes orientacoes);
        void Edit(Orientacoes orientacoes);
        void Delete(uint id);
        Orientacoes? GetById(uint id);
        IEnumerable<Orientacoes> GetAll();
        IEnumerable<Orientacoes> GetByTitulo(string titulo);

    }
}
