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


    public class PessoaOutroService  : IPessoaOutroService
    {
        private readonly IRepositoy<PessoaOutro> _repo;
        private readonly IPessoaOutroRepository _PessoaOutro;

        public PessoaOutroService(IRepositoy<PessoaOutro> repo, IPessoaOutroRepository sup)
        {
            _repo = repo;
            _PessoaOutro = sup;
        }

        public void Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public PessoaOutro Insert(PessoaOutroInsertCommand model)
        {
            var data = DateTime.UtcNow;

            if (!string.IsNullOrEmpty(model.Nome))
            {
                return _repo.Insert(model.asPessoaOutro());
            }
            else throw new Exception("Campo nome está nulo"); //passar para classe de validacao no modelo
        }
      

        public Task<PessoaOutroResult> Load(Guid id)
        {            
            var res = _repo.Load(id);
            return Task.FromResult(res.asPessoaOutroResult());
        }

        public Task<ResultPage<PessoaOutroResult>> Page(int page, int size, string? ordeBy="", string? orderDirection = "", string? search = "")
        {
            IQueryable<PessoaOutroResult> result;
                        
            if (!string.IsNullOrEmpty(search) && search != "")
            {
                result = _PessoaOutro.Query().AsQueryable().Where(p => p.Nome.ToLower().Contains(search.ToLower()));
            }
            else
            {
                result = _PessoaOutro.Query().AsQueryable();
            }
            
            if (!string.IsNullOrEmpty(ordeBy))
            {
                string _direction = string.IsNullOrEmpty(orderDirection) ? "asc" : orderDirection;
                result = result.AsQueryable().DynamicOrderBy(ordeBy, _direction).AsQueryable();
            }

            int qtd = result.Count();
            result = result.AsQueryable().ToPage(page, size);
            
            ResultPage<PessoaOutroResult> tmp = new ResultPage<PessoaOutroResult>();
            tmp.Items = result;
            tmp.TotalItems = qtd;
            return Task.FromResult(tmp);
        }

        public PessoaOutro Update(PessoaOutroUpdateCommand model)
        {
            var data = DateTime.UtcNow;
            //model.DataAlteracao = data;

            //if (model.Pago)
            //{
            //    model.DataPagamento = data;
            //}

            if (!string.IsNullOrEmpty(model.Nome))
            {
                return _repo.Update(model.asPessoaOutro());
            }
            else throw new Exception("Campo nome está nulo"); //passar para classe de validacao no modelo
        }



        
        public Task<IQueryable<PessoaOutroResult>> List()
        {
            return Task.FromResult(_PessoaOutro.Query().AsQueryable());
        }


    }
}
