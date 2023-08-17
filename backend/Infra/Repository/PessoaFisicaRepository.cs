using Domain.Dto;
using Domain.Interfaces.Repository;
using Domain.Specs;
using Entities.Models;
using Infra.Abstract;
using Microsoft.EntityFrameworkCore;

namespace Infra.Repositorio
{
    public class PessoaFisicaRepository : RepositoryBase<PessoaFisica>, IPessoaFisicaRepository
    {

        //IPessoaFisicaREPOSITORY
        

        public IList<PessoaFisicaResult> Query()
        {

            var res = _context.PessoaFisicas.Select(o => o.asPessoaFisicaResult()).ToList();
            return res;
        }
    }
}