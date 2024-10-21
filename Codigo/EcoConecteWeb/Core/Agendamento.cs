using System;
using System.Collections.Generic;

namespace Core;

public partial class Agendamento
{
    public uint Id { get; set; }

    public DateTime Data { get; set; }

    public string Cep { get; set; } = null!;

    public string Logradouro { get; set; } = null!;

    public string Numero { get; set; } = null!;

    public uint IdPessoa { get; set; }

    public string Bairro { get; set; } = null!;

    public string Cidade { get; set; } = null!;

    public string Estado { get; set; } = null!;

    /// <summary>
    /// A - ATIVO
    /// C -CANCELADO
    /// </summary>
    public string? Status { get; set; }

    public virtual Pessoa IdPessoaNavigation { get; set; } = null!;
}
