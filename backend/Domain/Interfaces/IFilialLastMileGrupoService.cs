using Domain.Dto;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IFilialLastMileGrupoService
    {
        public Task<ResultPage<FilialLastMileGrupoResult>> Page(int page, int size, string? ordeBy = "", string? orderDirection = "", string? search = "");
        public Task<IQueryable<FilialLastMileGrupoResult>> List();
        public Task<FilialLastMileGrupoResult> Load(Guid id);
        public FilialLastMileGrupo Insert(FilialLastMileGrupoInsertCommand model);
        public FilialLastMileGrupo Update(FilialLastMileGrupoUpdateCommand model);
        public void Delete(Guid id);

    }
}
