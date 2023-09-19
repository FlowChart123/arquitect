using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Extensions
{
    public class GenericFilter<TEntity>
    {
        public Expression<Func<TEntity, bool>> AggregateAnd(Expression<Func<TEntity, bool>>[] input)
        {
            try
            {
                return input.Aggregate((l, r) => l.And(r));
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public GenericFilter()
        {
            this.filtro = new List<Expression<Func<TEntity, bool>>>();
        }

        public List<Expression<Func<TEntity, bool>>> filtro { get; set; }

        public void Set(Expression<Func<TEntity, bool>> condition)
        {
            this.filtro.Add(condition);
        }

        public Expression<Func<TEntity, bool>> Resume()
        {
            return AggregateAnd(filtro.ToArray());
        }
    }
}
