using API.Business.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Infraestrutura.Data.Mapping
{
    public class CursoMapping : IEntityTypeConfiguration<Curso>
    {
        public void Configure(EntityTypeBuilder<Curso> builder)
        {
            builder.ToTable("TB_CURSO");
            builder.HasKey(P => P.Codigo);
            builder.Property(P => P.Codigo).ValueGeneratedOnAdd();
            builder.Property(P => P.Nome);
            builder.Property(P => P.Descricao);
            builder.HasOne(p => p.Usuario).WithMany().HasForeignKey(fk => fk.CodigoUsuario);
        }
    }
}
