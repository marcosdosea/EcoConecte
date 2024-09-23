using System;
using System.Collections.Generic;

namespace Core;

public partial class Vendamaterial
{
    public uint Id { get; set; }

    public string Tipo { get; set; } = null!;

    public decimal Valor { get; set; }

    public decimal Quantidade { get; set; }

    public DateTime Data { get; set; }

    public uint IdCooperativa { get; set; }

    public uint IdPessoa { get; set; }
}
