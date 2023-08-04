using Domain.Interfaces.Generics;
using Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Infra.Configuracao;

namespace Infra.Base
{

    public class BaseRepository<TEntity> : IRepository<TEntity> where TEntity : BaseEntity
    {
        private DataContext _context;

        public BaseRepository(DataContext context)
        {
            _context = context;

        }

        protected void UpdateChildCollection<Tparent, Tid, Tchild>(Tparent dbItem, Tparent newItem, Func<Tparent, IEnumerable<Tchild>> selector, Func<Tchild, Tid> idSelector) where Tchild : class
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

        public async Task<ResultPage<TEntity>> GetQueryable(Expression<Func<TEntity, bool>> filter = null, string[] includes = null, int? page = 1, int? limit = null)
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
                    tmp.Items = await query.Take((int)limit).ToListAsync();
                    return tmp;
                }
                else if (limit > 0 && page >= 1)
                {
                    int start = (Convert.ToInt32(page) - 1) * Convert.ToInt32(limit);
                    int qtd = Convert.ToInt32(limit);

                    tmp.TotalItems = query.Count();
                    tmp.Items = query.Skip(start).Take(qtd);

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
                tmp.Items = await query.ToListAsync();
                return tmp;
            }
        }

        public async Task<ResultPage<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> filter = null, string[] includes = null, int? page = 1, int? limit = null)
        {

            var tresult = await GetQueryable(filter: filter, includes: includes, limit: limit, page: page);

            return tresult;
        }

        public Task<TEntity> GetByIdAsync(int id, string[] includes = null)
        {
            long ret = id;

            //var query = _context.Set<TEntity>().AsQueryable();

            //includes?.ToList().ForEach(navigation => query = query.Include(navigation));

            //query.First(p=>p.)

            return Task.FromResult(_context.Set<TEntity>().FindAsync(ret).Result);
        }

        public void Add(TEntity entity)
        {
            _context.Add(entity);
        }

        public void AddRange(IEnumerable<TEntity> entity)
        {
            _context.AddRange(entity);
        }

        public void Update(TEntity entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            _context.Update(entity);
        }


        public void DeleteAsync(int id)
        {
            var entity =  GetByIdAsync(id);
            _context.Entry(entity).State = EntityState.Deleted;
            _context.SaveChanges();
        }

        public void Merge(TEntity persisted, TEntity current)
        {
            _context.Entry(persisted).CurrentValues.SetValues(current);
        }

        public async Task CommitAsync()
        {

            await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private void Dispose(bool status)
        {
            if (!status) return;
            _context.Dispose();
        }
    }
}
