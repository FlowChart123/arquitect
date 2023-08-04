using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces.Generics
{
    public interface IService<T> : IDisposable
    {
        Task<ResultPage<T>> GetAllAsync(Expression<Func<T, bool>> filter = null, string[] includes = null, int? page = 1, int? limit = null);
        Task<T> GetByIdAsync(int id, string[] includes = null);
        Task AddAsync(T dto);
        Task UpdateAsync(T dto);
        Task DeleteAsync(int id);
    }
}
