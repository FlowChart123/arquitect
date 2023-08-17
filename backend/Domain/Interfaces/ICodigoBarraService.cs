using Domain.Dto;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface ICodigoBarraService
    {
        public Task<ResultPage<CodigoBarraResult>> Page(int page, int size, string? ordeBy = "", string? orderDirection = "", string? search = "");
        public Task<IQueryable<CodigoBarraResult>> List();
        public Task<CodigoBarraResult> Load(Guid id);
        public CodigoBarra Insert(CodigoBarraInsertCommand model);
        public CodigoBarra Update(CodigoBarraUpdateCommand model);
        public void Delete(Guid id);

    }
}
