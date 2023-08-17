using Domain.Dto;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IPessoaOutroService
    {
        public Task<ResultPage<PessoaOutroResult>> Page(int page, int size, string? ordeBy = "", string? orderDirection = "", string? search = "");
        public Task<IQueryable<PessoaOutroResult>> List();
        public Task<PessoaOutroResult> Load(Guid id);
        public PessoaOutro Insert(PessoaOutroInsertCommand model);
        public PessoaOutro Update(PessoaOutroUpdateCommand model);
        public void Delete(Guid id);

    }
}
