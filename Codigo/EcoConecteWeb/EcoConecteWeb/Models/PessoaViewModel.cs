using System.ComponentModel.DataAnnotations;

namespace EcoConecteWeb.Models
{
    public class PessoaViewModel
    {
        /// <summary>
        /// GET ID
        /// </summary>
        [Key]
        public uint Id { get; }
        [Required(ErrorMessage = "Campo obrigatório.")]
        [StringLength(11)]
        public string Cpf { get; set; } = null!;
        [Required(ErrorMessage = "Campo obrigatório.")]
        [StringLength(45, ErrorMessage = "Nome deve ter no máximo 45 caracteres.")]
        public string Nome { get; set; } = null!;

        public string? Telefone { get; set; }

        public string? Logradouro { get; set; }

        public string? Bairro { get; set; }

        public string? Numero { get; set; }

        public string? Cidade { get; set; }

        public string? Estado { get; set; }

        public uint IdCooperativa { get; set; }

        /// <summary>
        /// A - ATIVO
        /// I - INATIVO
        /// </summary>
        public string Status { get; set; } = null!;
    }
}