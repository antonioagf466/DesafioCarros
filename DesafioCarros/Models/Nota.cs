using System.ComponentModel.DataAnnotations;

namespace DesafioCarros.Models
{
    public class Nota
    {
        public int Id { get; set; }
        public string Numero { get; set; }
        [Display(Name = "Data Emissão")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime DataEmissao { get; set; }
        [Display(Name = "Data Garantia")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime Garantia { get; set; }

        public double ValorVenda { get; set; }
        [Display(Name = "Nome do Cliente")]
        public int ClienteId { get; set; }
        public Cliente cliente { get; set; }
        [Display(Name = "Nome do Vendedor")]
        public int VendedorId { get; set; }

        public Vendedor vendedor { get; set; }
        [Display(Name = "Marca do Carro")]
        public int CarroId { get; set; }
        public Carro carro { get; set; }
    }
}
