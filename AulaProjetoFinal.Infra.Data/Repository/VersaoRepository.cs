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
    public class VersaoRepository : IVersaoRepository
    {
        private readonly DataContext context; // referencia do context

        public VersaoRepository(DataContext context)
        {
            this.context = context;
        } //metodo construtor, referenciando objeto context criado acima

        public IEnumerable<Versao> Get()
        {
            return context.Versoes;
        } // ligado ao context, faz referencia oa DbSet
        public Versao GetById(int Id)
        {
            return context.Versoes.Where(x => x.Id == Id).FirstOrDefault();
        }//Consulta via LINQ por Id
        public Versao Save(Versao versao) //poderia retornar um boolean
        {
            var state = versao.Id == 0 ? EntityState.Added : EntityState.Modified; //analise do framework,se o id do novo objeto for = 0 então ação added(adicionar),se nao, ele já existe então ação modified(modificação)
            context.Entry(versao).State = state; //recebe o estado do EFCore
            context.Add(versao); //adiciona os dados a entidade Versao
            context.SaveChanges(); //salva alteração
            return versao;
        }// Create
        public Versao Update(Versao versao)
        {
            var _versao = context.Versoes.Where(x => x.Id == versao.Id).FirstOrDefault();

            if (_versao != null)
            {
                _versao.Nome = versao.Nome;
                _versao.ModeloId = versao.ModeloId;

                context.Entry(_versao).State = EntityState.Modified;
                context.SaveChanges();
            }
            return versao;
        }
        public bool Delete(int Id)
        {
            var _versao = context.Versoes.Where(x => x.Id == Id).FirstOrDefault();

            if (_versao != null)
            {
                context.Entry(_versao).State = EntityState.Deleted;
                context.SaveChanges();
                return true;
            }
            return false;
        }
    }
}
