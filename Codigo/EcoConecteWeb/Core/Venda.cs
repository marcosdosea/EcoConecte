using System;
using System.Collections.Generic;

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
    public string Valor { get; set; } = null!;

    /// <summary>
    /// GET/SET Quantidade
    /// </summary>
    public string Quantidade { get; set; } = null!;

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
}
