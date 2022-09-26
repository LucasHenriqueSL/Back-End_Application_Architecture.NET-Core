using API.Business.Entities;
using API.Infraestrutura.Data.Mapping;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Infraestrutura.Data
{
    public class CursoDBContext : DbContext
    {
        public CursoDBContext(DbContextOptions<CursoDBContext> options): base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CursoMapping());
            modelBuilder.ApplyConfiguration(new UsuarioMapping());
            base.OnModelCreating(modelBuilder);
        }
        public DbSet<Usuario> Usuario { get; set; }
    }
}
