using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace EcoConecteWeb.Models
{
    public class ColetaViewModel
    {
        /// <summary>
        /// GET ID
        /// </summary>
        [Display(Name = "Código Coleta")]
        [Required(ErrorMessage = "Campo Obrigatório")]
        [Key]
        public uint Id { get; set; }

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
        [StringLength(45)]
        public string Logradouro { get; set; } = null!;

        /// <summary>
        /// GET/SET Número
        /// </summary>
        [Required(ErrorMessage = "Campo Obrigatório")]
        public string Numero { get; set; } = null!;

        /// <summary>
        /// GET/SET Dia coleta
        /// </summary>
        [Required(ErrorMessage = "Campo Obrigatório")]
        [DataType(DataType.Date, ErrorMessage = "Data válida requerida")]
        public DateTime DiaColeta { get; set; }

        /// <summary>
        /// GET/SET Hora de início coleta
        /// </summary>
        [Display(Name = "Hora de Inicio da Coleta")]
        [Required(ErrorMessage = "Campo Obrigatório")]
        [DataType(DataType.Date, ErrorMessage = "Data válida requerida")]
        public DateTime HorarioInicio { get; set; }

        /// <summary>
        /// GET/SET Hora término coleta
        /// </summary>
        [Display(Name = "Hora de Termino da Coleta")]
        [Required(ErrorMessage = "Campo Obrigatório")]
        [DataType(DataType.Date, ErrorMessage = "Data válida requerida")]
        public DateTime HorarioTermino { get; set; }

        /// <summary>
        /// GET/SET ID cooperativa
        /// </summary>
        [Display(Name = "Código Cooperativa")]
        [Required(ErrorMessage = "Campo Obrigatório")]
        [Key]
        public uint IdCooperativa { get; set; }
    }
}
