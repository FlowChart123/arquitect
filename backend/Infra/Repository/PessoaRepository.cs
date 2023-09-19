using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Domain.Dto;
using Domain.Interfaces.Repository;
using Entities.Models;
using Infra.Configuracao;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Domain.Specs;
using Infra.Abstract;

namespace Infra.Repositorio
{
    public class PessoaRepository : RepositoryBase<Pessoa>, IPessoaRepository
    {


        
        private readonly IUnitOfWork _unit;

        public PessoaRepository(IUnitOfWork unit) : base(unit)
        {            
            _unit = unit;
        }


        //IPessoaREPOSITORY   
        public IList<PessoaResult> Query()
        {

            var res = _context.Pessoas.Include("PessoaFisica").Include("PessoaJuridica")
                .Include("PessoaFisica.PessoaFisicaComplemento")
                .Select(o => o.asPessoaResult()).AsNoTracking().ToList();
            return res;
        }
                             
        public override Pessoa InsertOrUpdate(Pessoa entity)
        {
            _context.Pessoas.Entry(entity).State = EntityState.Detached;
            entity.DataCadastro = DateTime.Now;

            if (entity.Id != Guid.Empty)
            {                
                _context.Pessoas.Entry(entity).State = EntityState.Modified;
            }
            else
            {
                entity.Id = Guid.NewGuid();
                _context.Pessoas.Entry(entity).State = EntityState.Added;
                _context.SaveChanges();
            }
            
            _context.SaveChanges();            
            return entity;
        }

        public override Pessoa Load(int? id, Guid? guid)
        {
            var model = _context.Pessoas.Where(p => p.Id == guid).Include("PessoaFisica").Include("PessoaFisica.PessoaFisicaComplemento").AsNoTracking().FirstOrDefault();
            if (model == null) return null;
            //_context.Pessoas.Entry(model).State = EntityState.Detached;
            return model;
        }

        public override void Delete(int? id, Guid guid)
        {
             var entity = Load(null, guid);
            _context.Entry(entity).State = EntityState.Deleted;
            _context.SaveChanges();
        }

        public override Pessoa Insert(Pessoa entity)
        {
            var result = InsertOrUpdate(entity);
            return result;
        }

        public override Pessoa Update(Pessoa entity)
        {
            var result = InsertOrUpdate(entity);
            return result;
        }
    }
}

