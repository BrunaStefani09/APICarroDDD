using AulaProjetoFinal.Domain.Entities;
using AulaProjetoFinal.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AulaProjetoFinal.Domain.Services
{
    public class CarroService : ICarroService
    {
        private readonly ICarroRepository _carroRepository;

        public CarroService(ICarroRepository carroRepository)
        {
            _carroRepository = carroRepository;
        }

        public IList<Carro> Carros()
        {
            try
            {
                return _carroRepository.Get().ToList();
            }
            catch
            {
                //gravar log com a exceção
                return new List<Carro>();
            }
        }

        public Carro CarroById(int Id)
        {
            try
            {
                return _carroRepository.GetById(Id);
            }
            catch
            {
                return null;
            }
        }

        public Carro Salvar(Carro carro)
        {
            try
            {
                return _carroRepository.Save(carro);
            }
            catch
            {
                return null;
            }
        }

        public Carro Atualizar(Carro carro)
        {
            try
            {
                return _carroRepository.Update(carro);
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
                return _carroRepository.Delete(Id);
            }
            catch
            {
                return false;
            }
        }
    }
}
