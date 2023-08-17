using Domain.Dto;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Specs
{
    public static class DocumentoImpostoSpecs
    {
        public static DocumentoImpostoResult asDocumentoImpostoResult(this DocumentoImposto tmp)
        {
            return new DocumentoImpostoResult()
            {
               Id = tmp.Id,
            };
        }

        public static DocumentoImposto asDocumentoImposto(this DocumentoImpostoInsertCommand tmp)
        {
            return new DocumentoImposto()
            {
                
            };
        }
        public static DocumentoImposto asDocumentoImposto(this DocumentoImpostoUpdateCommand tmp)
        {
            return new DocumentoImposto()
            {                
                Id=tmp.Id,
            };
        }

    }
}
