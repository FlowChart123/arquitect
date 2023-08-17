using Domain.Dto;
using Domain.Interfaces.Repository;
using Domain.Specs;
using Entities.Models;
using Infra.Abstract;
using Microsoft.EntityFrameworkCore;

namespace Infra.Repositorio
{
    public class CodigoBarraRepository : RepositoryBase<CodigoBarra>, ICodigoBarraRepository
    {

        //ICodigoBarraREPOSITORY
        

        public IList<CodigoBarraResult> Query()
        {

            var res = _context.CodigoBarras.Select(o => o.asCodigoBarraResult()).ToList();
            return res;
        }
    }
}