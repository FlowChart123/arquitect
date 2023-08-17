using Domain.Dto;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Specs
{
    public static class EnderecoSpecs
    {
        public static EnderecoResult asEnderecoResult(this Endereco tmp)
        {
            return new EnderecoResult()
            {
               Id = tmp.Id,
            };
        }

        public static Endereco asEndereco(this EnderecoInsertCommand tmp)
        {
            return new Endereco()
            {
                
            };
        }
        public static Endereco asEndereco(this EnderecoUpdateCommand tmp)
        {
            return new Endereco()
            {                
                Id=tmp.Id,
            };
        }

    }
}
