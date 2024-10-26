using System.ComponentModel.DataAnnotations;

namespace EcoConecteWeb.Models
{
    public class OrientacoesViewModel
    {
        /// <summary>
        /// GET ID
        /// </summary>
        [Display(Name = "Código Orientaçao")]
        [Key]
        public uint Id { get; set; }

        /// <summary>
        /// GET/SET Título
        /// </summary>
        [Required(ErrorMessage = "Campo obrigatório.")]
        [StringLength(100)]
        public string Titulo { get; set; } = null!;

        /// <summary>
        /// GET/SET Descriçao
        /// </summary>
        [Required(ErrorMessage = "Campo obrigatório.")]
        [StringLength(2000)]
        public string Descricao { get; set; } = null!;

        /// <summary>
        /// GET/SET ID cooperativa
        /// </summary>
        [Display(Name = "Código Cooperativa")]
        [Required(ErrorMessage = "Campo obrigatório.")]
        [Key]
        public string? IdCooperativa { get; set; } = null!;

    }
}
