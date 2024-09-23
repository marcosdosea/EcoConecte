using System;
using System.Collections.Generic;

namespace Core;

public partial class Orientaco
{
    public uint Id { get; set; }

    public string Titulo { get; set; } = null!;

    public string Descricao { get; set; } = null!;

    public uint IdCooperativa { get; set; }
}
