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


    public class RomaneioService  : IRomaneioService
    {
        private readonly IRepositoy<Romaneio> _repo;
        private readonly IRomaneioRepository _Romaneio;

        public RomaneioService(IRepositoy<Romaneio> repo, IRomaneioRepository sup)
        {
            _repo = repo;
            _Romaneio = sup;
        }

        public void Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public Romaneio Insert(RomaneioInsertCommand model)
        {
            var data = DateTime.UtcNow;

            if (!string.IsNullOrEmpty(model.Nome))
            {
                return _repo.Insert(model.asRomaneio());
            }
            else throw new Exception("Campo nome está nulo"); //passar para classe de validacao no modelo
        }
      

        public Task<RomaneioResult> Load(Guid id)
        {            
            var res = _repo.Load(id);
            return Task.FromResult(res.asRomaneioResult());
        }

        public Task<ResultPage<RomaneioResult>> Page(int page, int size, string? ordeBy="", string? orderDirection = "", string? search = "")
        {
            IQueryable<RomaneioResult> result;
                        
            if (!string.IsNullOrEmpty(search) && search != "")
            {
                result = _Romaneio.Query().AsQueryable().Where(p => p.Nome.ToLower().Contains(search.ToLower()));
            }
            else
            {
                result = _Romaneio.Query().AsQueryable();
            }
            
            if (!string.IsNullOrEmpty(ordeBy))
            {
                string _direction = string.IsNullOrEmpty(orderDirection) ? "asc" : orderDirection;
                result = result.AsQueryable().DynamicOrderBy(ordeBy, _direction).AsQueryable();
            }

            int qtd = result.Count();
            result = result.AsQueryable().ToPage(page, size);
            
            ResultPage<RomaneioResult> tmp = new ResultPage<RomaneioResult>();
            tmp.Items = result;
            tmp.TotalItems = qtd;
            return Task.FromResult(tmp);
        }

        public Romaneio Update(RomaneioUpdateCommand model)
        {
            var data = DateTime.UtcNow;
            //model.DataAlteracao = data;

            //if (model.Pago)
            //{
            //    model.DataPagamento = data;
            //}

            if (!string.IsNullOrEmpty(model.Nome))
            {
                return _repo.Update(model.asRomaneio());
            }
            else throw new Exception("Campo nome está nulo"); //passar para classe de validacao no modelo
        }



        
        public Task<IQueryable<RomaneioResult>> List()
        {
            return Task.FromResult(_Romaneio.Query().AsQueryable());
        }


    }
}
