using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Dto
{
    public class ColetaDto
    {

        /// <summary>
        /// GET/SET ID
        /// </summary>
        public uint Id { get; set; }

        /// <summary>
        /// GET/SET Lagradouro
        /// </summary>
        public string Logradouro { get; set; } = null!;

        /// <summary>
        /// GET/SET Data
        /// </summary>
        public DateTime Data { get; set; }
    }
}
