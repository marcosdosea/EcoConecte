using Org.BouncyCastle.Crypto.Digests;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;


namespace EcoConecteWeb.Models
{
    public class VendaViewModel
    {
        /// <summary>
        /// GET ID Vendas
        /// </summary>
        [Key]
        [Required(ErrorMessage = "Campo obrigatório.")]
        [Display(Name = "Código Venda")]
        public uint Id { get; set; }

        /// <summary>
        /// GET/SET Nome
        /// </summary>
        [Required(ErrorMessage = "Campo obrigatório. Tipo ex: M ou P")]
        [Display(Name = "Tipo do material")]
        public string Tipo { get; set; } = null!;

        /// <summary>
        /// GET/SET Valor em real
        /// </summary>
        [Display(Name = "Valor R$")]
        [DataType(DataType.Currency)]
        [Range(0.01, 999999.99, ErrorMessage = "Informe um valor válido.")]
        public decimal Valor { get; set; }

        /// <summary>
        /// GET/SET Quantidade
        /// </summary>
        [Display(Name = "Quantidade (kg)")]
        [Required(ErrorMessage = "Campo obrigatório.")]
        public int Quantidade { get; set; }

        /// <summary>
        /// GET/SET Data
        /// </summary>
        [Required(ErrorMessage = "Campo obrigatório.")]
        [DataType(DataType.Date, ErrorMessage = "Data válida requerida")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
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
        [Display(Name = "Código Pessoa")]
        public uint IdPessoa { get; set; }
    }
}
