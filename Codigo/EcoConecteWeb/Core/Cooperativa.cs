using System;
using System.Collections.Generic;

namespace Core;

public partial class Cooperativa
{
    /// <summary>
    /// GET/SET ID
    /// </summary>
    public uint Id { get; set; }

    /// <summary>
    /// GET/SET Nome
    /// </summary>
    public string Nome { get; set; } = null!;

    /// <summary>
    /// GET/SET Inscriçao Estadual
    /// </summary>
    public string InscricaoEstadual { get; set; } = null!;

    /// <summary>
    /// GET/SET Inscriçao Municipal
    /// </summary>
    public string InscricaoMunicipal { get; set; } = null!;

    /// <summary>
    /// GET/SET CNPJ
    /// </summary>
    public string Cnpj { get; set; } = null!;

    /// <summary>
    /// GET/SET CEP
    /// </summary>
    public string Cep { get; set; } = null!;

    /// <summary>
    /// GET/SET Lagradouro
    /// </summary>
    public string? Logradouro { get; set; }

    /// <summary>
    /// GET/SET Bairro
    /// </summary>
    public string? Bairro { get; set; }

    /// <summary>
    /// GET/SET Número
    /// </summary>
    public string? Numero { get; set; }

    /// <summary>
    /// GET/SET Telefone
    /// </summary>
    public string? Telefone { get; set; }

    /// <summary>
    /// GET/SET Email
    /// </summary>
    public string? Email { get; set; }

    /// <summary>
    /// GET/SET ID Pessoa Representante
    /// </summary>
    public uint IdPessoaRepresentate { get; set; }

    /// <summary>
    /// A - ATIVO
    /// I - INATIVO
    /// </summary>
    public string Status { get; set; } = null!;

    /// <summary>
    /// GET/SET ID Pessoa Representante
    /// </summary>
    public virtual Pessoa IdPessoaRepresentateNavigation { get; set; } = null!;
}
