using Domain.Dto;
using Domain.Interfaces.Repository;
using Domain.Specs;
using Entities.Models;
using Infra.Abstract;
using Microsoft.EntityFrameworkCore;

namespace Infra.Repositorio
{
    public class RomaneioRepository : RepositoryBase<Romaneio>, IRomaneioRepository
    {

        //IRomaneioREPOSITORY
        

        public IList<RomaneioResult> Query()
        {

            var res = _context.Romaneios.Select(o => o.asRomaneioResult()).ToList();
            return res;
        }
    }
}