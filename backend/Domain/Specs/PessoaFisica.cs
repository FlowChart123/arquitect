using Domain.Dto;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Specs
{
    public static class PessoaFisicaSpecs
    {
        public static PessoaFisicaResult asPessoaFisicaResult(this PessoaFisica tmp)
        {
            return new PessoaFisicaResult()
            {
               Id = tmp.Id,
            };
        }

        public static PessoaFisica asPessoaFisica(this PessoaFisicaInsertCommand tmp)
        {
            return new PessoaFisica()
            {
                
            };
        }
        public static PessoaFisica asPessoaFisica(this PessoaFisicaUpdateCommand tmp)
        {
            return new PessoaFisica()
            {                
                Id=tmp.Id,
            };
        }

    }
}
