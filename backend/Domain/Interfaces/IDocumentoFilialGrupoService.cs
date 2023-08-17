using Domain.Dto;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IDocumentoFilialGrupoService
    {
        public Task<ResultPage<DocumentoFilialGrupoResult>> Page(int page, int size, string? ordeBy = "", string? orderDirection = "", string? search = "");
        public Task<IQueryable<DocumentoFilialGrupoResult>> List();
        public Task<DocumentoFilialGrupoResult> Load(Guid id);
        public DocumentoFilialGrupo Insert(DocumentoFilialGrupoInsertCommand model);
        public DocumentoFilialGrupo Update(DocumentoFilialGrupoUpdateCommand model);
        public void Delete(Guid id);

    }
}
