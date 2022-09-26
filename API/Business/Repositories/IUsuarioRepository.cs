using API.Business.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Business.Repositories
{
    interface IUsuarioRepository
    {
        void Adicionar(Usuario usuario);
        void Commit();
    }
}
