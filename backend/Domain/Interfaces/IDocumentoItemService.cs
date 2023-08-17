using Domain.Dto;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IDocumentoItemService
    {
        public Task<ResultPage<DocumentoItemResult>> Page(int page, int size, string? ordeBy = "", string? orderDirection = "", string? search = "");
        public Task<IQueryable<DocumentoItemResult>> List();
        public Task<DocumentoItemResult> Load(Guid id);
        public DocumentoItem Insert(DocumentoItemInsertCommand model);
        public DocumentoItem Update(DocumentoItemUpdateCommand model);
        public void Delete(Guid id);

    }
}
