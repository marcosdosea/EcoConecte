using Org.BouncyCastle.Crypto.Digests;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;


namespace EcoConecteWeb.Models
{
    public class VendaViewModel
    {
        /// <summary>
        /// GET ID
        /// </summary>
        [Key]
        [Required(ErrorMessage = "Campo obrigatório.")]
        [Display(Name = "Código da venda")]
        public uint Id { get; }

        /// <summary>
        /// GET/SET Nome
        /// </summary>
        [Required(ErrorMessage = "Campo obrigatório.")]
        [Display(Name = "Tipo do material")]
        public string Tipo { get; set; } = null!;

        /// <summary>
        /// GET/SET Valor em real
        /// </summary>
        [Required(ErrorMessage = "Campo obrigatório.")]
        public string Valor { get; set; } = null;

        /// <summary>
        /// GET/SET Quantidade
        /// </summary>
        [Required(ErrorMessage = "Campo obrigatório.")]
        public string Quantidade { get; set; } = null!;

        /// <summary>
        /// GET/SET Data
        /// </summary>
        [Required(ErrorMessage = "Campo obrigatório.")]
        public DateTime Data { get; set; }

        /// <summary>
        /// GET/SET ID cooperativa
        /// </summary>
        [Required(ErrorMessage = "Campo obrigatório.")]
        [Display(Name = "Código da cooperativa")]
        public uint IdCooperativa { get; set; }

        /// <summary>
        /// GET/SET ID pessoa
        /// </summary>
        [Required(ErrorMessage = "Campo obrigatório.")]
        [Display(Name = "Código da pessoa")]
        public uint IdPessoa { get; set; }
    }
}
