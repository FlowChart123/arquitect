using Domain.Dto;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IPessoaEnderecoService
    {
        public Task<ResultPage<PessoaEnderecoResult>> Page(int page, int size, string? ordeBy = "", string? orderDirection = "", string? search = "");
        public Task<IQueryable<PessoaEnderecoResult>> List();
        public Task<PessoaEnderecoResult> Load(Guid id);
        public PessoaEndereco Insert(PessoaEnderecoInsertCommand model);
        public PessoaEndereco Update(PessoaEnderecoUpdateCommand model);
        public void Delete(Guid id);

    }
}
