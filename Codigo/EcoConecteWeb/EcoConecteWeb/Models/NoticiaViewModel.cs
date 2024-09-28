using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace EcoConecteWeb.Models
{
    public class NoticiaViewModel
    {
        [Display(Name = "Código")]
        [Key]
        [Required(ErrorMessage = "Campo obrigatório.")]
        public uint Id { get; set; }

        [Required(ErrorMessage = "Campo obrigatório.")]
        [StringLength(30)]
        public string Titulo { get; set; } = null!;

        [Required(ErrorMessage = "Campo obrigatório.")]
        public string Conteudo { get; set; } = null!;

        [Display(Name = "Código")]
        [Required(ErrorMessage = "Campo obrigatório.")]
        public string? IdCooperativa { get; set; } = null!;
        
        [Required(ErrorMessage = "Campo obrigatório.")]
        [DataType(DataType.Date, ErrorMessage = "Data válida requerida")]
        public string? Data { get; set; } = null! ;

    }
}
