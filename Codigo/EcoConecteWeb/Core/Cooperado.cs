using System;
using System.Collections.Generic;

namespace Core;

public partial class Cooperado
{
    public uint IdCooperado { get; set; }

    public string Nome { get; set; } = null!;

    public string Cpf { get; set; } = null!;

    public string? Telefone { get; set; }

    public virtual ICollection<Agendamento> Agendamentos { get; set; } = new List<Agendamento>();
}
