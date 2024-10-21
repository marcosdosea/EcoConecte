using System;
using System.Collections.Generic;

namespace Core;

public partial class Cooperativa
{
    /// <summary>
    /// GET/SET ID da cooperativa
    /// </summary>
    public uint Id { get; set; }

    /// <summary>
    /// GET/SET Nome da cooperativa
    /// </summary>
    public string Nome { get; set; } = null!;

    /// <summary>
    /// GET/SET Inscriç±ao Estadual
    /// </summary>
    public string InscricaoEstadual { get; set; } = null!;

    /// <summary>
    /// GET/SET Inscriç±ao Municipal
    /// </summary>
    public string InscricaoMunicipal { get; set; } = null!;

    /// <summary>
    /// GET/SET CNPJ da cooperativa
    /// </summary>
    public string Cnpj { get; set; } = null!;

    /// <summary>
    /// GET/SET CEP da cooperativa
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
    /// GET/SET Telefone fixo
    /// </summary>
    public string? Telefone { get; set; }

    /// <summary>
    /// GET/SET Email xxx@xxx.com
    /// </summary>
    public string? Email { get; set; }

    /// <summary>
    /// GET/SET ID Pessoa Representante
    /// </summary>
    public uint IdPessoaRepresentate { get; set; }

    /// <summary>
    /// GET/SET
    /// A - ATIVO
    /// I - INATIVO
    /// </summary>
    public string Status { get; set; } = null!;
}
