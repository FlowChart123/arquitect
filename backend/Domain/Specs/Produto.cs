using Domain.Dto;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Specs
{
    public static class ProdutoSpecs
    {
        public static ProdutoResult asProdutoResult(this Produto tmp)
        {
            return new ProdutoResult()
            {
               Id = tmp.Id,
            };
        }

        public static Produto asProduto(this ProdutoInsertCommand tmp)
        {
            return new Produto()
            {
                
            };
        }
        public static Produto asProduto(this ProdutoUpdateCommand tmp)
        {
            return new Produto()
            {                
                Id=tmp.Id,
            };
        }

    }
}
