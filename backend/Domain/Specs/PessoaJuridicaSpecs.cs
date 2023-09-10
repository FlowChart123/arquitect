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
                Cnpj = tmp.Cnpj,
                Fantasia = tmp.Fantasia,
                InscricaoEstadual = tmp.InscricaoEstadual,
                InscricaoMunicipal = tmp.InscricaoMunicipal                
            };
        }

       
        public static PessoaJuridica asPessoaJuridica(this PessoaJuridicaInsertCommand tmp)
        {

            var p = new PessoaJuridica()
            {
                Cnpj = tmp.Cnpj,
                Fantasia = tmp.Fantasia,
                InscricaoEstadual = tmp.InscricaoEstadual,
                InscricaoMunicipal = tmp.InscricaoMunicipal            
            };       
            return p;
        }

        public static PessoaJuridica asPessoaJuridica(this PessoaJuridicaUpdateCommand tmp)
        {

            var p = new PessoaJuridica()
            {
                Id = tmp.Id,
                Cnpj = tmp.Cnpj,
                Fantasia = tmp.Fantasia,
                InscricaoEstadual = tmp.InscricaoEstadual,
                InscricaoMunicipal = tmp.InscricaoMunicipal
            };

            return p;
        }

    }
}
