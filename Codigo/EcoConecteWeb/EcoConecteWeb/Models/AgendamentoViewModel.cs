using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace EcoConecteWeb.Models
{
    public class AgendamentoViewModel
    {
        /// <summary>
        /// GET/SET ID Agendamento
        /// </summary>
        [Required(ErrorMessage = "Campo Obrigatório")]
        [Display(Name = "Código Agendamento")]
        [Key]
        public uint Id { get; set; }


        /// <summary>
        /// GET/SET ID Pessoa
        /// </summary>
        [Required(ErrorMessage = "Campo Obrigatório")]
        [Display(Name = "Código Pessoa")]
        [Key]
        public uint IdPessoa { get; set; }

        /// <summary>
        /// GET/SET Data
        /// </summary>
        [Required(ErrorMessage = "Campo Obrigatório")]
        [DataType(DataType.Date, ErrorMessage = "Data válida requerida")]
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
        [StringLength(45)]
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
        [StringLength(45)]
        public string Bairro { get; set; } = null!;

        /// <summary>
        /// GET/SET Cidade
        /// </summary>
        [Required(ErrorMessage = "Campo Obrigatório")]
        [StringLength(45)]
        public string Cidade { get; set; } = null!;

        /// <summary>
        /// GET/SET Estado ex: SE, BA, SP
        /// </summary>
        [Required(ErrorMessage = "Campo Obrigatório, EX: SP, SE, BA")]
        [StringLength(2)]
        public string Estado { get; set; } = null!;

        /// <summary>
        /// GET/SET
        /// Status A - Ativo
        ///        C - Cancelado
        /// </summary>
        [Required(ErrorMessage = "Campo Obrigatório, EX: A - Ativo ou C - Cancelado")]
        [StringLength(1)]
        public string? Status { get; set; }
    }
}