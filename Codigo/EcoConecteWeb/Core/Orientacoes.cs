using System;
using System.Collections.Generic;

namespace Core;

public partial class Orientacoes
{
    /// <summary>
    /// GET/SET ID orientações
    /// </summary>
    public uint Id { get; set; }

    /// <summary>
    /// GET/SET Título para a orientação
    /// </summary>
    public string Titulo { get; set; } = null!;

    /// <summary>
    /// GET/SET Descrição
    /// </summary>
    public string Descricao { get; set; } = null!;

    /// <summary>
    /// GET/SET ID cooperativa atrelada a descrição
    /// </summary>
    public uint IdCooperativa { get; set; }
}
