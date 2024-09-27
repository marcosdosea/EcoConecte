using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace EcoConecteWeb.Models
{
    public class ColetaViewModel
    {
        [Required(ErrorMessage = "Campo Obrigatório")]
        public uint Id { get; set; }

        [Required(ErrorMessage = "Campo Obrigatório")]
        public DateTime Data { get; set; }

        [Required(ErrorMessage = "Campo Obrigatório")]
        [StringLength( 8,MinimumLength = 8,ErrorMessage ="O CEP deve conter 8 digitos")]
        public string Cep { get; set; } = null!;

        [Required(ErrorMessage = "Campo Obrigatório")]
        public string Logradouro { get; set; } = null!;

        [Required(ErrorMessage = "Campo Obrigatório")]
        [StringLength(4, MinimumLength = 4, ErrorMessage = "O Numero da casa deve conter 4 digitos")]
        [Display(Name = "Número da Residencia")]
        public string Numero da residencia { get; set; } = null!;


        [AllowNull]
        public string? Status { get; set; }
    }
}
