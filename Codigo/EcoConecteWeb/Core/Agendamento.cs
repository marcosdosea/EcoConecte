using System;
using System.Collections.Generic;

namespace Core;

public partial class Agendamento
{
    public uint IdAgendamento { get; set; }

    public DateTime Data { get; set; }

    public DateTime Horario { get; set; }

    public string Cep { get; set; } = null!;

    public string Logradouro { get; set; } = null!;

    public int NumeroEndereco { get; set; }

    public uint CidadaoIdCidadao { get; set; }

    public uint CooperadoIdCooperado { get; set; }

    public string CooperadoCpf { get; set; } = null!;

    public virtual Cidadao CidadaoIdCidadaoNavigation { get; set; } = null!;

    public virtual Cooperado Cooperado { get; set; } = null!;

    public virtual ICollection<Cooperativa> Cooperativas { get; set; } = new List<Cooperativa>();
}
