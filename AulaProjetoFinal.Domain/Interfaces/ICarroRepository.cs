using AulaProjetoFinal.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace AulaProjetoFinal.Domain.Interfaces
{
    public interface ICarroRepository
    {
        IEnumerable<Carro> Get();
        Carro GetById(int Id);
        Carro Save(Carro carro);
        Carro Update(Carro carro);
        bool Delete(int Id);
    }
}
