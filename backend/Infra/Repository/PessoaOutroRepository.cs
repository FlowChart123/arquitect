using Domain.Dto;
using Domain.Interfaces.Repository;
using Domain.Specs;
using Entities.Models;
using Infra.Abstract;
using Microsoft.EntityFrameworkCore;

namespace Infra.Repositorio
{
    public class PessoaOutroRepository : RepositoryBase<PessoaOutro>, IPessoaOutroRepository
    {

        //IPessoaOutroREPOSITORY
        

        public IList<PessoaOutroResult> Query()
        {

            var res = _context.PessoaOutros.Select(o => o.asPessoaOutroResult()).ToList();
            return res;
        }
    }
}