using System.ComponentModel.DataAnnotations;

namespace EcoConecteWeb.Models
{
    public class PessoaViewModel
    {
        /// <summary>
        /// GET/SET ID Pessoa
        /// </summary>
        [Display(Name = "Código Pessoa")]
        [Key]
        [Required(ErrorMessage = "Campo obrigatório.")]
        public uint Id { get; set; }

        /// <summary>
        /// GET/SET CPF
        /// </summary>
        [Required(ErrorMessage = "Campo obrigatório.")]
        [StringLength(11, MinimumLength = 11, ErrorMessage = "O CPF deve conter 11 digitos")]
        public string Cpf { get; set; } = null!;

        /// <summary>
        /// GET/SET Nome
        /// </summary>
        [Required(ErrorMessage = "Campo obrigatório.")]
        [StringLength(45, ErrorMessage = "Nome deve ter no máximo 45 caracteres.")]
        public string Nome { get; set; } = null!;

        /// <summary>
        /// GET/SET Telefone
        /// </summary>
        [Required(ErrorMessage = "Campo obrigatório.")]
        [StringLength(9, ErrorMessage = "Telefone deve ter 9 digitos.")]
        public string? Telefone { get; set; }

        /// <summary>
        /// GET/SET Lagradouro
        /// </summary>
        [Required(ErrorMessage = "Campo obrigatório.")]
        [StringLength(45)]
        public string? Logradouro { get; set; }

        /// <summary>
        /// GET/SET Bairro
        /// </summary>
        [Required(ErrorMessage = "Campo obrigatório.")]
        [StringLength(45)]
        public string? Bairro { get; set; }

        /// <summary>
        /// GET/SET Número
        /// </summary>
        [Required(ErrorMessage = "Campo obrigatório.")]
        public string? Numero { get; set; }

        /// <summary>
        /// GET/SET Cidade
        /// </summary>
        [Required(ErrorMessage = "Campo obrigatório.")]
        [StringLength(45)]
        public string? Cidade { get; set; }

        /// <summary>
        /// GET/SET Estado
        /// </summary>
        [Required(ErrorMessage = "Campo obrigatório. EX: SE, BA, SP")]
        [StringLength(2)]
        public string? Estado { get; set; }

        /// <summary>
        /// GET/SET ID Cooperativa
        /// </summary>
        [Display(Name = "Código Cooperativa")]
        [Key]
        public uint? IdCooperativa { get; set; }

        /// <summary>
        /// A - ATIVO
        /// I - INATIVO
        /// </summary>
        [Required(ErrorMessage = "Campo obrigatório. EX: A - Ativo, I - Inativo")]
        [StringLength(2)]
        public string Status { get; set; } = null!;
    }
}