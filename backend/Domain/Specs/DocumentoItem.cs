using Domain.Dto;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Specs
{
    public static class DocumentoItemSpecs
    {
        public static DocumentoItemResult asDocumentoItemResult(this DocumentoItem tmp)
        {
            return new DocumentoItemResult()
            {
               Id = tmp.Id,
            };
        }

        public static DocumentoItem asDocumentoItem(this DocumentoItemInsertCommand tmp)
        {
            return new DocumentoItem()
            {
                
            };
        }
        public static DocumentoItem asDocumentoItem(this DocumentoItemUpdateCommand tmp)
        {
            return new DocumentoItem()
            {                
                Id=tmp.Id,
            };
        }

    }
}
