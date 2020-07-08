using AulaProjetoFinal.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace AulaProjetoFinal.Domain.Interfaces
{
    public interface IVeiculoRepository
    {
        IEnumerable<Veiculo> Get();
        Veiculo GetById(int Id);
        Veiculo Save(Veiculo veiculo);
        Veiculo Update(Veiculo veiculo);
        bool Delete(int Id);
    }
}
