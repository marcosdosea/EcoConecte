using System;
using System.Collections.Generic;

namespace Core;

public partial class Coleta
{
    /// <summary>
    /// GET/SET ID da coleta
    /// </summary>
    public uint Id { get; set; }

    /// <summary>
    /// GET/SET CEP
    /// </summary>
    public string Cep { get; set; } = null!;

    /// <summary>
    /// GET/SET Lagradouro
    /// </summary>
    public string Logradouro { get; set; } = null!;

    /// <summary>
    /// GET/SET Número do local
    /// </summary>
    public int Numero { get; set; }

    /// <summary>
    /// GET/SET Data para a coleta
    /// </summary>
    public DateTime DiaColeta { get; set; }

    /// <summary>
    /// GET/SET Hora para início coleta
    /// </summary>
    public DateTime? HorarioInicio { get; set; }

    /// <summary>
    /// GET/SET Hora para o fim da coleta
    /// </summary>
    public DateTime? HorarioTermino { get; set; }

    /// <summary>
    /// GET/SET ID da cooperativa
    /// </summary>
    public uint IdCooperativa { get; set; }
}
