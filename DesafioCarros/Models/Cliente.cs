using System.ComponentModel.DataAnnotations;

namespace DesafioCarros.Models
{
    public class Cliente
    {
        public int Id { get; set; }
        public string Name { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime DataNasc { get; set; }

        public string Email { get; set; }

        public string Telefone { get; set; }

        public string Endereco { get; set; }

        public string Cpf { get; set; }
    }
}
