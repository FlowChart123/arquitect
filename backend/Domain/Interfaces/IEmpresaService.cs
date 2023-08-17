using Domain.Dto;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IEmpresaService
    {
        public Task<ResultPage<EmpresaResult>> Page(int page, int size, string? ordeBy = "", string? orderDirection = "", string? search = "");
        public Task<IQueryable<EmpresaResult>> List();
        public Task<EmpresaResult> Load(int id);
        public Empresa Insert(EmpresaInsertCommand model);
        public Empresa Update(EmpresaUpdateCommand model);
        public void Delete(int id);

    }
}
