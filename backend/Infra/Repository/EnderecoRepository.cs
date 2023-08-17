using Domain.Dto;
using Domain.Interfaces.Repository;
using Domain.Specs;
using Entities.Models;
using Infra.Abstract;
using Microsoft.EntityFrameworkCore;

namespace Infra.Repositorio
{
    public class EnderecoRepository : RepositoryBase<Endereco>, IEnderecoRepository
    {

        //IEnderecoREPOSITORY
        

        public IList<EnderecoResult> Query()
        {

            var res = _context.Enderecos.Select(o => o.asEnderecoResult()).ToList();
            return res;
        }
    }
}