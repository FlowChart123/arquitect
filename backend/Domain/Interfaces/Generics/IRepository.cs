using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces.Generics
{
    public interface IRepository<TEntity> : IDisposable where TEntity : BaseEntity
    {
        Task<ResultPage<TEntity>> GetQueryable(Expression<Func<TEntity, bool>> filter = null, string[] includes = null, int? page = 1, int? limit = null);
        Task<ResultPage<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> filter = null, string[] includes = null, int? page = 1, int? limit = null);
        Task<TEntity> GetByIdAsync(int id, string[] includes = null);
        void Add(TEntity entity);
        void AddRange(IEnumerable<TEntity> entity);
        void Update(TEntity entity);
        void DeleteAsync(int id);
        void Merge(TEntity persisted, TEntity current);
        Task CommitAsync();
    }
}
