using Domain.Dto;
using Domain.Interfaces.Repository;
using Domain.Specs;
using Entities.Models;
using Infra.Abstract;
using Microsoft.EntityFrameworkCore;

namespace Infra.Repositorio
{
    public class EmpresaRepository : RepositoryBase<Empresa>, IEmpresaRepository
    {

        //IEmpresaREPOSITORY
        

        public IList<EmpresaResult> Query()
        {

            var res = _context.Empresas.Select(o => o.asEmpresaResult()).ToList();
            return res;
        }
    }
}