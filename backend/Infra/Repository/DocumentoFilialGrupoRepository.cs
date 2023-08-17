using Domain.Dto;
using Domain.Interfaces.Repository;
using Domain.Specs;
using Entities.Models;
using Infra.Abstract;
using Microsoft.EntityFrameworkCore;

namespace Infra.Repositorio
{
    public class DocumentoFilialGrupoRepository : RepositoryBase<DocumentoFilialGrupo>, IDocumentoFilialGrupoRepository
    {

        //IDocumentoFilialGrupoREPOSITORY
        

        public IList<DocumentoFilialGrupoResult> Query()
        {

            var res = _context.DocumentoFilialGrupos.Select(o => o.asDocumentoFilialGrupoResult()).ToList();
            return res;
        }
    }
}