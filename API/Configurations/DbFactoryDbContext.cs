using API.Infraestrutura.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Configurations
{
    public class DbFactoryDbContext : IDesignTimeDbContextFactory<CursoDBContext>
    {
        public CursoDBContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<CursoDBContext>();
            optionsBuilder.UseSqlServer("Server=localhost;Database=???;user=root;password=123456");
            CursoDBContext contexto = new CursoDBContext(optionsBuilder.Options);

            return contexto;
        }
    }
}
