using Domain.Dto;
using Domain.Interfaces.Repository;
using Domain.Specs;
using Entities.Models;
using Infra.Abstract;
using Microsoft.EntityFrameworkCore;

namespace Infra.Repositorio
{
    public class BairroRepository : RepositoryBase<Bairro>, IBairroRepository
    {

        //IBairroREPOSITORY       
        public IList<BairroResult> Query()
        {

            var res = _context.Bairros.Select(o => o.asBairroResult()).ToList();
            return res;
        }
    }
}