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


    public class BairroService  : IBairroService
    {
        private readonly IRepositoy<Bairro> _repo;
        private readonly IBairroRepository _Bairro;

        public BairroService(IRepositoy<Bairro> repo, IBairroRepository sup)
        {
            _repo = repo;
            _Bairro = sup;
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Bairro Insert(BairroInsertCommand model)
        {
            var data = DateTime.UtcNow;

            if (!string.IsNullOrEmpty(model.Nome))
            {
                return _repo.Insert(model.asBairro());
            }
            else throw new Exception("Campo nome está nulo"); //passar para classe de validacao no modelo
        }
      

        public Task<BairroResult> Load(int id)
        {            
            var res = _repo.Load(id);
            return Task.FromResult(res.asBairroResult());
        }

        public Task<ResultPage<BairroResult>> Page(int page, int size, string? ordeBy="", string? orderDirection = "", string? search = "")
        {
            IQueryable<BairroResult> result;
                        
            if (!string.IsNullOrEmpty(search) && search != "")
            {
                result = _Bairro.Query().AsQueryable().Where(p => p.Nome.ToLower().Contains(search.ToLower()));
            }
            else
            {
                result = _Bairro.Query().AsQueryable();
            }
            
            if (!string.IsNullOrEmpty(ordeBy))
            {
                string _direction = string.IsNullOrEmpty(orderDirection) ? "asc" : orderDirection;
                result = result.AsQueryable().DynamicOrderBy(ordeBy, _direction).AsQueryable();
            }

            int qtd = result.Count();
            result = result.AsQueryable().ToPage(page, size);
            
            ResultPage<BairroResult> tmp = new ResultPage<BairroResult>();
            tmp.Items = result;
            tmp.TotalItems = qtd;
            return Task.FromResult(tmp);
        }

        public Bairro Update(BairroUpdateCommand model)
        {
            var data = DateTime.UtcNow;
            //model.DataAlteracao = data;

            //if (model.Pago)
            //{
            //    model.DataPagamento = data;
            //}

            if (!string.IsNullOrEmpty(model.Nome))
            {
                return _repo.Update(model.asBairro());
            }
            else throw new Exception("Campo nome está nulo"); //passar para classe de validacao no modelo
        }


     

        
        public Task<IQueryable<BairroResult>> List()
        {
            return Task.FromResult(_Bairro.Query().AsQueryable());
        }


    }
}
