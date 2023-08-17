using Domain.Dto;
using Domain.Interfaces.Repository;
using Domain.Specs;
using Entities.Models;
using Infra.Abstract;
using Microsoft.EntityFrameworkCore;

namespace Infra.Repositorio
{
    public class DocumentoRepository : RepositoryBase<Documento>, IDocumentoRepository
    {

        //IDocumentoREPOSITORY
        

        public IList<DocumentoResult> Query()
        {

            var res = _context.Documentos.Select(o => o.asDocumentoResult()).ToList();
            return res;
        }
    }
}