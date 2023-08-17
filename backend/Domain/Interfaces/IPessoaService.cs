using Domain.Dto;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IPessoaService
    {
        public Task<ResultPage<PessoaResult>> Page(int page, int size, string? ordeBy = "", string? orderDirection = "", string? search = "");
        public Task<IQueryable<PessoaResult>> List();
        public Task<PessoaResult> Load(Guid id);
        public Pessoa Insert(PessoaInsertCommand model);
        public Pessoa Update(PessoaUpdateCommand model);
        public void Delete(Guid id);

    }
}
