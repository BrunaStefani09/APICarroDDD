using AulaProjetoFinal.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace AulaProjetoFinal.Domain.Interfaces
{
    public interface IMarcaService
    {
        IList<Marca> Marcas();
        Marca MarcaById(int Id);
        Marca Salvar(Marca marca);
        Marca Atualizar(Marca marca);
        bool Deletar(int Id);
    }
}
