using AulaProjetoFinal.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace AulaProjetoFinal.Domain.Interfaces
{
    public interface IVersaoRepository
    {
        IEnumerable<Versao> Get();
        Versao GetById(int Id);
        Versao Save(Versao versao);
        Versao Update(Versao versao);
        bool Delete(int Id);
    }
}
