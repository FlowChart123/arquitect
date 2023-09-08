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
    public class PessoaFisicaComplementoRepository : RepositoryBase<PessoaFisicaComplemento>
    {
        private readonly IUnitOfWork _unit;

        public PessoaFisicaComplementoRepository(IUnitOfWork unit) : base(unit)
        {
            _unit = unit;
        }

        public override void Delete(int? id, Guid guid)
        {
            throw new NotImplementedException();
        }

        public override PessoaFisicaComplemento Insert(PessoaFisicaComplemento entity)
        {
            throw new NotImplementedException();
        }

        public override PessoaFisicaComplemento InsertOrUpdate(PessoaFisicaComplemento entity)
        {
            _context.Entry(entity).State = EntityState.Detached;
            var t = Load(null, entity.Id);
            if (t != null)
            {
                _context.Entry(entity).State = EntityState.Modified;
            }
            else
            {
                _context.Entry(entity).State = EntityState.Added;
            }

            _context.SaveChanges();
            return entity;
        }

        public override PessoaFisicaComplemento Load(int? id, Guid? guid)
        {
            var model = _context.PessoaFisicaComplementos.AsNoTracking().Where(p => p.Id == guid).FirstOrDefault();
            if (model == null) return null;
            _context.Entry(model).State = EntityState.Detached;
            return model;
        }

        public override PessoaFisicaComplemento Update(PessoaFisicaComplemento entity)
        {
            throw new NotImplementedException();
        }
    }
}
