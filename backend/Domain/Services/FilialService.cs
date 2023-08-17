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


    public class FilialService  : IFilialService
    {
        private readonly IRepositoy<Filial> _repo;
        private readonly IFilialRepository _Filial;

        public FilialService(IRepositoy<Filial> repo, IFilialRepository sup)
        {
            _repo = repo;
            _Filial = sup;
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Filial Insert(FilialInsertCommand model)
        {
            var data = DateTime.UtcNow;

            if (!string.IsNullOrEmpty(model.Nome))
            {
                return _repo.Insert(model.asFilial());
            }
            else throw new Exception("Campo nome está nulo"); //passar para classe de validacao no modelo
        }
      

        public Task<FilialResult> Load(int id)
        {            
            var res = _repo.Load(id);
            return Task.FromResult(res.asFilialResult());
        }

        public Task<ResultPage<FilialResult>> Page(int page, int size, string? ordeBy="", string? orderDirection = "", string? search = "")
        {
            IQueryable<FilialResult> result;
                        
            if (!string.IsNullOrEmpty(search) && search != "")
            {
                result = _Filial.Query().AsQueryable().Where(p => p.Nome.ToLower().Contains(search.ToLower()));
            }
            else
            {
                result = _Filial.Query().AsQueryable();
            }
            
            if (!string.IsNullOrEmpty(ordeBy))
            {
                string _direction = string.IsNullOrEmpty(orderDirection) ? "asc" : orderDirection;
                result = result.AsQueryable().DynamicOrderBy(ordeBy, _direction).AsQueryable();
            }

            int qtd = result.Count();
            result = result.AsQueryable().ToPage(page, size);
            
            ResultPage<FilialResult> tmp = new ResultPage<FilialResult>();
            tmp.Items = result;
            tmp.TotalItems = qtd;
            return Task.FromResult(tmp);
        }

        public Filial Update(FilialUpdateCommand model)
        {
            var data = DateTime.UtcNow;
            //model.DataAlteracao = data;

            //if (model.Pago)
            //{
            //    model.DataPagamento = data;
            //}

            if (!string.IsNullOrEmpty(model.Nome))
            {
                return _repo.Update(model.asFilial());
            }
            else throw new Exception("Campo nome está nulo"); //passar para classe de validacao no modelo
        }



        
        public Task<IQueryable<FilialResult>> List()
        {
            return Task.FromResult(_Filial.Query().AsQueryable());
        }


    }
}
