using Domain.Dto;
using Entities.Models;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces.Repository
{
    public interface IRepositoy<TEntity> 
    {
        public Task<ResultPage<TEntity>> List(Expression<Func<TEntity, bool>> filter = null, string[] includes = null, int? page = 1, int? limit = null);
        public Task<TEntity> Load(object id, string[]? includes = null);        
        public void Insert(TEntity entity);
        public void Delete(int id);
        public void Delete(Guid id);
        public void Update(TEntity entity);
        public void InsertOrUpdate(TEntity entity);
        public void UpdateChildCollection<Tparent, Tid, Tchild>(Tparent dbItem, Tparent newItem, Func<Tparent, IEnumerable<Tchild>> selector, Func<Tchild, Tid> idSelector) where Tchild : class;       
        void Save();
    }
}
