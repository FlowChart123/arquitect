using Domain.Dto;
using Domain.Interfaces.Repository;
using Domain.Specs;
using Entities.Models;
using Infra.Abstract;
using Microsoft.EntityFrameworkCore;

namespace Infra.Repositorio
{
    public class FilialRepository : RepositoryBase<Filial>, IFilialRepository
    {

        //IFilialREPOSITORY
        

        public IList<FilialResult> Query()
        {

            var res = _context.Filials.Select(o => o.asFilialResult()).ToList();
            return res;
        }
    }
}