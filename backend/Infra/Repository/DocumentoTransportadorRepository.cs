using Domain.Dto;
using Domain.Interfaces.Repository;
using Domain.Specs;
using Entities.Models;
using Infra.Abstract;
using Microsoft.EntityFrameworkCore;

namespace Infra.Repositorio
{
    public class DocumentoTransportadorRepository : RepositoryBase<DocumentoTransportador>, IDocumentoTransportadorRepository
    {

        //IDocumentoTransportadorREPOSITORY
        

        public IList<DocumentoTransportadorResult> Query()
        {

            var res = _context.DocumentoTransportadors.Select(o => o.asDocumentoTransportadorResult()).ToList();
            return res;
        }
    }
}