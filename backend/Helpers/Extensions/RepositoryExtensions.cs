using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Helpers.Extensions
{
    public static class RepositoryExtensions
    {
        public static IQueryable<T> ToPage<T>(this IQueryable<T> Model, int page, int pageSize)
        {
            int start = (Convert.ToInt32(page) - 1) * Convert.ToInt32(pageSize);
            var items = Model.Skip(start).Take(pageSize).ToList();
            return items.AsQueryable();
        }
    }
}
