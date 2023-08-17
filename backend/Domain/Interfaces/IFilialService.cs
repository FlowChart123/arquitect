using Domain.Dto;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IFilialService
    {
        public Task<ResultPage<FilialResult>> Page(int page, int size, string? ordeBy = "", string? orderDirection = "", string? search = "");
        public Task<IQueryable<FilialResult>> List();
        public Task<FilialResult> Load(int id);
        public Filial Insert(FilialInsertCommand model);
        public Filial Update(FilialUpdateCommand model);
        public void Delete(int id);

    }
}
