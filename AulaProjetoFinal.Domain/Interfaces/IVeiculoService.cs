using AulaProjetoFinal.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace AulaProjetoFinal.Domain.Interfaces
{
    public interface IVeiculoService
    {
        IList<Veiculo> Veiculos();
        Veiculo VeiculoById(int Id);
        Veiculo Salvar(Veiculo veiculo);
        Veiculo Atualizar(Veiculo veiculo);
        bool Deletar(int Id);
    }
}
