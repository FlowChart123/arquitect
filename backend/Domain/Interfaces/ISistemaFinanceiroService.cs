using Domain.Dto;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface ISistemaFinanceiroService
    {
        public Task<ResultPage<SistemaFinanceiroResult>> Page(int page, int size, string? ordeBy = "", string? orderDirection = "", string? search = "");
        public Task<IQueryable<SistemaFinanceiroResult>> List();
        public Task<SistemaFinanceiroResult> Load(int id);
        public SistemaFinanceiro Insert(SistemaFinanceiroInsertCommand model);
        public SistemaFinanceiro Update(SistemaFinanceiroUpdateCommand model);
        public void Delete(int id);
        public Task<IList<SistemaFinanceiroResult>> ListarSistemasUsuario(string emailUsuario);
    }
}
