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
    public class MarcaRepository : IMarcaRepository
    {
        private readonly DataContext context; // referencia do context

        public MarcaRepository(DataContext context)
        {
            this.context = context;
        } //metodo construtor, referenciando objeto context criado acima

        public IEnumerable<Marca> Get()
        {
            return context.Marcas;
        } // ligado ao context, faz referencia oa DbSet
        public Marca GetById(int Id)
        {
            return context.Marcas.Where(x => x.Id == Id).FirstOrDefault();
        }//Consulta via LINQ por Id
        public Marca Save(Marca marca) //poderia retornar um boolean
        {
            var state = marca.Id == 0 ? EntityState.Added : EntityState.Modified; //analise do framework,se o id do novo objeto for = 0 então ação added(adicionar),se nao, ele já existe então ação modified(modificação)
            context.Entry(marca).State = state; //recebe o estado do EFCore
            context.Add(marca); //adiciona os dados a entidade Marca
            context.SaveChanges(); //salva alteração
            return marca;
        }// Create
        public Marca Update(Marca marca)
        {
            var _marca = context.Marcas.Where(x => x.Id == marca.Id).FirstOrDefault();

            if (_marca != null)
            {
                _marca.Nome = marca.Nome;

                context.Entry(_marca).State = EntityState.Modified;
                context.SaveChanges();
            }

            return marca;
        }
        public bool Delete(int Id)
        {
            var _marca = context.Marcas.Where(x => x.Id == Id).FirstOrDefault();

            if (_marca != null)
            {
                context.Entry(_marca).State = EntityState.Deleted;
                context.SaveChanges();
                return true;
            }
            return false;
        }
    }
}
