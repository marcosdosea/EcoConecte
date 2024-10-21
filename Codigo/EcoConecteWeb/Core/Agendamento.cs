using System;
using System.Collections.Generic;

namespace Core;

public partial class Agendamento
{
    /// <summary>
    /// GET/SET ID - auto increment
    /// </summary>
    public uint Id { get; set; }

    /// <summary>
    /// GET/SET data
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
    /// GET/SET Número para o endereço
    /// </summary>
    public string Numero { get; set; } = null!;

    /// <summary>
    /// GET/SET ID - ID Pessoa cadastrada
    /// </summary>
    public uint IdPessoa { get; set; }

    /// <summary>
    /// GET/SET Bairro
    /// </summary>
    public string Bairro { get; set; } = null!;

    /// <summary>
    /// GET/SET Nome da Cidade
    /// </summary>
    public string Cidade { get; set; } = null!;

    /// <summary>
    /// GET/SET Estado - EX: SE, BA, SP e etc...
    /// </summary>
    public string Estado { get; set; } = null!;

    /// <summary>
    /// GET/SET
    /// A - ATIVO
    /// C -CANCELADO
    /// </summary>
    public string? Status { get; set; }
}
