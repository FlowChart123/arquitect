using Domain.Dto;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IRomaneioDocumentoService
    {
        public Task<ResultPage<RomaneioDocumentoResult>> Page(int page, int size, string? ordeBy = "", string? orderDirection = "", string? search = "");
        public Task<IQueryable<RomaneioDocumentoResult>> List();
        public Task<RomaneioDocumentoResult> Load(Guid id);
        public RomaneioDocumento Insert(RomaneioDocumentoInsertCommand model);
        public RomaneioDocumento Update(RomaneioDocumentoUpdateCommand model);
        public void Delete(Guid id);

    }
}
