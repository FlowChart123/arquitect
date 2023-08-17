using Domain.Dto;
using Domain.Interfaces.Repository;
using Domain.Specs;
using Entities.Models;
using Infra.Abstract;
using Microsoft.EntityFrameworkCore;

namespace Infra.Repositorio
{
    public class DocumentoItemRepository : RepositoryBase<DocumentoItem>, IDocumentoItemRepository
    {

        //IDocumentoItemREPOSITORY
        

        public IList<DocumentoItemResult> Query()
        {

            var res = _context.DocumentoItems.Select(o => o.asDocumentoItemResult()).ToList();
            return res;
        }
    }
}