using AulaProjetoFinal.Domain.Entities;
using AulaProjetoFinal.Domain.Interfaces;
using AulaProjetoFinal.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AulaProjetoFinal.Infra.Data.Repository
{
    public class CarroRepository :ICarroRepository
    {
        private readonly DataContext context;
        public CarroRepository(DataContext context)
        {
            this.context = context;
        }

        public IEnumerable<Carro> Get()
        {
            return context.Carros;
        }
        public Carro GetById(int Id)
        {
            return context.Carros.Where(x => x.Id == Id).FirstOrDefault();
        }
        public Carro Save(Carro carro)
        {
            var state = carro.Id == 0 ? EntityState.Added : EntityState.Modified;
            context.Entry(carro).State = state;
            context.Add(carro);
            context.SaveChanges();
            return carro;
        }
        public Carro Update(Carro carro)
        {
            var _carro = context.Carros.Where(x => x.Id == carro.Id).FirstOrDefault();

            if (_carro != null)
            {
                _carro.Ano = carro.Ano;
                _carro.KM = carro.KM;
                _carro.Observacao = carro.Observacao;
                _carro.MarcaId = carro.MarcaId;
                _carro.ModeloId = carro.ModeloId;
                _carro.VersaoId = carro.VersaoId;
                context.Entry(_carro).State = EntityState.Modified;
                context.SaveChanges();
            }

            return carro;
        }
        public bool Delete(int Id)
        {
            var _carro = context.Carros.Where(x => x.Id == Id).FirstOrDefault();

            if (_carro != null)
            {
                context.Entry(_carro).State = EntityState.Deleted;
                context.SaveChanges();
                return true;
            }
            return false;
        }
    }
}
