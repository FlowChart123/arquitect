using Domain.Dto;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IPessoaFisicaService
    {
        public Task<ResultPage<PessoaFisicaResult>> Page(int page, int size, string? ordeBy = "", string? orderDirection = "", string? search = "");
        public Task<IQueryable<PessoaFisicaResult>> List();
        public Task<PessoaFisicaResult> Load(Guid id);
        public PessoaFisica Insert(PessoaFisicaInsertCommand model);
        public PessoaFisica Update(PessoaFisicaUpdateCommand model);
        public void Delete(Guid id);

    }
}
