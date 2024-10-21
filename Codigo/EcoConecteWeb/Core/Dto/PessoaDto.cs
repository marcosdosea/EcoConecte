using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Dto
{
    public class PessoaDto
    {
        /// <summary>
        /// GET/SET ID
        /// </summary>
        public uint IdPessoa { get; set; }

        /// <summary>
        /// GET/SET Nome
        /// </summary>
        public string? Nome { get; set; }
    }
}
