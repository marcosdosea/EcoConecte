using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace EcoConecteWeb.Models
{
    public class NoticiaViewModel
    {
        /// <summary>
        /// GET ID
        /// </summary>
        [Display(Name = "Código Notícia")]
        [Key]
        public uint Id { get; set; }

        /// <summary>
        /// GET/SET Titulo para a noticia
        /// </summary>
        [Required(ErrorMessage = "Campo obrigatório.")]
        [StringLength(100)]
        public string Titulo { get; set; } = null!;

        /// <summary>
        /// GET/SET Conteúdo notícia
        /// </summary>
        [Required(ErrorMessage = "Campo obrigatório.")]
        [StringLength(2000)]
        public string Conteudo { get; set; } = null!;

        /// <summary>
        /// GET/SET ID Cooperativa
        /// </summary>
        [Key]
        [Display(Name = "Código Cooperativa")]
        [Required(ErrorMessage = "Campo obrigatório.")]
        public string? IdCooperativa { get; set; } = null!;

        /// <summary>
        /// GET/SET Data para a notícia
        /// </summary>
        [Required(ErrorMessage = "Campo obrigatório.")]
        [DataType(DataType.Date, ErrorMessage = "Data válida requerida")]
        public string? Data { get; set; } = null! ;

    }
}
