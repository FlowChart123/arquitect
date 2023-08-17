using Domain.Dto;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IDocumentoImpostoService
    {
        public Task<ResultPage<DocumentoImpostoResult>> Page(int page, int size, string? ordeBy = "", string? orderDirection = "", string? search = "");
        public Task<IQueryable<DocumentoImpostoResult>> List();
        public Task<DocumentoImpostoResult> Load(Guid id);
        public DocumentoImposto Insert(DocumentoImpostoInsertCommand model);
        public DocumentoImposto Update(DocumentoImpostoUpdateCommand model);
        public void Delete(Guid id);

    }
}
