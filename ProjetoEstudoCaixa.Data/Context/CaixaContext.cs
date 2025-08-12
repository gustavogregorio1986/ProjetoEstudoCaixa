using Microsoft.EntityFrameworkCore;
using ProjetoEstudoCaixa.Dominio.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoEstudoCaixa.Data.Context
{
    public class CaixaContext : DbContext
    {
        public CaixaContext(DbContextOptions options)
            :base(options)
        {
            
        }

        public DbSet<Usuario> Usuarios { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(CaixaContext).Assembly);
            base.OnModelCreating(modelBuilder);
        }
    }
}
