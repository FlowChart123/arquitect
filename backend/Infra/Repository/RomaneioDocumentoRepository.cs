using Domain.Dto;
using Domain.Interfaces.Repository;
using Domain.Specs;
using Entities.Models;
using Infra.Abstract;
using Microsoft.EntityFrameworkCore;

namespace Infra.Repositorio
{
    public class RomaneioDocumentoRepository : RepositoryBase<RomaneioDocumento>, IRomaneioDocumentoRepository
    {

        //IRomaneioDocumentoREPOSITORY
        

        public IList<RomaneioDocumentoResult> Query()
        {

            var res = _context.RomaneioDocumentos.Select(o => o.asRomaneioDocumentoResult()).ToList();
            return res;
        }
    }
}