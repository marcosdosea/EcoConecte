using System.ComponentModel.DataAnnotations;

namespace EcoConecteWeb.Models
{
    public class OrientacoesViewModel
    {
        [Display(Name = "Código")]
        [Key]
        [Required(ErrorMessage = "Campo obrigatório.")]
        public uint Id { get; set; }

        [Required(ErrorMessage = "Campo obrigatório.")]
        [StringLength(30)]
        public string Titulo { get; set; } = null!;

        public string Descricao { get; set; } = null!;

        [Display(Name = "Código")]
        [Required(ErrorMessage = "Campo obrigatório.")]
        public string? IdCooperativa { get; set; } = null!;

    }
}
