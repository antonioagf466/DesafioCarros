namespace DesafioCarros.Models
{
    public class Carro
    {
        public int Id { get; set; }
        public string Marca { get; set; }

        public string Modelo { get; set;}

        public DateTime AnoFabricacao { get; set; }

        public int AnoModelo { get; set; }

        public string Chassi { get; set; }

        public double Preco { get; set; }
    }
}
