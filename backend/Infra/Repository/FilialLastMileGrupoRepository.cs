using Domain.Dto;
using Domain.Interfaces.Repository;
using Domain.Specs;
using Entities.Models;
using Infra.Abstract;
using Microsoft.EntityFrameworkCore;

namespace Infra.Repositorio
{
    public class FilialLastMileGrupoRepository : RepositoryBase<FilialLastMileGrupo>, IFilialLastMileGrupoRepository
    {

        //IFilialLastMileGrupoREPOSITORY
        

        public IList<FilialLastMileGrupoResult> Query()
        {

            var res = _context.FilialLastMileGrupos.Select(o => o.asFilialLastMileGrupoResult()).ToList();
            return res;
        }
    }
}