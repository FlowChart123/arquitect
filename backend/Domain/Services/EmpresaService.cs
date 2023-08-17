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


    public class EmpresaService  : IEmpresaService
    {
        private readonly IRepositoy<Empresa> _repo;
        private readonly IEmpresaRepository _Empresa;

        public EmpresaService(IRepositoy<Empresa> repo, IEmpresaRepository sup)
        {
            _repo = repo;
            _Empresa = sup;
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Empresa Insert(EmpresaInsertCommand model)
        {
            var data = DateTime.UtcNow;

            if (!string.IsNullOrEmpty(model.Nome))
            {
                return _repo.Insert(model.asEmpresa());
            }
            else throw new Exception("Campo nome está nulo"); //passar para classe de validacao no modelo
        }
      

        public Task<EmpresaResult> Load(int id)
        {            
            var res = _repo.Load(id);
            return Task.FromResult(res.asEmpresaResult());
        }

        public Task<ResultPage<EmpresaResult>> Page(int page, int size, string? ordeBy="", string? orderDirection = "", string? search = "")
        {
            IQueryable<EmpresaResult> result;
                        
            if (!string.IsNullOrEmpty(search) && search != "")
            {
                result = _Empresa.Query().AsQueryable().Where(p => p.Nome.ToLower().Contains(search.ToLower()));
            }
            else
            {
                result = _Empresa.Query().AsQueryable();
            }
            
            if (!string.IsNullOrEmpty(ordeBy))
            {
                string _direction = string.IsNullOrEmpty(orderDirection) ? "asc" : orderDirection;
                result = result.AsQueryable().DynamicOrderBy(ordeBy, _direction).AsQueryable();
            }

            int qtd = result.Count();
            result = result.AsQueryable().ToPage(page, size);
            
            ResultPage<EmpresaResult> tmp = new ResultPage<EmpresaResult>();
            tmp.Items = result;
            tmp.TotalItems = qtd;
            return Task.FromResult(tmp);
        }

        public Empresa Update(EmpresaUpdateCommand model)
        {
            var data = DateTime.UtcNow;
            //model.DataAlteracao = data;

            //if (model.Pago)
            //{
            //    model.DataPagamento = data;
            //}

            if (!string.IsNullOrEmpty(model.Nome))
            {
                return _repo.Update(model.asEmpresa());
            }
            else throw new Exception("Campo nome está nulo"); //passar para classe de validacao no modelo
        }



        
        public Task<IQueryable<EmpresaResult>> List()
        {
            return Task.FromResult(_Empresa.Query().AsQueryable());
        }


    }
}
