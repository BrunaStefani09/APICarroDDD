using AulaProjetoFinal.Domain.Entities;
using AulaProjetoFinal.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AulaProjetoFinal.Domain.Services
{
    public class VeiculoService : IVeiculoService
    {
        private readonly IVeiculoRepository _veiculoRepository;

        public VeiculoService(IVeiculoRepository veiculoRepository)
        {
            _veiculoRepository = veiculoRepository;
        }

        public IList<Veiculo> Veiculos()
        {
            try
            {
                return _veiculoRepository.Get().ToList();
            }
            catch
            {
                //gravar log com a exceção
                return new List<Veiculo>();
            }
        }

        public Veiculo VeiculoById(int Id)
        {
            try
            {
                return _veiculoRepository.GetById(Id);
            }
            catch
            {
                return null;
            }
        }

        public Veiculo Salvar(Veiculo veiculo)
        {
            try
            {
                return _veiculoRepository.Save(veiculo);
            }
            catch
            {
                return null;
            }
        }

        public Veiculo Atualizar(Veiculo veiculo)
        {
            try
            {
                return _veiculoRepository.Update(veiculo);
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
                return _veiculoRepository.Delete(Id);
            }
            catch
            {
                return false;
            }
        }
    }
}
