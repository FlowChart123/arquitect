using Domain.Dto;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Specs
{
    public static class SupplementSpecs
    {       
        public static  SupplementResult asSupplementResult(this Supplement tmp)
        {
            return new SupplementResult()
            {
                id = tmp.Id,
                name = tmp.Name,
            };
        }

        public static Supplement asSupplement(this SupplementInsertCommand tmp)
        {
            return new Supplement()
            {                
                Name=tmp.Name
            };
        }
        public static Supplement asSupplement(this SupplementUpdateCommand tmp)
        {
            return new Supplement()
            {
                Id =tmp.Id,
                Name = tmp.Name
            };
        }

    }
}
