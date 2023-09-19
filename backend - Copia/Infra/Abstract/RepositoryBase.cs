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

namespace Infra.Abstract
{
    public abstract class RepositoryBase<TEntity> : IRepositoy<TEntity> where TEntity : class 
    {

        protected DataContext _context { get; set; }
        private readonly IUnitOfWork _unit;
    
        public RepositoryBase(IUnitOfWork unit)
        {
            this._unit = unit;
            this._context = unit.GetContext();
        }
               
        public virtual Task<ResultPage<TEntity>> List(Expression<Func<TEntity, bool>> filter = null, string[] includes = null, int? page = 1, int? limit = null)
        {

            ResultPage<TEntity> tmp = new ResultPage<TEntity>();


            var query = _context.Set<TEntity>().AsQueryable();

            if (filter != null)
                query = query.Where(filter);

            includes?.ToList().ForEach(navigation => query = query.Include(navigation));
            if (limit != null)
            {
                if (limit > 0 && page == null)
                {
                    tmp.TotalItems = query.Count();
                    tmp.Items = query.Take((int)limit).AsNoTracking().ToList().AsQueryable();
                    return Task.FromResult(tmp);
                }
                else if (limit > 0 && page >= 1)
                {
                    int start = (Convert.ToInt32(page) - 1) * Convert.ToInt32(limit);
                    int qtd = Convert.ToInt32(limit);

                    tmp.TotalItems = query.Count();
                    tmp.Items = query.Skip(start).Take((int)limit).AsNoTracking().ToList().AsQueryable();
                    return Task.FromResult(tmp);
                }
                else
                {
                    throw new Exception("limite de valor deve ser positivo.");
                }
            }
            else
            {
                tmp.TotalItems = query.Count();
                tmp.Items = query.AsNoTracking().ToList().AsQueryable();
                return Task.FromResult(tmp);
            }

        }

        public virtual void UpdateChildCollection<Tparent, Tid, Tchild>(Tparent dbItem, Tparent newItem, Func<Tparent, IEnumerable<Tchild>> selector, Func<Tchild, Tid> idSelector) where Tchild : class
        {
             
            var dbItems = selector(dbItem).ToList();
            var newItems = selector(newItem).ToList();
            if (dbItems == null && newItems == null)
                return;

            var original = dbItems?.ToDictionary(idSelector) ?? new Dictionary<Tid, Tchild>();
            var updated = newItems?.ToDictionary(idSelector) ?? new Dictionary<Tid, Tchild>();

            var toRemove = original.Where(i => !updated.ContainsKey(i.Key)).ToArray();
            var removed = toRemove.Select(i => _context.Entry(i.Value).State = EntityState.Deleted).ToArray();

            var toUpdate = original.Where(i => updated.ContainsKey(i.Key)).ToList();
            toUpdate.ForEach(i => _context.Entry(i.Value).CurrentValues.SetValues(updated[i.Key]));

            var toAdd = updated.Where(i => !original.ContainsKey(i.Key)).ToList();
            toAdd.ForEach(i => _context.Set<Tchild>().Add(i.Value));
        }

        public abstract TEntity InsertOrUpdate(TEntity entity);

        public abstract void Delete(int? id, Guid guid);

        public abstract TEntity Load(int? id, Guid? guid);

        public void Save()
        {
            _context.SaveChanges();
        }

        public abstract TEntity Insert(TEntity entity);

        public abstract TEntity Update(TEntity entity);        
    }
}
