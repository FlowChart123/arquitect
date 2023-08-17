using Domain.Dto;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IProdutoService
    {
        public Task<ResultPage<ProdutoResult>> Page(int page, int size, string? ordeBy = "", string? orderDirection = "", string? search = "");
        public Task<IQueryable<ProdutoResult>> List();
        public Task<ProdutoResult> Load(Guid id);
        public Produto Insert(ProdutoInsertCommand model);
        public Produto Update(ProdutoUpdateCommand model);
        public void Delete(Guid id);

    }
}
