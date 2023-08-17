using Domain.Dto;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Specs
{
    public static class RomaneioSpecs
    {
        public static RomaneioResult asRomaneioResult(this Romaneio tmp)
        {
            return new RomaneioResult()
            {
               Id = tmp.Id,
            };
        }

        public static Romaneio asRomaneio(this RomaneioInsertCommand tmp)
        {
            return new Romaneio()
            {
                
            };
        }
        public static Romaneio asRomaneio(this RomaneioUpdateCommand tmp)
        {
            return new Romaneio()
            {                
                Id=tmp.Id,
            };
        }

    }
}
