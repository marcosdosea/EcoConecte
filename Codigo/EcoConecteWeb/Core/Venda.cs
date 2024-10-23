using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Core;

public partial class venda
{
    /// <summary>
    /// GET/SET ID - auto incremente
    /// </summary>
    public uint Id { get; set; }

    /// <summary>
    /// GET/SET Tipo M ou P
    /// </summary>
    public string Tipo { get; set; } = null!;

    /// <summary>
    /// GET/SET Valor em real
    /// </summary>
    public decimal Valor { get; set; }
    /// <summary>
    /// GET/SET Quantidade
    /// </summary>
    public int Quantidade { get; set; }

    /// <summary>
    /// GET/SET Data da venda
    /// </summary>
    public DateTime Data { get; set; }

    /// <summary>
    /// GET/SET ID cooperativa
    /// </summary>
    public uint IdCooperativa { get; set; }

    /// <summary>
    /// GET/SET ID pessoa
    /// </summary>
    public uint IdPessoa { get; set; }

    /// <summary>
    /// GET/SET ID Pessoa
    /// </summary>
    public Pessoa IdPessoaNavigation { get; set; } = null!;
}
