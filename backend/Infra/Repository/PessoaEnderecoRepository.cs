using Domain.Dto;
using Domain.Interfaces.Repository;
using Domain.Specs;
using Entities.Models;
using Infra.Abstract;
using Microsoft.EntityFrameworkCore;

namespace Infra.Repositorio
{
    public class PessoaEnderecoRepository : RepositoryBase<PessoaEndereco>, IPessoaEnderecoRepository
    {

        //IPessoaEnderecoREPOSITORY
        

        public IList<PessoaEnderecoResult> Query()
        {

            var res = _context.PessoaEnderecos.Select(o => o.asPessoaEnderecoResult()).ToList();
            return res;
        }
    }
}