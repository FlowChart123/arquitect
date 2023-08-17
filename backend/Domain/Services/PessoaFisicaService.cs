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


    public class PessoaFisicaService  : IPessoaFisicaService
    {
        private readonly IRepositoy<PessoaFisica> _repo;
        private readonly IPessoaFisicaRepository _PessoaFisica;

        public PessoaFisicaService(IRepositoy<PessoaFisica> repo, IPessoaFisicaRepository sup)
        {
            _repo = repo;
            _PessoaFisica = sup;
        }

        public void Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public PessoaFisica Insert(PessoaFisicaInsertCommand model)
        {
            var data = DateTime.UtcNow;

            if (!string.IsNullOrEmpty(model.Nome))
            {
                return _repo.Insert(model.asPessoaFisica());
            }
            else throw new Exception("Campo nome está nulo"); //passar para classe de validacao no modelo
        }
      

        public Task<PessoaFisicaResult> Load(Guid id)
        {            
            var res = _repo.Load(id);
            return Task.FromResult(res.asPessoaFisicaResult());
        }

        public Task<ResultPage<PessoaFisicaResult>> Page(int page, int size, string? ordeBy="", string? orderDirection = "", string? search = "")
        {
            IQueryable<PessoaFisicaResult> result;
                        
            if (!string.IsNullOrEmpty(search) && search != "")
            {
                result = _PessoaFisica.Query().AsQueryable().Where(p => p.Nome.ToLower().Contains(search.ToLower()));
            }
            else
            {
                result = _PessoaFisica.Query().AsQueryable();
            }
            
            if (!string.IsNullOrEmpty(ordeBy))
            {
                string _direction = string.IsNullOrEmpty(orderDirection) ? "asc" : orderDirection;
                result = result.AsQueryable().DynamicOrderBy(ordeBy, _direction).AsQueryable();
            }

            int qtd = result.Count();
            result = result.AsQueryable().ToPage(page, size);
            
            ResultPage<PessoaFisicaResult> tmp = new ResultPage<PessoaFisicaResult>();
            tmp.Items = result;
            tmp.TotalItems = qtd;
            return Task.FromResult(tmp);
        }

        public PessoaFisica Update(PessoaFisicaUpdateCommand model)
        {
            var data = DateTime.UtcNow;
            //model.DataAlteracao = data;

            //if (model.Pago)
            //{
            //    model.DataPagamento = data;
            //}

            if (!string.IsNullOrEmpty(model.Nome))
            {
                return _repo.Update(model.asPessoaFisica());
            }
            else throw new Exception("Campo nome está nulo"); //passar para classe de validacao no modelo
        }



        
        public Task<IQueryable<PessoaFisicaResult>> List()
        {
            return Task.FromResult(_PessoaFisica.Query().AsQueryable());
        }


    }
}
