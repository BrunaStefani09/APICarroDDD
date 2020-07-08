using AulaProjetoFinal.Domain.Entities;
using AulaProjetoFinal.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AulaProjetoFinal.Domain.Services
{
    public class MarcaService : IMarcaService
    {
        private readonly IMarcaRepository _marcaRepository;

        public MarcaService(IMarcaRepository marcaRepository)
        {
            _marcaRepository = marcaRepository;
        }

        public IList<Marca> Marcas()
        {
            try
            {
                return _marcaRepository.Get().ToList();
            }
            catch
            {
                //gravar log com a exceção
                return new List<Marca>();
            }
        }

        public Marca MarcaById(int Id)
        {
            try
            {
                return _marcaRepository.GetById(Id);
            }
            catch
            {
                return null;
            }
        }

        public Marca Salvar(Marca marca)
        {
            try
            {
                return _marcaRepository.Save(marca);
            }
            catch
            {
                return null;
            }
        }

        public Marca Atualizar(Marca marca)
        {
            try
            {
                return _marcaRepository.Update(marca);
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
                return _marcaRepository.Delete(Id);
            }
            catch
            {
                return false;
            }
        }
    }
}
