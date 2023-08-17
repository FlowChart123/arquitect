using Domain.Dto;
using Domain.Interfaces;
using Domain.Interfaces.Repository;
using Entities.Models;
using Domain.Specs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Helpers.Extensions;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Domain.Services
{


    public class FilialLastMileGrupoItemService  : IFilialLastMileGrupoItemService
    {
        private readonly IRepositoy<FilialLastMileGrupoItem> _repo;
        private readonly IFilialLastMileGrupoItemRepository _FilialLastMileGrupoItem;

        public FilialLastMileGrupoItemService(IRepositoy<FilialLastMileGrupoItem> repo, IFilialLastMileGrupoItemRepository sup)
        {
            _repo = repo;
            _FilialLastMileGrupoItem = sup;
        }

        public void Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public FilialLastMileGrupoItem Insert(FilialLastMileGrupoItemInsertCommand model)
        {
            var data = DateTime.UtcNow;

            if (!string.IsNullOrEmpty(model.Nome))
            {
                return _repo.Insert(model.asFilialLastMileGrupoItem());
            }
            else throw new Exception("Campo nome está nulo"); //passar para classe de validacao no modelo
        }
      

        public Task<FilialLastMileGrupoItemResult> Load(Guid id)
        {            
            var res = _repo.Load(id);
            return Task.FromResult(res.asFilialLastMileGrupoItemResult());
        }

        public Task<ResultPage<FilialLastMileGrupoItemResult>> Page(int page, int size, string? ordeBy="", string? orderDirection = "", string? search = "")
        {
            IQueryable<FilialLastMileGrupoItemResult> result;
                        
            if (!string.IsNullOrEmpty(search) && search != "")
            {
                result = _FilialLastMileGrupoItem.Query().AsQueryable().Where(p => p.Nome.ToLower().Contains(search.ToLower()));
            }
            else
            {
                result = _FilialLastMileGrupoItem.Query().AsQueryable();
            }
            
            if (!string.IsNullOrEmpty(ordeBy))
            {
                string _direction = string.IsNullOrEmpty(orderDirection) ? "asc" : orderDirection;
                result = result.AsQueryable().DynamicOrderBy(ordeBy, _direction).AsQueryable();
            }

            int qtd = result.Count();
            result = result.AsQueryable().ToPage(page, size);
            
            ResultPage<FilialLastMileGrupoItemResult> tmp = new ResultPage<FilialLastMileGrupoItemResult>();
            tmp.Items = result;
            tmp.TotalItems = qtd;
            return Task.FromResult(tmp);
        }

        public FilialLastMileGrupoItem Update(FilialLastMileGrupoItemUpdateCommand model)
        {
            var data = DateTime.UtcNow;
            //model.DataAlteracao = data;

            //if (model.Pago)
            //{
            //    model.DataPagamento = data;
            //}

            if (!string.IsNullOrEmpty(model.Nome))
            {
                return _repo.Update(model.asFilialLastMileGrupoItem());
            }
            else throw new Exception("Campo nome está nulo"); //passar para classe de validacao no modelo
        }



        
        public Task<IQueryable<FilialLastMileGrupoItemResult>> List()
        {
            return Task.FromResult(_FilialLastMileGrupoItem.Query().AsQueryable());
        }


    }
}
