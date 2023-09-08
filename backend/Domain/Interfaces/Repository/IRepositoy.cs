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
        public void UpdateChildCollection<Tparent, Tid, Tchild>(Tparent dbItem, Tparent newItem, Func<Tparent, IEnumerable<Tchild>> selector, Func<Tchild, Tid> idSelector) where Tchild : class;
        public TEntity InsertOrUpdate(TEntity entity);
        public TEntity Insert(TEntity entity);
        public TEntity Update(TEntity entity);
        public TEntity Load(int? id, Guid? guid);
        public void Delete(int? id, Guid guid);
        public void Save();

    }
}

