using Domain.Dto;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Specs
{
    public static class BairroSpecs
    {
        public static BairroResult asBairroResult(this Bairro tmp)
        {
            return new BairroResult()
            {
               Id = tmp.Id,
            };
        }

        public static Bairro asBairro(this BairroInsertCommand tmp)
        {
            return new Bairro()
            {
                
            };
        }
        public static Bairro asBairro(this BairroUpdateCommand tmp)
        {
            return new Bairro()
            {                
                Id=tmp.Id,
            };
        }

    }
}
