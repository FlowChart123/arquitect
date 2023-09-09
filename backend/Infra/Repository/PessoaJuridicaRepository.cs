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
    public class PessoaJuridicaRepository : RepositoryBase<PessoaJuridica>
    {
        
        private readonly IUnitOfWork _unit;

        public PessoaJuridicaRepository(IUnitOfWork unit) : base(unit)
        {            
            _unit = unit;
        }


        //IPessoaREPOSITORY   
        public IList<PessoaJuridicaResult> Query()
        {

            var res = _context.PessoaJuridicas.AsNoTracking().ToList();
            return res.Select(p => p.asPessoaJuridicaResult()).ToList();
        }
                             
        public override PessoaJuridica InsertOrUpdate(PessoaJuridica entity)
        {
            if (string.IsNullOrEmpty(entity.Cnpj)) return entity;
            _context.PessoaJuridicas.Entry(entity).State = EntityState.Detached;
            var t1 = Load(null, entity.Id);
            if (t1 != null)
            {                
                _context.PessoaJuridicas.Entry(entity).State = EntityState.Modified;
            }
            else
            {                
                _context.PessoaJuridicas.Entry(entity).State = EntityState.Added;                
            }
            
            _context.SaveChanges();            
            return entity;
        }

        public override PessoaJuridica Load(int? id, Guid? guid)
        {
            var model = _context.PessoaJuridicas.Where(p => p.Id == guid).AsNoTracking().FirstOrDefault();
            if (model == null) return null;
            return model;
        }

        public override void Delete(int? id, Guid guid)
        {
             var entity = Load(null, guid);
            _context.Entry(entity).State = EntityState.Deleted;
            _context.SaveChanges();
        }

        public override PessoaJuridica Insert(PessoaJuridica entity)
        {
            var result = InsertOrUpdate(entity);
            return result;
        }

        public override PessoaJuridica Update(PessoaJuridica entity)
        {
            var result = InsertOrUpdate(entity);
            return result;
        }
    }
}

