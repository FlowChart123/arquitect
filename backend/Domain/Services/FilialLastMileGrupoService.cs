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


    public class FilialLastMileGrupoService  : IFilialLastMileGrupoService
    {
        private readonly IRepositoy<FilialLastMileGrupo> _repo;
        private readonly IFilialLastMileGrupoRepository _FilialLastMileGrupo;

        public FilialLastMileGrupoService(IRepositoy<FilialLastMileGrupo> repo, IFilialLastMileGrupoRepository sup)
        {
            _repo = repo;
            _FilialLastMileGrupo = sup;
        }

        public void Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public FilialLastMileGrupo Insert(FilialLastMileGrupoInsertCommand model)
        {
            var data = DateTime.UtcNow;

            if (!string.IsNullOrEmpty(model.Nome))
            {
                return _repo.Insert(model.asFilialLastMileGrupo());
            }
            else throw new Exception("Campo nome está nulo"); //passar para classe de validacao no modelo
        }
      

        public Task<FilialLastMileGrupoResult> Load(Guid id)
        {            
            var res = _repo.Load(id);
            return Task.FromResult(res.asFilialLastMileGrupoResult());
        }

        public Task<ResultPage<FilialLastMileGrupoResult>> Page(int page, int size, string? ordeBy="", string? orderDirection = "", string? search = "")
        {
            IQueryable<FilialLastMileGrupoResult> result;
                        
            if (!string.IsNullOrEmpty(search) && search != "")
            {
                result = _FilialLastMileGrupo.Query().AsQueryable().Where(p => p.Nome.ToLower().Contains(search.ToLower()));
            }
            else
            {
                result = _FilialLastMileGrupo.Query().AsQueryable();
            }
            
            if (!string.IsNullOrEmpty(ordeBy))
            {
                string _direction = string.IsNullOrEmpty(orderDirection) ? "asc" : orderDirection;
                result = result.AsQueryable().DynamicOrderBy(ordeBy, _direction).AsQueryable();
            }

            int qtd = result.Count();
            result = result.AsQueryable().ToPage(page, size);
            
            ResultPage<FilialLastMileGrupoResult> tmp = new ResultPage<FilialLastMileGrupoResult>();
            tmp.Items = result;
            tmp.TotalItems = qtd;
            return Task.FromResult(tmp);
        }

        public FilialLastMileGrupo Update(FilialLastMileGrupoUpdateCommand model)
        {
            var data = DateTime.UtcNow;
            //model.DataAlteracao = data;

            //if (model.Pago)
            //{
            //    model.DataPagamento = data;
            //}

            if (!string.IsNullOrEmpty(model.Nome))
            {
                return _repo.Update(model.asFilialLastMileGrupo());
            }
            else throw new Exception("Campo nome está nulo"); //passar para classe de validacao no modelo
        }



        
        public Task<IQueryable<FilialLastMileGrupoResult>> List()
        {
            return Task.FromResult(_FilialLastMileGrupo.Query().AsQueryable());
        }


    }
}
