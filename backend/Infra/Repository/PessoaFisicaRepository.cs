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

namespace Infra.Repository
{
    public class PessoaFisicaRepository : RepositoryBase<PessoaFisica>
    {
        private readonly IUnitOfWork _unit;

        public PessoaFisicaRepository(IUnitOfWork unit) : base(unit)
        {
            _unit = unit;
        }

        public override void Delete(int? id, Guid guid)
        {
            throw new NotImplementedException();
        }

        public override PessoaFisica Insert(PessoaFisica entity)
        {
            throw new NotImplementedException();
        }

        public override PessoaFisica InsertOrUpdate(PessoaFisica entity)
        {            
            
            _context.Entry(entity).State = EntityState.Detached;
            var t1 = Load(null,entity.Id);            
            if (t1 != null)
            {
                _context.Entry(entity).State = EntityState.Modified;
            }
            else
            {
                if (string.IsNullOrEmpty(entity.Cpf) == false)
                {
                    _context.Entry(entity).State = EntityState.Added;
                }
            }

            if (entity.PessoaFisicaComplemento != null)
            {
            }
            _context.SaveChanges();
            return entity;         
        }

        public override PessoaFisica Load(int? id, Guid? guid)
        {
            var model = _context.PessoaFisicas.AsNoTracking().Where(p => p.Id == guid).FirstOrDefault();
            if (model == null) return null;
            _context.Entry(model).State = EntityState.Detached;
            return model;
        }

        public override PessoaFisica Update(PessoaFisica entity)
        {
            throw new NotImplementedException();
        }
    }
}
