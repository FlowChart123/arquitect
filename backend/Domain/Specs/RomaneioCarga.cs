using Domain.Dto;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Specs
{
    public static class RomaneioCargaSpecs
    {
        public static RomaneioCargaResult asRomaneioCargaResult(this RomaneioCarga tmp)
        {
            return new RomaneioCargaResult()
            {
               Id = tmp.Id,
            };
        }

        public static RomaneioCarga asRomaneioCarga(this RomaneioCargaInsertCommand tmp)
        {
            return new RomaneioCarga()
            {
                
            };
        }
        public static RomaneioCarga asRomaneioCarga(this RomaneioCargaUpdateCommand tmp)
        {
            return new RomaneioCarga()
            {                
                Id=tmp.Id,
            };
        }

    }
}
