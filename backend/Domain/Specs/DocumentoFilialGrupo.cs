using Domain.Dto;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Specs
{
    public static class DocumentoFilialGrupoSpecs
    {
        public static DocumentoFilialGrupoResult asDocumentoFilialGrupoResult(this DocumentoFilialGrupo tmp)
        {
            return new DocumentoFilialGrupoResult()
            {
               Id = tmp.Id,
            };
        }

        public static DocumentoFilialGrupo asDocumentoFilialGrupo(this DocumentoFilialGrupoInsertCommand tmp)
        {
            return new DocumentoFilialGrupo()
            {
                
            };
        }
        public static DocumentoFilialGrupo asDocumentoFilialGrupo(this DocumentoFilialGrupoUpdateCommand tmp)
        {
            return new DocumentoFilialGrupo()
            {                
                Id=tmp.Id,
            };
        }

    }
}
