using Domain.Dto;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IRomaneioCargaService
    {
        public Task<ResultPage<RomaneioCargaResult>> Page(int page, int size, string? ordeBy = "", string? orderDirection = "", string? search = "");
        public Task<IQueryable<RomaneioCargaResult>> List();
        public Task<RomaneioCargaResult> Load(Guid id);
        public RomaneioCarga Insert(RomaneioCargaInsertCommand model);
        public RomaneioCarga Update(RomaneioCargaUpdateCommand model);
        public void Delete(Guid id);

    }
}
