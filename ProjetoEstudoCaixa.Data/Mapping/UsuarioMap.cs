using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjetoEstudoCaixa.Dominio.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoEstudoCaixa.Data.Mapping
{
    public class UsuarioMap : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.ToTable("tb_Usuarios");

            builder.HasKey(u => u.Id);

            builder.Property(u => u.Email)
                .HasColumnName("Email")
                .IsRequired()
                .HasColumnType("NVARCHAR(50)");

            builder.Property(u => u.Senha)
                .HasColumnName("Senha")
                .IsRequired()
                .HasColumnType("NVARCHAR(100)");

            builder.Property(u => u.Perfil)
                .HasColumnName("Perfil")
                .IsRequired()
                .HasColumnType("NVARCHAR(50)");
        }
    }
}
