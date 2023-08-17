using Domain.Dto;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IFilialLastMileGrupoItemService
    {
        public Task<ResultPage<FilialLastMileGrupoItemResult>> Page(int page, int size, string? ordeBy = "", string? orderDirection = "", string? search = "");
        public Task<IQueryable<FilialLastMileGrupoItemResult>> List();
        public Task<FilialLastMileGrupoItemResult> Load(Guid id);
        public FilialLastMileGrupoItem Insert(FilialLastMileGrupoItemInsertCommand model);
        public FilialLastMileGrupoItem Update(FilialLastMileGrupoItemUpdateCommand model);
        public void Delete(Guid id);

    }
}
