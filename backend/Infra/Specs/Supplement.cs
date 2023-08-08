using Domain.Dto;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Specs
{
    public static class SupplementSpecs
    {       
        public static  SupplementDto asSupplementResult(this Supplement tmp)
        {
            return new SupplementDto()
            {
                id = tmp.Id,
                name = tmp.Name,
            };
        }

    }
}
