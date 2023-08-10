using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Dto;
using Entities.Models;

namespace Domain.Interfaces
{
    public interface ISupplementService
    {
        public Task<IQueryable<SupplementResult>> Page(int page, int size, string? ordeBy="", string? orderDirection="", string? search="");
        public Task<IQueryable<SupplementResult>> List();
        public Task<SupplementResult> Load(object id);
        public Supplement Insert(SupplementInsertCommand model);
        public Supplement Update(SupplementUpdateCommand model);
        public void Delete(object id);
    }
}
