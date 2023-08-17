using Domain.Dto;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Specs
{
    public static class RomaneioDocumentoSpecs
    {
        public static RomaneioDocumentoResult asRomaneioDocumentoResult(this RomaneioDocumento tmp)
        {
            return new RomaneioDocumentoResult()
            {
               Id = tmp.Id,
            };
        }

        public static RomaneioDocumento asRomaneioDocumento(this RomaneioDocumentoInsertCommand tmp)
        {
            return new RomaneioDocumento()
            {
                
            };
        }
        public static RomaneioDocumento asRomaneioDocumento(this RomaneioDocumentoUpdateCommand tmp)
        {
            return new RomaneioDocumento()
            {                
                Id=tmp.Id,
            };
        }

    }
}
