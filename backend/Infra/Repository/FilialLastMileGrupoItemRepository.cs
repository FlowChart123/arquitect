using Domain.Dto;
using Domain.Interfaces.Repository;
using Domain.Specs;
using Entities.Models;
using Infra.Abstract;
using Microsoft.EntityFrameworkCore;

namespace Infra.Repositorio
{
    public class FilialLastMileGrupoItemRepository : RepositoryBase<FilialLastMileGrupoItem>, IFilialLastMileGrupoItemRepository
    {

        //IFilialLastMileGrupoItemREPOSITORY
        

        public IList<FilialLastMileGrupoItemResult> Query()
        {

            var res = _context.FilialLastMileGrupoItems.Select(o => o.asFilialLastMileGrupoItemResult()).ToList();
            return res;
        }
    }
}