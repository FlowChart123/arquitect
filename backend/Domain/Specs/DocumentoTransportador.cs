using Domain.Dto;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Specs
{
    public static class DocumentoTransportadorSpecs
    {
        public static DocumentoTransportadorResult asDocumentoTransportadorResult(this DocumentoTransportador tmp)
        {
            return new DocumentoTransportadorResult()
            {
               Id = tmp.Id,
            };
        }

        public static DocumentoTransportador asDocumentoTransportador(this DocumentoTransportadorInsertCommand tmp)
        {
            return new DocumentoTransportador()
            {
                
            };
        }
        public static DocumentoTransportador asDocumentoTransportador(this DocumentoTransportadorUpdateCommand tmp)
        {
            return new DocumentoTransportador()
            {                
                Id=tmp.Id,
            };
        }

    }
}
