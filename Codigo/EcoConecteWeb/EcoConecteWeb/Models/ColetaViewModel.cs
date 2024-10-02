using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace EcoConecteWeb.Models
{
    public class ColetaViewModel
    {
        [Display(Name = "Código")]
        [Required(ErrorMessage = "Campo Obrigatório")]
        public uint Id { get; set; }

        [Required(ErrorMessage = "Campo Obrigatório")]
        [StringLength(8, MinimumLength = 8, ErrorMessage = "O CEP deve conter 8 digitos")]
        public string Cep { get; set; } = null!;

        [Required(ErrorMessage = "Campo Obrigatório")]
        public string Logradouro { get; set; } = null!;

        [Required(ErrorMessage = "Campo Obrigatório")]
        [StringLength(4, MinimumLength = 4, ErrorMessage = "O Numero da casa deve conter 4 digitos")]
        public string Numero { get; set; } = null!;

        [Required(ErrorMessage = "Campo Obrigatório")]
        public DateTime DiaColeta { get; set; }

        [Display(Name = "Hora de Inicio da Coleta")]
        [Required(ErrorMessage = "Campo Obrigatório")]
        public DateTime HorarioInicio { get; set; }

        [Display(Name = "Hora de Termino da Coleta")]
        [Required(ErrorMessage = "Campo Obrigatório")]
        public DateTime HorarioTermino { get; set; }

        [Display(Name = "Código")]
        [Required(ErrorMessage = "Campo Obrigatório")]
        public uint IdCooperativa { get; set; }
    }
}
