using AulaProjetoFinal.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace AulaProjetoFinal.Domain.Interfaces
{
    public interface IVersaoService
    {
        IList<Versao> Versoes();
        Versao VersaoById(int Id);
        Versao Salvar(Versao versao);
        Versao Atualizar(Versao versao);
        bool Deletar(int Id);
    }
}
