using System;
using System.Collections.Generic;

namespace Core;

public partial class Cidadao
{
    public uint IdCidadao { get; set; }

    public string Cpf { get; set; } = null!;

    public string Nome { get; set; } = null!;

    public string? Telefone { get; set; }

    public string? Logradouro { get; set; }

    public string? Bairro { get; set; }

    public int? NumeroEndereco { get; set; }

    public string? Email { get; set; }

    public virtual ICollection<Agendamento> Agendamentos { get; set; } = new List<Agendamento>();
}
