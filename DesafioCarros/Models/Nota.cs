namespace DesafioCarros.Models
{
    public class Nota
    {
        public int Id { get; set; }
        public string Numero { get; set; }

        public DateTime DataEmissao { get; set; }

        public DateTime Garantia { get; set; }

        public double ValorVenda { get; set; }

        public Cliente cliente { get; set; }

        public Vendedor vendedor { get; set; }

        public Carro carro { get; set; }
    }
}
