using AulaProjetoFinal.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace AulaProjetoFinal.Domain.Interfaces
{
    public interface IUsuarioRepository
    {
        IEnumerable<Usuario> Get();
        Usuario GetById(int Id);
        Usuario GetByEmailPassword(Usuario usuario);
        Usuario GetByEmail(string email);
        Usuario Save(Usuario usuario);
        Usuario Update(Usuario usuario);
        bool Delete(int Id);
    }
}
