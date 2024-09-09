using System;
using System.Collections.Generic;

namespace Core;

public partial class Vendamaterial
{
    public uint IdVendaMaterial { get; set; }

    public string Tipo { get; set; } = null!;

    public decimal Valor { get; set; }

    public decimal QuantidadeVendida { get; set; }

    public DateTime? Data { get; set; }

    public uint CooperadoIdCooperado { get; set; }

    public string CooperadoCpf { get; set; } = null!;

    public virtual ICollection<Cooperativa> Cooperativas { get; set; } = new List<Cooperativa>();
}
