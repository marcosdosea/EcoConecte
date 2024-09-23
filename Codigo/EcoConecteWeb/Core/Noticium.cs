using System;
using System.Collections.Generic;

namespace Core;

public partial class Noticium
{
    public uint Id { get; set; }

    public string Titulo { get; set; } = null!;

    public string Conteudo { get; set; } = null!;

    public uint IdCooperativa { get; set; }

    public DateTime Data { get; set; }
}
