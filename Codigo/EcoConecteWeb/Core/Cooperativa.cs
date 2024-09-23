using System;
using System.Collections.Generic;

namespace Core;

public partial class Cooperativa
{
    public uint Id { get; set; }

    public string Nome { get; set; } = null!;

    public string InscricaoEstadual { get; set; } = null!;

    public string InscricaoMunicipal { get; set; } = null!;

    public string Cnpj { get; set; } = null!;

    public string Cep { get; set; } = null!;

    public string? Logradouro { get; set; }

    public string? Bairro { get; set; }

    public string? Numero { get; set; }

    public string? Telefone { get; set; }

    public string? Email { get; set; }

    public uint IdPessoaRepresentate { get; set; }

    /// <summary>
    /// A - ATIVO
    /// I - INATIVO
    /// </summary>
    public string Status { get; set; } = null!;
}
