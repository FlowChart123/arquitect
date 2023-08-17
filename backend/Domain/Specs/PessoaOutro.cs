using Domain.Dto;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Specs
{
    public static class PessoaOutroSpecs
    {
        public static PessoaOutroResult asPessoaOutroResult(this PessoaOutro tmp)
        {
            return new PessoaOutroResult()
            {
               Id = tmp.Id,
            };
        }

        public static PessoaOutro asPessoaOutro(this PessoaOutroInsertCommand tmp)
        {
            return new PessoaOutro()
            {
                
            };
        }
        public static PessoaOutro asPessoaOutro(this PessoaOutroUpdateCommand tmp)
        {
            return new PessoaOutro()
            {                
                Id=tmp.Id,
            };
        }

    }
}
