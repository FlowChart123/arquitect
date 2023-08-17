using Domain.Dto;
using Domain.Interfaces.Repository;
using Domain.Specs;
using Entities.Models;
using Infra.Abstract;
using Microsoft.EntityFrameworkCore;

namespace Infra.Repositorio
{
    public class DocumentoTotalRepository : RepositoryBase<DocumentoTotal>, IDocumentoTotalRepository
    {

        //IDocumentoTotalREPOSITORY
        

        public IList<DocumentoTotalResult> Query()
        {

            var res = _context.DocumentoTotals.Select(o => o.asDocumentoTotalResult()).ToList();
            return res;
        }
    }
}