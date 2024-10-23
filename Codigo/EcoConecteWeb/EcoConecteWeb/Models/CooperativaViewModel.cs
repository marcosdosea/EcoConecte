using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EcoConecteWeb.Models
{
    public class CooperativaViewModel
    {
        /// <summary>
        /// GET ID
        /// </summary>
        [Display(Name = "Código Cooperativa")]
        [Key]
        [Required(ErrorMessage = "Campo requerido")]
        public int Id { get; set; }

        /// <summary>
        /// GET/SET Nome
        /// </summary>
        [Display(Name ="Nome da cooperativa")]
        [Required(ErrorMessage = "Campo requerido")]
        [StringLength(45,MinimumLength=5,ErrorMessage = "Nome da cooperativa deve ter entre 5 e 45 caracteres")]
        public string Nome { get; set; } = null!;

        /// <summary>
        /// GET/SET Número inscriçao estadual
        /// </summary>
        [Required(ErrorMessage = "Campo requerido")]
        [Display(Name ="Inscrição Estadual")]
        [StringLength(9,MinimumLength =9,ErrorMessage ="Inscrição estadual deve possuir 9 dígitos ")]
        public string InscricaoEstadual { get; set; } = null!;

        /// <summary>
        /// GET/SET Número inscriçao municipal
        /// </summary>
        [Required(ErrorMessage = "Campo requerido")]
        [Display(Name ="Inscrição Municipal")]
        [StringLength(9,MinimumLength =9,ErrorMessage ="Inscrição municipal deve possuir 9 dígitos")]
        public string InscricaoMunicipal { get; set; } = null!;

        /// <summary>
        /// GET/SET CNPJ 00.000.000/0000-00
        /// </summary>
        [Display(Name = "CNPJ")]
        [Required(ErrorMessage = "Campo requerido")]
        [StringLength(14,MinimumLength =14,ErrorMessage =" CNPJ deve ser composto por 14 dígitos ")]
        public string Cnpj { get; set; } = null!;

        /// <summary>
        /// GET/SET CEP
        /// </summary>
        [Display(Name = "CEP")]
        [Required(ErrorMessage = "Campo requerido")]
        [StringLength(8, MinimumLength = 8, ErrorMessage = " CEP deve ser composto por 8 dígitos ")]
        public string Cep { get; set; } = null!;

        /// <summary>
        /// GET/SET Lagradouro
        /// </summary>
        [Required(ErrorMessage = "Campo requerido")]
        [StringLength(45)]
        public string? Logradouro { get; set; }

        /// <summary>
        /// GET/SET Bairro
        /// </summary>
        [Required(ErrorMessage = "Campo requerido")]
        [StringLength(45)]
        public string? Bairro { get; set; }

        /// <summary>
        /// GET/SET Número
        /// </summary>
        [Display(Name ="Número residencial")]
        [Required(ErrorMessage = "Campo requerido")]
        public string? Numero { get; set; }

        /// <summary>
        /// GET/SET Telefone
        /// </summary>
        [Required(ErrorMessage = "Campo requerido")]
        [StringLength(11,MinimumLength =11,ErrorMessage ="Número deve conter 11 dígitos, incluindo o DDD")]
        public string? Telefone { get; set; }

        /// <summary>
        /// GET/SET Email
        /// </summary>
        [Required(ErrorMessage = "Insira seu e-mail")]
        public string? Email { get; set; }

        /// <summary>
        /// GET/SET ID representante cooperativa
        /// </summary>
        [Display(Name ="Código Pessoa")]
        [Required(ErrorMessage = "Campo requerido")]
        [Key]
        public uint IdPessoaRepresentate { get; set; }

        /// <summary>
        /// GET/SET
        /// Status A - Ativo
        ///        C - Cancelado
        /// </summary>
        [Required(ErrorMessage = "Campo Obrigatório, EX: A - Ativo ou I - Inativo")]
        public string Status { get; set; } = null!;

    }
}
