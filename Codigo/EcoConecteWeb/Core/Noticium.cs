using System;
using System.Collections.Generic;

namespace Core;

public partial class Noticium
{
    public uint IdNoticia { get; set; }

    public string Titulo { get; set; } = null!;

    public string Conteudo { get; set; } = null!;

    public virtual ICollection<Cooperativa> Cooperativas { get; set; } = new List<Cooperativa>();
}
