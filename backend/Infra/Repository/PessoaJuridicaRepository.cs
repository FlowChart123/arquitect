using Domain.Dto;
using Domain.Interfaces.Repository;
using Domain.Specs;
using Entities.Models;
using Infra.Abstract;
using Microsoft.EntityFrameworkCore;

namespace Infra.Repositorio
{
    public class PessoaJuridicaRepository : RepositoryBase<PessoaJuridica>, IPessoaJuridicaRepository
    {

        //IPessoaJuridicaREPOSITORY
        

        public IList<PessoaJuridicaResult> Query()
        {

            var res = _context.PessoaJuridicas.Select(o => o.asPessoaJuridicaResult()).ToList();
            return res;
        }
    }
}