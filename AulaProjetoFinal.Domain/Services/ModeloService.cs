using AulaProjetoFinal.Domain.Entities;
using AulaProjetoFinal.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AulaProjetoFinal.Domain.Services
{
    public class ModeloService : IModeloService
    {
        private readonly IModeloRepository _modeloRepository;

        public ModeloService(IModeloRepository modeloRepository)
        {
            _modeloRepository = modeloRepository;
        }

        public IList<Modelo> Modelos()
        {
            try
            {
                return _modeloRepository.Get().ToList();
            }
            catch
            {
                //gravar log com a exceção
                return new List<Modelo>();
            }
        }

        public Modelo ModeloById(int Id)
        {
            try
            {
                return _modeloRepository.GetById(Id);
            }
            catch
            {
                return null;
            }
        }

        public Modelo Salvar(Modelo modelo)
        {
            try
            {
                return _modeloRepository.Save(modelo);
            }
            catch
            {
                return null;
            }
        }

        public Modelo Atualizar(Modelo modelo)
        {
            try
            {
                return _modeloRepository.Update(modelo);
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
                return _modeloRepository.Delete(Id);
            }
            catch
            {
                return false;
            }
        }
    }
}
