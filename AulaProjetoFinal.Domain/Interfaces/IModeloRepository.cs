using AulaProjetoFinal.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace AulaProjetoFinal.Domain.Interfaces
{
    public interface IModeloRepository
    {
        IEnumerable<Modelo> Get();
        Modelo GetById(int Id);
        Modelo Save(Modelo modelo);
        Modelo Update(Modelo modelo);
        bool Delete(int Id);
    }
}
