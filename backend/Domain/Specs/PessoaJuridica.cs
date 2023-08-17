using Domain.Dto;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Specs
{
    public static class PessoaJuridicaSpecs
    {
        public static PessoaJuridicaResult asPessoaJuridicaResult(this PessoaJuridica tmp)
        {
            return new PessoaJuridicaResult()
            {
               Id = tmp.Id,
            };
        }

        public static PessoaJuridica asPessoaJuridica(this PessoaJuridicaInsertCommand tmp)
        {
            return new PessoaJuridica()
            {
                
            };
        }
        public static PessoaJuridica asPessoaJuridica(this PessoaJuridicaUpdateCommand tmp)
        {
            return new PessoaJuridica()
            {                
                Id=tmp.Id,
            };
        }

    }
}
