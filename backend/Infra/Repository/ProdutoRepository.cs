using Domain.Dto;
using Domain.Interfaces.Repository;
using Domain.Specs;
using Entities.Models;
using Infra.Abstract;
using Microsoft.EntityFrameworkCore;

namespace Infra.Repositorio
{
    public class ProdutoRepository : RepositoryBase<Produto>, IProdutoRepository
    {

        //IProdutoREPOSITORY
        

        public IList<ProdutoResult> Query()
        {

            var res = _context.Produtos.Select(o => o.asProdutoResult()).ToList();
            return res;
        }
    }
}