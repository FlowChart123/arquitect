using Domain.Dto;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IEnderecoService
    {
        public Task<ResultPage<EnderecoResult>> Page(int page, int size, string? ordeBy = "", string? orderDirection = "", string? search = "");
        public Task<IQueryable<EnderecoResult>> List();
        public Task<EnderecoResult> Load(Guid id);
        public Endereco Insert(EnderecoInsertCommand model);
        public Endereco Update(EnderecoUpdateCommand model);
        public void Delete(Guid id);

    }
}
