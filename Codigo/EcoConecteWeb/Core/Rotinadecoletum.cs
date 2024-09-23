using System;
using System.Collections.Generic;

namespace Core;

public partial class Rotinadecoletum
{
    public uint Id { get; set; }

    public string Cep { get; set; } = null!;

    public string Logradouro { get; set; } = null!;

    public int Numero { get; set; }

    public DateTime DiaColeta { get; set; }

    public DateTime? HorarioInicio { get; set; }

    public DateTime? HorarioTermino { get; set; }

    public uint IdCooperativa { get; set; }
}
