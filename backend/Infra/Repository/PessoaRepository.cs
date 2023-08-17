using Domain.Dto;
using Domain.Interfaces.Repository;
using Domain.Specs;
using Entities.Models;
using Infra.Abstract;
using Microsoft.EntityFrameworkCore;

namespace Infra.Repositorio
{
    public class PessoaRepository : RepositoryBase<Pessoa>, IPessoaRepository
    {

        //IPessoaREPOSITORY
        

        public IList<PessoaResult> Query()
        {

            var res = _context.Pessoas.Select(o => o.asPessoaResult()).ToList();
            return res;
        }
    }
}