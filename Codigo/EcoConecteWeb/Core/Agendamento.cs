using System;
using System.Collections.Generic;

namespace Core;

public partial class Agendamento
{

    /// <summary>
    /// GET/SET ID
    /// </summary>
    public uint Id { get; set; }

    /// <summary>
    /// GET/SET Data
    /// </summary>
    public DateTime Data { get; set; }

    /// <summary>
    /// GET/SET CEP
    /// </summary>
    public string Cep { get; set; } = null!;

    /// <summary>
    /// GET/SET Lagradouro
    /// </summary>
    public string Logradouro { get; set; } = null!;

    /// <summary>
    /// GET/SET Número
    /// </summary>
    public string Numero { get; set; } = null!;

    /// <summary>
    /// GET/SET ID Pessoa
    /// </summary>
    public uint IdPessoa { get; set; }

    /// <summary>
    /// GET/SET Bairro
    /// </summary>
    public string Bairro { get; set; } = null!;

    /// <summary>
    /// GET/SET Cidade
    /// </summary>
    public string Cidade { get; set; } = null!;

    /// <summary>
    /// GET/SET Estado
    /// </summary>
    public string Estado { get; set; } = null!;

    /// <summary>
    /// A - ATIVO
    /// C -CANCELADO
    /// </summary>
    public string? Status { get; set; }

    public virtual Pessoa IdPessoaNavigation { get; set; } = null!;
}
