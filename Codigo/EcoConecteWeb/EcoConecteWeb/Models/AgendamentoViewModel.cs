using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace EcoConecteWeb.Models
{
    public class AgendamentoViewModel
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
        [Display(Name = "Número")]
        public string Numero { get; set; } = null!;

        [Required(ErrorMessage = "Campo Obrigatório")]
        public string Bairro { get; set; } = null!;

        [Required(ErrorMessage = "Campo Obrigatório")]
        public string Cidade { get; set; } = null!;

        [Required(ErrorMessage = "Campo Obrigatório")]
        public string Estado { get; set; } = null!;

        [AllowNull]
        public string? Status { get; set; }

        public uint IdPessoa { get; set; }
    }
}
