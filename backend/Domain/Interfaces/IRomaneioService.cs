using Domain.Dto;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IRomaneioService
    {
        public Task<ResultPage<RomaneioResult>> Page(int page, int size, string? ordeBy = "", string? orderDirection = "", string? search = "");
        public Task<IQueryable<RomaneioResult>> List();
        public Task<RomaneioResult> Load(Guid id);
        public Romaneio Insert(RomaneioInsertCommand model);
        public Romaneio Update(RomaneioUpdateCommand model);
        public void Delete(Guid id);

    }
}
