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


    public class SistemaFinanceiroService : ISistemaFinanceiroService
    {
        private readonly IRepositoy<SistemaFinanceiro> _repo;
        private readonly ISistemaFinanceiroRepository _SistemaFinanceiro;

        public SistemaFinanceiroService(IRepositoy<SistemaFinanceiro> repo, ISistemaFinanceiroRepository sup)
        {
            _repo = repo;
            _SistemaFinanceiro = sup;
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public SistemaFinanceiro Insert(SistemaFinanceiroInsertCommand model)
        {
            var data = DateTime.UtcNow;
            model.Ano = data.Year;
            model.Mes = data.Month;

            if (!string.IsNullOrEmpty(model.Nome))
            {
                var t = model.asSistemaFinanceiro();
                return _repo.Insert(t);
            }
            else throw new Exception("Campo nome está nulo"); //passar para classe de validacao no modelo
        }
      

        public Task<SistemaFinanceiroResult> Load(int id)
        {            
            var res = _repo.Load(id);
            return Task.FromResult(res.asSistemaFinanceiroResult());
        }

        public Task<ResultPage<SistemaFinanceiroResult>> Page(int page, int size, string? ordeBy="", string? orderDirection = "", string? search = "")
        {
            IQueryable<SistemaFinanceiroResult> result;
                        
            if (!string.IsNullOrEmpty(search) && search != "")
            {
                result = _SistemaFinanceiro.Query().AsQueryable().Where(p => p.Nome.ToLower().Contains(search.ToLower()));
            }
            else
            {
                result = _SistemaFinanceiro.Query().AsQueryable();
            }
            
            if (!string.IsNullOrEmpty(ordeBy))
            {
                string _direction = string.IsNullOrEmpty(orderDirection) ? "asc" : orderDirection;
                result = result.AsQueryable().DynamicOrderBy(ordeBy, _direction).AsQueryable();
            }

            int qtd = result.Count();
            result = result.AsQueryable().ToPage(page, size);
            
            ResultPage<SistemaFinanceiroResult> tmp = new ResultPage<SistemaFinanceiroResult>();
            tmp.Items = result;
            tmp.TotalItems = qtd;
            return Task.FromResult(tmp);
        }

        public SistemaFinanceiro Update(SistemaFinanceiroUpdateCommand model)
        {
            var data = DateTime.UtcNow;
            
            if (!string.IsNullOrEmpty(model.Nome))
            {
                return _repo.Update(model.asSistemaFinanceiro());
            }
            else throw new Exception("Campo nome está nulo"); //passar para classe de validacao no modelo
        }


        public Task<IList<SistemaFinanceiroResult>> ListarSistemasUsuario(string emailUsuario)
        {
            var res = _SistemaFinanceiro.ListaSistemasUsuario(emailUsuario);
            return res;
        }

        public Task<IQueryable<SistemaFinanceiroResult>> List()
        {
            return Task.FromResult(_SistemaFinanceiro.Query().AsQueryable());
        }
    }
}
