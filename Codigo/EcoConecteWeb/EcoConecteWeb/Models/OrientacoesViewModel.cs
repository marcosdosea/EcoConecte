using System.ComponentModel.DataAnnotations;

namespace EcoConecteWeb.Models
{
    public class OrientacoesViewModel
    {
        /// <summary>
        /// GET ID
        /// </summary>
        [Display(Name = "Código")]
        [Key]
        [Required(ErrorMessage = "Campo obrigatório.")]
        public uint Id { get; }

        /// <summary>
        /// GET/SET Título
        /// </summary>
        [Required(ErrorMessage = "Campo obrigatório.")]
        [StringLength(30)]
        public string Titulo { get; set; } = null!;

        /// <summary>
        /// GET/SET Descriçao
        /// </summary>
        public string Descricao { get; set; } = null!;

        /// <summary>
        /// GET/SET ID cooperativa
        /// </summary>
        [Display(Name = "Código")]
        [Required(ErrorMessage = "Campo obrigatório.")]
        public string? IdCooperativa { get; set; } = null!;

    }
}
