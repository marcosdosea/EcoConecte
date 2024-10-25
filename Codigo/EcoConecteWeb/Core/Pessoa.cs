using System;
using System.Collections.Generic;

namespace Core;

public partial class Pessoa
{
    /// <summary>
    /// GET/SET ID
    /// </summary>
    public uint Id { get; set; }

    /// <summary>
    /// GET/SET CPF
    /// </summary>
    public string Cpf { get; set; } = null!;

    /// <summary>
    /// GET/SET Nome
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
    /// GET/SET Estado
    /// </summary>
    public string? Estado { get; set; }

    /// <summary>
    /// GET/SET ID Cooperativa
    /// </summary>
    public uint? IdCooperativa { get; set; }

    /// <summary>
    /// A - ATIVO
    /// I - INATIVO
    /// </summary>
    public string Status { get; set; } = null!;

    /// <summary>
    /// GET/SET Agendamentos
    /// </summary>
    public virtual ICollection<Agendamento> Agendamentos { get; set; } = new List<Agendamento>();

    /// <summary>
    /// GET/SET Cooperativa
    /// </summary>
    public virtual ICollection<Cooperativa> Cooperativas { get; set; } = new List<Cooperativa>();

    /// <summary>
    /// GET/SET Vendas Material
    /// </summary>
    public virtual ICollection<Venda> Vendamaterials { get; set; } = new List<Venda>();
}
