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


    public class ProdutoService  : IProdutoService
    {
        private readonly IRepositoy<Produto> _repo;
        private readonly IProdutoRepository _Produto;

        public ProdutoService(IRepositoy<Produto> repo, IProdutoRepository sup)
        {
            _repo = repo;
            _Produto = sup;
        }

        public void Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public Produto Insert(ProdutoInsertCommand model)
        {
            var data = DateTime.UtcNow;

            if (!string.IsNullOrEmpty(model.Nome))
            {
                return _repo.Insert(model.asProduto());
            }
            else throw new Exception("Campo nome está nulo"); //passar para classe de validacao no modelo
        }
      

        public Task<ProdutoResult> Load(Guid id)
        {            
            var res = _repo.Load(id);
            return Task.FromResult(res.asProdutoResult());
        }

        public Task<ResultPage<ProdutoResult>> Page(int page, int size, string? ordeBy="", string? orderDirection = "", string? search = "")
        {
            IQueryable<ProdutoResult> result;
                        
            if (!string.IsNullOrEmpty(search) && search != "")
            {
                result = _Produto.Query().AsQueryable().Where(p => p.Nome.ToLower().Contains(search.ToLower()));
            }
            else
            {
                result = _Produto.Query().AsQueryable();
            }
            
            if (!string.IsNullOrEmpty(ordeBy))
            {
                string _direction = string.IsNullOrEmpty(orderDirection) ? "asc" : orderDirection;
                result = result.AsQueryable().DynamicOrderBy(ordeBy, _direction).AsQueryable();
            }

            int qtd = result.Count();
            result = result.AsQueryable().ToPage(page, size);
            
            ResultPage<ProdutoResult> tmp = new ResultPage<ProdutoResult>();
            tmp.Items = result;
            tmp.TotalItems = qtd;
            return Task.FromResult(tmp);
        }

        public Produto Update(ProdutoUpdateCommand model)
        {
            var data = DateTime.UtcNow;
            //model.DataAlteracao = data;

            //if (model.Pago)
            //{
            //    model.DataPagamento = data;
            //}

            if (!string.IsNullOrEmpty(model.Nome))
            {
                return _repo.Update(model.asProduto());
            }
            else throw new Exception("Campo nome está nulo"); //passar para classe de validacao no modelo
        }



        
        public Task<IQueryable<ProdutoResult>> List()
        {
            return Task.FromResult(_Produto.Query().AsQueryable());
        }


    }
}
