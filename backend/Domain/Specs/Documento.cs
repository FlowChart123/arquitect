using Domain.Dto;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Specs
{
    public static class DocumentoSpecs
    {
        public static DocumentoResult asDocumentoResult(this Documento tmp)
        {
            return new DocumentoResult()
            {
               Id = tmp.Id,
            };
        }

        public static Documento asDocumento(this DocumentoInsertCommand tmp)
        {
            return new Documento()
            {
                
            };
        }
        public static Documento asDocumento(this DocumentoUpdateCommand tmp)
        {
            return new Documento()
            {                
                Id=tmp.Id,
            };
        }

    }
}
