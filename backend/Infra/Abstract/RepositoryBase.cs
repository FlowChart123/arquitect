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
    public abstract class RepositoryBase<TEntity> : IRepositoy<TEntity> where TEntity : BaseEntity 
    {
        private readonly DbContextOptions<DataContext> _OptionsBuilder;
        
        protected DataContext _context { get; set; }
        
        public RepositoryBase()
        {
            _OptionsBuilder = new DbContextOptions<DataContext>();
            this._context = new DataContext(_OptionsBuilder);
        }

        public virtual async void Delete(int id)
        {
            var entity =  Load(id);
            _context.Entry(entity).State = EntityState.Deleted;
            _context.SaveChanges();
        }

        public virtual TEntity Insert(TEntity entity)
        {            
            _context.Add(entity);
            _context.SaveChanges();
            return entity;

        }

        public virtual async Task<ResultPage<TEntity>> List(Expression<Func<TEntity, bool>> filter = null, string[] includes = null, int? page = 1, int? limit = null)
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
                    tmp.Items = query.Take((int)limit).ToList().AsQueryable();
                    return tmp;
                }
                else if (limit > 0 && page >= 1)
                {
                    int start = (Convert.ToInt32(page) - 1) * Convert.ToInt32(limit);
                    int qtd = Convert.ToInt32(limit);

                    tmp.TotalItems = query.Count();
                    tmp.Items = query.Skip(start).Take((int)limit).ToList().AsQueryable();
                    return tmp;
                }
                else
                {
                    throw new Exception("limite de valor deve ser positivo.");
                }
            }
            else
            {
                tmp.TotalItems = query.Count();
                tmp.Items = query.ToList().AsQueryable();
                return tmp;
            }

        }

        public  TEntity Load(int id, string[]? includes = null)
        {
            var model = _context.Set<TEntity>().Find(id);
            if (model == null) return null;
            _context.Entry(model).State = EntityState.Detached;
            return model;
        }

        public TEntity Load(Guid id, string[]? includes = null)
        {
            var model = _context.Set<TEntity>().Find(id);
            if (model == null) return null;
            _context.Entry(model).State = EntityState.Detached;
            return model;
        }


        public virtual void Save()
        {
            _context.SaveChanges();
        }

        public virtual TEntity Update(TEntity entity)
        {
            _context.Entry(entity).State = EntityState.Modified;            
            _context.Update(entity);
            _context.SaveChanges();
            return entity;
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

        public virtual void InsertOrUpdate(TEntity entity)
        {
            var obj = _context.Entry(entity);
            if (obj==null)
            {
                Insert(entity);
            }
            else
            {
                Update(entity);
            }
            _context.SaveChanges();
        }


        public void Delete(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
