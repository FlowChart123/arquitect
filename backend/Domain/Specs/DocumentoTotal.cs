using Domain.Dto;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Specs
{
    public static class DocumentoTotalSpecs
    {
        public static DocumentoTotalResult asDocumentoTotalResult(this DocumentoTotal tmp)
        {
            return new DocumentoTotalResult()
            {
               Id = tmp.Id,
            };
        }

        public static DocumentoTotal asDocumentoTotal(this DocumentoTotalInsertCommand tmp)
        {
            return new DocumentoTotal()
            {
                
            };
        }
        public static DocumentoTotal asDocumentoTotal(this DocumentoTotalUpdateCommand tmp)
        {
            return new DocumentoTotal()
            {                
                Id=tmp.Id,
            };
        }

    }
}
