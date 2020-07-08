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
    public class VeiculoRepository : IVeiculoRepository
    {
        private readonly DataContext context;
        public VeiculoRepository(DataContext context)
        {
            this.context = context;
        }

        public IEnumerable<Veiculo> Get()
        {
            return context.Veiculos;
        }
        public Veiculo GetById(int Id)
        {
            return context.Veiculos.Where(x => x.Id == Id).FirstOrDefault();
        }
        public Veiculo Save(Veiculo veiculo)
        {
            var state = veiculo.Id == 0 ? EntityState.Added : EntityState.Modified;
            context.Entry(veiculo).State = state;
            context.Add(veiculo);
            context.SaveChanges();
            return veiculo;
        }
        public Veiculo Update(Veiculo veiculo)
        {
            var _veiculo = context.Veiculos.Where(x => x.Id == veiculo.Id).FirstOrDefault();

            if (_veiculo != null)
            {
                _veiculo.AnoFabricacao = veiculo.AnoFabricacao;
                _veiculo.AnoModelo = veiculo.AnoModelo;
                _veiculo.Cor = veiculo.Cor;
                _veiculo.Imagem = veiculo.Imagem;
                _veiculo.MarcaId = veiculo.MarcaId;
                _veiculo.ModeloId = veiculo.ModeloId;
                _veiculo.Preco = veiculo.Preco;
                _veiculo.KM = veiculo.KM;
                _veiculo.VersaoId = veiculo.VersaoId;
                context.Entry(_veiculo).State = EntityState.Modified;
                context.SaveChanges();
            }

            return veiculo;
        }
        public bool Delete(int Id)
        {
            var _veiculo = context.Veiculos.Where(x => x.Id == Id).FirstOrDefault();

            if (_veiculo != null)
            {
                context.Entry(_veiculo).State = EntityState.Deleted;
                context.SaveChanges();
                return true;
            }
            return false;
        }
    }
}
