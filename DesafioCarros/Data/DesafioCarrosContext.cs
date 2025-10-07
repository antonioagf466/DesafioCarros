using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using DesafioCarros.Models;

namespace DesafioCarros.Data
{
    public class DesafioCarrosContext : DbContext
    {
        public DesafioCarrosContext (DbContextOptions<DesafioCarrosContext> options)
            : base(options)
        {
        }

        public DbSet<DesafioCarros.Models.Carro> Carro { get; set; } = default!;

        public DbSet<DesafioCarros.Models.Cliente>? Cliente { get; set; }

        public DbSet<DesafioCarros.Models.Vendedor>? Vendedor { get; set; }

        public DbSet<DesafioCarros.Models.Nota>? Nota { get; set; }
    }
}
