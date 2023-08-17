using Domain.Dto;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IDocumentoService
    {
        public Task<ResultPage<DocumentoResult>> Page(int page, int size, string? ordeBy = "", string? orderDirection = "", string? search = "");
        public Task<IQueryable<DocumentoResult>> List();
        public Task<DocumentoResult> Load(Guid id);
        public Documento Insert(DocumentoInsertCommand model);
        public Documento Update(DocumentoUpdateCommand model);
        public void Delete(Guid id);

    }
}
