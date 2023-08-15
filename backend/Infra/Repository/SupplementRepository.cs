using Domain.Dto;
using Domain.Interfaces.Repository;
using Domain.Specs;
using Entities.Models;
using Infra.Abstract;

namespace Infra.Repositorio
{
    public class SupplementRepository : RepositoryBase<Supplement>, ISupplement
    {
        //ISUPLEMENT
        public IList<SupplementResult> Query()
        {
            var res = _context.Supplements.Select(o => o.asSupplementResult()).ToList();
            return res;
        }
    }
}