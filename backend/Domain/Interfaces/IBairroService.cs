using Domain.Dto;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IBairroService
    {
        public Task<ResultPage<BairroResult>> Page(int page, int size, string? ordeBy = "", string? orderDirection = "", string? search = "");
        public Task<IQueryable<BairroResult>> List();
        public Task<BairroResult> Load(int id);
        public Bairro Insert(BairroInsertCommand model);
        public Bairro Update(BairroUpdateCommand model);
        public void Delete(int id);

    }
}
