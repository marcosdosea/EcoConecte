using System;
using System.Collections.Generic;

namespace Core;

public partial class Orientaco
{
    public uint IdOrientacoes { get; set; }

    public string Titulo { get; set; } = null!;

    public string Descricao { get; set; } = null!;

    public virtual ICollection<Cooperativa> Cooperativas { get; set; } = new List<Cooperativa>();
}
