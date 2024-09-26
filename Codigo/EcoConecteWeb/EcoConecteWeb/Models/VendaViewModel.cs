using Org.BouncyCastle.Crypto.Digests;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;


namespace EcoConecteWeb.Models
{
    public class VendaViewModel
    {
        [Key]
        [Required(ErrorMessage = "Campo obrigatório.")]
        [Display(Name = "Código da venda")]
        public uint Id { get; set; }

        [Required(ErrorMessage = "Campo obrigatório.")]
        [Display(Name = "Tipo do material")]
        public string Tipo { get; set; } = null!;

        [Required(ErrorMessage = "Campo obrigatório.")]
        public decimal Valor { get; set; }

        [Required(ErrorMessage = "Campo obrigatório.")]
        public decimal Quantidade { get; set; }

        [Required(ErrorMessage = "Campo obrigatório.")]
        public DateTime Data { get; set; }

        [Required(ErrorMessage = "Campo obrigatório.")]
        [Display(Name = "Código da cooperativa")]
        public uint IdCooperativa { get; set; }

        [Required(ErrorMessage = "Campo obrigatório.")]
        [Display(Name = "Código da pessoa")]
        public uint IdPessoa { get; set; }
    }
}
