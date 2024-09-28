using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EcoConecteWeb.Models
{
    public class CooperativaModel
    {
        [Display(Name = "Código")]
        [Key]
        [Required(ErrorMessage = "Campo requerido")]
        public int Id { get; set; }
        [Display(Name ="Nome da cooperativa")]
        [Required(ErrorMessage = "Campo requerido")]
        [StringLength(40,MinimumLength =5,ErrorMessage = "Nome da cooperativa deve ter entre 5 e 40 caracteres")]
        public string Nome { get; set; } = null!;
        [Required(ErrorMessage = "Campo requerido")]
        [Display(Name ="Inscrição Estadual")]
        [StringLength(9,MinimumLength =9,ErrorMessage ="Inscrição estadual deve possuir 9 dígitos ")]
        public string InscrcaoEstadual { get; set; } = null!;
        [Required(ErrorMessage = "Campo requerido")]
        [Display(Name ="Inscrição Municipal")]
        [StringLength(9,MinimumLength =9,ErrorMessage ="Inscrição municipal deve possuir 9 dígitos")]
        public string InscricaoMunicipal { get; set; } = null!;
        [Display(Name = "CNPJ")]
        [Required(ErrorMessage = "Campo requerido")]
        [StringLength(14,MinimumLength =14,ErrorMessage =" CNPJ deve ser composto por 14 dígitos ")]
        public string Cnpj { get; set; } = null!;
        [Display(Name = "CEP")]
        [Required(ErrorMessage = "Campo requerido")]
        [StringLength(8, MinimumLength = 8, ErrorMessage = " CEP deve ser composto por 8 dígitos ")]
        public string Cep { get; set; } = null!;
        [Required(ErrorMessage = "Campo requerido")]
        [StringLength(30)]
        public string? Logradouro { get; set; }
        [Required(ErrorMessage = "Campo requerido")]
        [StringLength(30)]
        public string? Bairro { get; set; }
        [Display(Name ="Número residencial")]
        [Required(ErrorMessage = "Campo requerido")]
        public string? Numero { get; set; }
        [Required(ErrorMessage = "Campo requerido")]
        [StringLength(11,MinimumLength =11,ErrorMessage ="Número deve conter 11 dígitos, incluindo o DDD")]
        public string? Telefone { get; set; }
        [Required(ErrorMessage = "Insira seu e-mail")]
        public string? Email { get; set; }
        [Display(Name ="Código do representante da cooperativa")]
        [Required(ErrorMessage = "Campo requerido")]
        public uint IdPessoaRepresentate { get; set; }
         [Required(ErrorMessage = "Campo requerido")]
        public string Status { get; set; } = null!;


    }
}
