using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Dto
{
    public class ColetaDto
    {
        public uint Id { get; set; }
        public string Logradouro { get; set; } = null!;
        public DateTime Data { get; set; }
    }
}
