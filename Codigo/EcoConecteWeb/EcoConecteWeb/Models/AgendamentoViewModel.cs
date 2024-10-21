using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace EcoConecteWeb.Models
{
    public class AgendamentoViewModel
    {
        /// <summary>
        /// GET ID
        /// </summary>
        [Required(ErrorMessage = "Campo Obrigatório")]
        public uint Id { get; }

        /// <summary>
        /// GET/SET Data
        /// </summary>
        [Required(ErrorMessage = "Campo Obrigatório")]
        public DateTime Data { get; set; }

        /// <summary>
        /// GET/SET CEP
        /// </summary>
        [Required(ErrorMessage = "Campo Obrigatório")]
        [StringLength( 8,MinimumLength = 8,ErrorMessage ="O CEP deve conter 8 digitos")]
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
        [Display(Name = "Número")]
        public string Numero { get; set; } = null!;

        /// <summary>
        /// GET/SET Bairro
        /// </summary>
        [Required(ErrorMessage = "Campo Obrigatório")]
        public string Bairro { get; set; } = null!;

        /// <summary>
        /// GET/SET Cidade
        /// </summary>
        [Required(ErrorMessage = "Campo Obrigatório")]
        public string Cidade { get; set; } = null!;

        /// <summary>
        /// GET/SET Estado ex: SE, BA, SP
        /// </summary>
        [Required(ErrorMessage = "Campo Obrigatório")]
        public string Estado { get; set; } = null!;

        /// <summary>
        /// GET/SET
        /// Status A - Ativo
        ///        C - Cancelado
        /// </summary>
        [AllowNull]
        public string? Status { get; set; }

        /// <summary>
        /// GET/SET ID Pessoa
        /// </summary>
        public uint IdPessoa { get; set; }
    }
}
