using System;
using System.Collections.Generic;

namespace Core;

public partial class Pessoa
{
    /// <summary>
    /// GET/SET ID Pessoa
    /// </summary>
    public uint Id { get; set; }

    /// <summary>
    /// GET/SET CPF xxxxxxxxxx
    /// </summary>
    public string Cpf { get; set; } = null!;

    /// <summary>
    /// GET/SET Nome para a pessoa
    /// </summary>
    public string Nome { get; set; } = null!;

    /// <summary>
    /// GET/SET Telefone
    /// </summary>
    public string? Telefone { get; set; }

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
    /// GET/SET Cidade
    /// </summary>
    public string? Cidade { get; set; }

    /// <summary>
    /// GET/SET Estado ex: SE, BA, SP e etc.
    /// </summary>
    public string? Estado { get; set; }

    /// <summary>
    /// GET/SET ID Cooperativa
    /// </summary>
    public uint IdCooperativa { get; set; }

    /// <summary>
    /// GET/SET
    /// A - ATIVO
    /// I - INATIVO
    /// </summary>
    public string Status { get; set; } = null!;
}
