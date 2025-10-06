using System.Data;

namespace DesafioCarros.Models
{
    public class Vendedor
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DataSetDateTime DataAdmissao { get; set; }
        public string Matricula { get; set; }

        public double Salary { get; set; }
    }
}
