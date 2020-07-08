using AulaProjetoFinal.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace AulaProjetoFinal.Domain.Interfaces
{
    public interface IMarcaRepository
    {
        IEnumerable<Marca> Get();
        Marca GetById(int Id);
        Marca Save(Marca marca);
        Marca Update(Marca marca);
        bool Delete(int Id);
    }
}
