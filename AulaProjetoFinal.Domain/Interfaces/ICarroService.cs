using AulaProjetoFinal.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace AulaProjetoFinal.Domain.Interfaces
{
    public interface ICarroService
    {
        IList<Carro> Carros();
        Carro CarroById(int Id);
        Carro Salvar(Carro carro);
        Carro Atualizar(Carro carro);
        bool Deletar(int Id);
    }
}
