using API.Business.Entities;
using API.Business.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Infraestrutura.Data.Repository
{
    public class CursoRepository : ICursoRepository
    {
        private readonly CursoDBContext _contexto;

        public CursoRepository(CursoDBContext contexto)
        {
            _contexto = contexto;
        }

        public void Adicionar(Curso curso)
        {
            _contexto.Curso.Add(curso);
        }

        public void Commit()
        {
            _contexto.SaveChanges();
        }

        public IList<Curso> ObterPorUsuario(int codigoUsuario)
        {
            return _contexto.Curso.Where(w => w.CodigoUsuario == codigoUsuario).ToList();
        }
    }
}
