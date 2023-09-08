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
                IsFisica = tmp.PessoaFisica != null ? true : false,
                DocNum = tmp.PessoaFisica != null ? tmp.PessoaFisica.Cpf : tmp.PessoaJuridica != null ? tmp.PessoaJuridica.Cnpj : "",
                pessoaFisica = tmp.PessoaFisica!=null ? tmp.PessoaFisica : null
            };
        }

       
        public static Pessoa asPessoa(this PessoaInsertCommand tmp)
        {

            var p = new Pessoa()
            {             
                Nome = tmp.Nome,             
            };       

            if (tmp.pessoaFisica!=null)
            {
                p.PessoaFisica = tmp.pessoaFisica;
            }

            return p;
        }

        public static Pessoa asPessoa(this PessoaUpdateCommand tmp)
        {

            var p = new Pessoa()
            {
                Id = tmp.Id,
                Nome = tmp.Nome,
            };

            if (tmp.pessoaFisica != null)
            {
                p.PessoaFisica = tmp.pessoaFisica;
            }

            return p;
        }

    }
}
