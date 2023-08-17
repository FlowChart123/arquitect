using Domain.Dto;
using Domain.Interfaces.Repository;
using Domain.Specs;
using Entities.Models;
using Infra.Abstract;
using Microsoft.EntityFrameworkCore;

namespace Infra.Repositorio
{
    public class DocumentoImpostoRepository : RepositoryBase<DocumentoImposto>, IDocumentoImpostoRepository
    {

        //IDocumentoImpostoREPOSITORY
        

        public IList<DocumentoImpostoResult> Query()
        {

            var res = _context.DocumentoImpostos.Select(o => o.asDocumentoImpostoResult()).ToList();
            return res;
        }
    }
}