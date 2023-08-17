using Domain.Dto;
using Domain.Interfaces.Repository;
using Domain.Specs;
using Entities.Models;
using Infra.Abstract;
using Microsoft.EntityFrameworkCore;

namespace Infra.Repositorio
{
    public class RomaneioCargaRepository : RepositoryBase<RomaneioCarga>, IRomaneioCargaRepository
    {

        //IRomaneioCargaREPOSITORY
        

        public IList<RomaneioCargaResult> Query()
        {

            var res = _context.RomaneioCargas.Select(o => o.asRomaneioCargaResult()).ToList();
            return res;
        }
    }
}