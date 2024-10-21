using System;
using System.Collections.Generic;

namespace Core;

public partial class Noticia
{
    /// <summary>
    /// GET/SET ID da notícia
    /// </summary>
    public uint Id { get; set; }

    /// <summary>
    /// GET/SET Título para a notícia
    /// </summary>
    public string Titulo { get; set; } = null!;

    /// <summary>
    /// GET/SET Conteúdo para a noticia
    /// </summary>
    public string Conteudo { get; set; } = null!;

    /// <summary>
    /// GET/SET ID cooperativa atrelada a notícia
    /// </summary>
    public uint IdCooperativa { get; set; }

    /// <summary>
    /// GET/SET Data para a notícia
    /// </summary>
    public DateTime Data { get; set; }
}
