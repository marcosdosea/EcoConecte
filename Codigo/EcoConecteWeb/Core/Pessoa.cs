using System;
using System.Collections.Generic;

namespace Core;

public partial class Pessoa
{
    public uint Id { get; set; }

    public string Cpf { get; set; } = null!;

    public string Nome { get; set; } = null!;

    public string? Telefone { get; set; }

    public string? Logradouro { get; set; }

    public string? Bairro { get; set; }

    public string? Numero { get; set; }

    public string? Cidade { get; set; }

    public string? Estado { get; set; }

    public uint IdCooperativa { get; set; }

    /// <summary>
    /// A - ATIVO
    /// I - INATIVO
    /// </summary>
    public string Status { get; set; } = null!;
}
