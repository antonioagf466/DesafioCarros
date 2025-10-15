using System.ComponentModel.DataAnnotations;

namespace DesafioCarros.Models
{
    public class Carro
    {
        public int Id { get; set; }
        public string Marca { get; set; }

        public string Modelo { get; set;}
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]

        public DateTime AnoFabricacao { get; set; }

        public int AnoModelo { get; set; }

        public string Chassi { get; set; }

        public double Preco { get; set; }
    }
}
