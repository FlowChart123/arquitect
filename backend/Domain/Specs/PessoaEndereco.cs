using Domain.Dto;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Specs
{
    public static class PessoaEnderecoSpecs
    {
        public static PessoaEnderecoResult asPessoaEnderecoResult(this PessoaEndereco tmp)
        {
            return new PessoaEnderecoResult()
            {
               Id = tmp.Id,
            };
        }

        public static PessoaEndereco asPessoaEndereco(this PessoaEnderecoInsertCommand tmp)
        {
            return new PessoaEndereco()
            {
                
            };
        }
        public static PessoaEndereco asPessoaEndereco(this PessoaEnderecoUpdateCommand tmp)
        {
            return new PessoaEndereco()
            {                
                Id=tmp.Id,
            };
        }

    }
}
