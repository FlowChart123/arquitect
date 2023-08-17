using Domain.Dto;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IDocumentoTotalService
    {
        public Task<ResultPage<DocumentoTotalResult>> Page(int page, int size, string? ordeBy = "", string? orderDirection = "", string? search = "");
        public Task<IQueryable<DocumentoTotalResult>> List();
        public Task<DocumentoTotalResult> Load(Guid id);
        public DocumentoTotal Insert(DocumentoTotalInsertCommand model);
        public DocumentoTotal Update(DocumentoTotalUpdateCommand model);
        public void Delete(Guid id);

    }
}
