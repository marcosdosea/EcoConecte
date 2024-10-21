using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace EcoConecteWeb.Models
{
    public class ColetaViewModel
    {
        /// <summary>
        /// GET ID
        /// </summary>
        [Display(Name = "Código")]
        [Required(ErrorMessage = "Campo Obrigatório")]
        public uint Id { get; }

        /// <summary>
        /// GET/SET CEP
        /// </summary>
        [Required(ErrorMessage = "Campo Obrigatório")]
        [StringLength(8, MinimumLength = 8, ErrorMessage = "O CEP deve conter 8 digitos")]
        public string Cep { get; set; } = null!;

        /// <summary>
        /// GET/SET Lagradouro
        /// </summary>
        [Required(ErrorMessage = "Campo Obrigatório")]
        public string Logradouro { get; set; } = null!;

        /// <summary>
        /// GET/SET Número
        /// </summary>
        [Required(ErrorMessage = "Campo Obrigatório")]
        [StringLength(4, MinimumLength = 4, ErrorMessage = "O Numero da casa deve conter 4 digitos")]
        public string Numero { get; set; } = null!;

        /// <summary>
        /// GET/SET Dia coleta
        /// </summary>
        [Required(ErrorMessage = "Campo Obrigatório")]
        public DateTime DiaColeta { get; set; }

        /// <summary>
        /// GET/SET Hora de início coleta
        /// </summary>
        [Display(Name = "Hora de Inicio da Coleta")]
        [Required(ErrorMessage = "Campo Obrigatório")]
        public DateTime HorarioInicio { get; set; }

        /// <summary>
        /// GET/SET Hora término coleta
        /// </summary>
        [Display(Name = "Hora de Termino da Coleta")]
        [Required(ErrorMessage = "Campo Obrigatório")]
        public DateTime HorarioTermino { get; set; }

        /// <summary>
        /// GET/SET ID cooperativa
        /// </summary>
        [Display(Name = "Código")]
        [Required(ErrorMessage = "Campo Obrigatório")]
        public uint IdCooperativa { get; set; }
    }
}
