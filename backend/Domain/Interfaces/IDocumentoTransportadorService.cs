using Domain.Dto;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IDocumentoTransportadorService
    {
        public Task<ResultPage<DocumentoTransportadorResult>> Page(int page, int size, string? ordeBy = "", string? orderDirection = "", string? search = "");
        public Task<IQueryable<DocumentoTransportadorResult>> List();
        public Task<DocumentoTransportadorResult> Load(Guid id);
        public DocumentoTransportador Insert(DocumentoTransportadorInsertCommand model);
        public DocumentoTransportador Update(DocumentoTransportadorUpdateCommand model);
        public void Delete(Guid id);

    }
}
