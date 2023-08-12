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


    public class SupplementService  : ISupplementService
    {
        private readonly IRepositoy<Supplement> _repo;
        private readonly ISupplement _supplement;

        public SupplementService(IRepositoy<Supplement> repo, ISupplement sup)
        {
            _repo = repo;
            _supplement = sup;
        }

        public void Delete(object id)
        {
            throw new NotImplementedException();
        }

        public Supplement Insert(SupplementInsertCommand model)
        {           
            return _repo.Insert(model.asSupplement());
        }

        public Task<IQueryable<SupplementResult>> List()
        {
            
            return Task.FromResult(_supplement.Query().OrderByDescending(p => p.id).AsQueryable());
        }

        public Task<SupplementResult> Load(int id)
        {            
            var res = _repo.Load(id);
            return Task.FromResult(res.asSupplementResult());
        }

        public Task<ResultPage<SupplementResult>> Page(int page, int size, string? ordeBy="", string? orderDirection = "", string? search = "")
        {
            IQueryable<SupplementResult> result;
                        
            if (!string.IsNullOrEmpty(search) && search != "")
            {
                result = _supplement.Query().AsQueryable().Where(p => p.name.ToLower().Contains(search.ToLower()));
            }
            else
            {
                result = _supplement.Query().AsQueryable();
            }
            
            if (!string.IsNullOrEmpty(ordeBy))
            {
                string _direction = string.IsNullOrEmpty(orderDirection) ? "asc" : orderDirection;
                result = result.AsQueryable().DynamicOrderBy(ordeBy, _direction).AsQueryable();
            }

            int qtd = result.Count();
            result = result.OrderByDescending(p => p.id).AsQueryable().ToPage(page, size);
            
            ResultPage<SupplementResult> tmp = new ResultPage<SupplementResult>();
            tmp.Items = result;
            tmp.TotalItems = qtd;
            return Task.FromResult(tmp);
        }

        public Supplement Update(SupplementUpdateCommand model)
        {            
            return _repo.Update(model.asSupplement());
        }

    }
}
