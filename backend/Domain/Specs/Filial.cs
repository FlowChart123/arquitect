using Domain.Dto;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Specs
{
    public static class FilialSpecs
    {
        public static FilialResult asFilialResult(this Filial tmp)
        {
            return new FilialResult()
            {
               Id = tmp.Id,
            };
        }

        public static Filial asFilial(this FilialInsertCommand tmp)
        {
            return new Filial()
            {
                
            };
        }
        public static Filial asFilial(this FilialUpdateCommand tmp)
        {
            return new Filial()
            {                
                Id=tmp.Id,
            };
        }

    }
}
