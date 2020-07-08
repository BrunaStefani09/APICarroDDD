using AulaProjetoFinal.Domain.Entities;
using AulaProjetoFinal.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AulaProjetoFinal.Domain.Services
{
    public class VersaoService : IVersaoService
    {
        private readonly IVersaoRepository _versaoRepository;

        public VersaoService(IVersaoRepository versaoRepository)
        {
            _versaoRepository = versaoRepository;
        }

        public IList<Versao> Versoes()
        {
            try
            {
                return _versaoRepository.Get().ToList();
            }
            catch
            {
                //gravar log com a exceção
                return new List<Versao>();
            }
        }

        public Versao VersaoById(int Id)
        {
            try
            {
                return _versaoRepository.GetById(Id);
            }
            catch
            {
                return null;
            }
        }

        public Versao Salvar(Versao versao)
        {
            try
            {
                return _versaoRepository.Save(versao);
            }
            catch
            {
                return null;
            }
        }

        public Versao Atualizar(Versao versao)
        {
            try
            {
                return _versaoRepository.Update(versao);
            }
            catch
            {
                return null;
            }
        }

        public bool Deletar(int Id)
        {
            try
            {
                return _versaoRepository.Delete(Id);
            }
            catch
            {
                return false;
            }
        }
    }
}
