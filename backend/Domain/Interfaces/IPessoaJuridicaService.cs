using Domain.Dto;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IPessoaJuridicaService
    {
        public Task<ResultPage<PessoaJuridicaResult>> Page(int page, int size, string? ordeBy = "", string? orderDirection = "", string? search = "");
        public Task<IQueryable<PessoaJuridicaResult>> List();
        public Task<PessoaJuridicaResult> Load(Guid id);
        public PessoaJuridica Insert(PessoaJuridicaInsertCommand model);
        public PessoaJuridica Update(PessoaJuridicaUpdateCommand model);
        public void Delete(Guid id);

    }
}
