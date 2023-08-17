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


    public class EnderecoService  : IEnderecoService
    {
        private readonly IRepositoy<Endereco> _repo;
        private readonly IEnderecoRepository _Endereco;

        public EnderecoService(IRepositoy<Endereco> repo, IEnderecoRepository sup)
        {
            _repo = repo;
            _Endereco = sup;
        }

        public void Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public Endereco Insert(EnderecoInsertCommand model)
        {
            var data = DateTime.UtcNow;

            if (!string.IsNullOrEmpty(model.Nome))
            {
                return _repo.Insert(model.asEndereco());
            }
            else throw new Exception("Campo nome está nulo"); //passar para classe de validacao no modelo
        }
      

        public Task<EnderecoResult> Load(Guid id)
        {            
            var res = _repo.Load(id);
            return Task.FromResult(res.asEnderecoResult());
        }

        public Task<ResultPage<EnderecoResult>> Page(int page, int size, string? ordeBy="", string? orderDirection = "", string? search = "")
        {
            IQueryable<EnderecoResult> result;
                        
            if (!string.IsNullOrEmpty(search) && search != "")
            {
                result = _Endereco.Query().AsQueryable().Where(p => p.Nome.ToLower().Contains(search.ToLower()));
            }
            else
            {
                result = _Endereco.Query().AsQueryable();
            }
            
            if (!string.IsNullOrEmpty(ordeBy))
            {
                string _direction = string.IsNullOrEmpty(orderDirection) ? "asc" : orderDirection;
                result = result.AsQueryable().DynamicOrderBy(ordeBy, _direction).AsQueryable();
            }

            int qtd = result.Count();
            result = result.AsQueryable().ToPage(page, size);
            
            ResultPage<EnderecoResult> tmp = new ResultPage<EnderecoResult>();
            tmp.Items = result;
            tmp.TotalItems = qtd;
            return Task.FromResult(tmp);
        }

        public Endereco Update(EnderecoUpdateCommand model)
        {
            var data = DateTime.UtcNow;
            //model.DataAlteracao = data;

            //if (model.Pago)
            //{
            //    model.DataPagamento = data;
            //}

            if (!string.IsNullOrEmpty(model.Nome))
            {
                return _repo.Update(model.asEndereco());
            }
            else throw new Exception("Campo nome está nulo"); //passar para classe de validacao no modelo
        }



        
        public Task<IQueryable<EnderecoResult>> List()
        {
            return Task.FromResult(_Endereco.Query().AsQueryable());
        }


    }
}
