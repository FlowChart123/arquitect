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


    public class PessoaJuridicaService  : IPessoaJuridicaService
    {
        private readonly IRepositoy<PessoaJuridica> _repo;
        private readonly IPessoaJuridicaRepository _PessoaJuridica;

        public PessoaJuridicaService(IRepositoy<PessoaJuridica> repo, IPessoaJuridicaRepository sup)
        {
            _repo = repo;
            _PessoaJuridica = sup;
        }

        public void Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public PessoaJuridica Insert(PessoaJuridicaInsertCommand model)
        {
            var data = DateTime.UtcNow;

            if (!string.IsNullOrEmpty(model.Nome))
            {
                return _repo.Insert(model.asPessoaJuridica());
            }
            else throw new Exception("Campo nome está nulo"); //passar para classe de validacao no modelo
        }
      

        public Task<PessoaJuridicaResult> Load(Guid id)
        {            
            var res = _repo.Load(id);
            return Task.FromResult(res.asPessoaJuridicaResult());
        }

        public Task<ResultPage<PessoaJuridicaResult>> Page(int page, int size, string? ordeBy="", string? orderDirection = "", string? search = "")
        {
            IQueryable<PessoaJuridicaResult> result;
                        
            if (!string.IsNullOrEmpty(search) && search != "")
            {
                result = _PessoaJuridica.Query().AsQueryable().Where(p => p.Nome.ToLower().Contains(search.ToLower()));
            }
            else
            {
                result = _PessoaJuridica.Query().AsQueryable();
            }
            
            if (!string.IsNullOrEmpty(ordeBy))
            {
                string _direction = string.IsNullOrEmpty(orderDirection) ? "asc" : orderDirection;
                result = result.AsQueryable().DynamicOrderBy(ordeBy, _direction).AsQueryable();
            }

            int qtd = result.Count();
            result = result.AsQueryable().ToPage(page, size);
            
            ResultPage<PessoaJuridicaResult> tmp = new ResultPage<PessoaJuridicaResult>();
            tmp.Items = result;
            tmp.TotalItems = qtd;
            return Task.FromResult(tmp);
        }

        public PessoaJuridica Update(PessoaJuridicaUpdateCommand model)
        {
            var data = DateTime.UtcNow;
            //model.DataAlteracao = data;

            //if (model.Pago)
            //{
            //    model.DataPagamento = data;
            //}

            if (!string.IsNullOrEmpty(model.Nome))
            {
                return _repo.Update(model.asPessoaJuridica());
            }
            else throw new Exception("Campo nome está nulo"); //passar para classe de validacao no modelo
        }



        
        public Task<IQueryable<PessoaJuridicaResult>> List()
        {
            return Task.FromResult(_PessoaJuridica.Query().AsQueryable());
        }


    }
}
