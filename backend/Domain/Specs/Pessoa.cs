using Domain.Dto;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Specs
{
    public static class PessoaSpecs
    {
        public static PessoaResult asPessoaResult(this Pessoa tmp)
        {
            return new PessoaResult()
            {
               Id = tmp.Id,
               Nome = tmp.Nome,
               DataCadastro = tmp.DataCadastro,
            };
        }

        public static Pessoa asPessoa(this PessoaInsertCommand tmp)
        {
            return new Pessoa()
            {
                Id = tmp.Id,
                Nome = tmp.Nome,
                DataCadastro=tmp.DataCadastro,
            };
        }
        public static Pessoa asPessoa(this PessoaUpdateCommand tmp)
        {
            return new Pessoa()
            {
                Id = tmp.Id,
                Nome = tmp.Nome,
                DataCadastro = tmp.DataCadastro
            };
        }

    }
}
