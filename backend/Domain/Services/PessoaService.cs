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


    public class PessoaService  : IPessoaService
    {
        private readonly IRepositoy<Pessoa> _repo;
        private readonly IPessoaRepository _Pessoa;

        public PessoaService(IRepositoy<Pessoa> repo, IPessoaRepository sup)
        {
            _repo = repo;
            _Pessoa = sup;
        }

        public void Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public Pessoa Insert(PessoaInsertCommand model)
        {
            var data = DateTime.UtcNow;

            if (!string.IsNullOrEmpty(model.Nome))
            {
                return _repo.Insert(model.asPessoa());
            }
            else throw new Exception("Campo nome está nulo"); //passar para classe de validacao no modelo
        }
      

        public Task<PessoaResult> Load(Guid id)
        {            
            var res = _repo.Load(id);
            return Task.FromResult(res.asPessoaResult());
        }

        public Task<ResultPage<PessoaResult>> Page(int page, int size, string? ordeBy="", string? orderDirection = "", string? search = "")
        {
            IQueryable<PessoaResult> result;
                        
            if (!string.IsNullOrEmpty(search) && search != "")
            {
                result = _Pessoa.Query().AsQueryable().Where(p => p.Nome.ToLower().Contains(search.ToLower()));
            }
            else
            {
                result = _Pessoa.Query().AsQueryable();
            }
            
            if (!string.IsNullOrEmpty(ordeBy))
            {
                string _direction = string.IsNullOrEmpty(orderDirection) ? "asc" : orderDirection;
                result = result.AsQueryable().DynamicOrderBy(ordeBy, _direction).AsQueryable();
            }

            int qtd = result.Count();
            result = result.AsQueryable().ToPage(page, size);
            
            ResultPage<PessoaResult> tmp = new ResultPage<PessoaResult>();
            tmp.Items = result;
            tmp.TotalItems = qtd;
            return Task.FromResult(tmp);
        }

        public Pessoa Update(PessoaUpdateCommand model)
        {
                        
            if (!string.IsNullOrEmpty(model.Nome))
            {
                var res = _repo.Load(model.Id);
                if (res != null)
                {
                    res.Nome = model.Nome;
                    return _repo.Update(res);
                }
                else
                {
                    throw new Exception(message: $"Registro com id {model.Id} não pode ser encontrado para alteração!");
                }
            }
            else throw new Exception("Campo nome está nulo"); //passar para classe de validacao no modelo
        }



        
        public Task<IQueryable<PessoaResult>> List()
        {
            return Task.FromResult(_Pessoa.Query().AsQueryable());
        }


    }
}
