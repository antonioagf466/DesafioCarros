using System.ComponentModel.DataAnnotations;
using System.Data;

namespace DesafioCarros.Models
{
    public class Vendedor
    {
        public int Id { get; set; }
        public string Name { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime DataAdmissao { get; set; }
        public string Matricula { get; set; }

        public double Salary { get; set; }
    }
}
