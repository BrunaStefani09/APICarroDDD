using AulaProjetoFinal.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace AulaProjetoFinal.Domain.Interfaces
{
    public interface IModeloService
    {
       IList<Modelo> Modelos();
       Modelo ModeloById(int Id);
       Modelo Salvar(Modelo modelo);
       Modelo Atualizar(Modelo modelo);
       bool Deletar(int Id);
    }
}
