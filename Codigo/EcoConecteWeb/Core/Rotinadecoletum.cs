using System;
using System.Collections.Generic;

namespace Core;

public partial class Rotinadecoletum
{
    public uint IdRotinaDeColeta { get; set; }

    public string Cep { get; set; } = null!;

    public string Logradouro { get; set; } = null!;

    public int NumeroEndereco { get; set; }

    public DateTime DiaColeta { get; set; }

    public DateTime? HorarioInicio { get; set; }

    public DateTime? HorarioTermino { get; set; }

    public virtual ICollection<Cooperativa> Cooperativas { get; set; } = new List<Cooperativa>();
}
