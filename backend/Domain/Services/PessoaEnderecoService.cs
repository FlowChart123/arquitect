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


    public class PessoaEnderecoService  : IPessoaEnderecoService
    {
        private readonly IRepositoy<PessoaEndereco> _repo;
        private readonly IPessoaEnderecoRepository _PessoaEndereco;

        public PessoaEnderecoService(IRepositoy<PessoaEndereco> repo, IPessoaEnderecoRepository sup)
        {
            _repo = repo;
            _PessoaEndereco = sup;
        }

        public void Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public PessoaEndereco Insert(PessoaEnderecoInsertCommand model)
        {
            var data = DateTime.UtcNow;

            if (!string.IsNullOrEmpty(model.Nome))
            {
                return _repo.Insert(model.asPessoaEndereco());
            }
            else throw new Exception("Campo nome está nulo"); //passar para classe de validacao no modelo
        }
      

        public Task<PessoaEnderecoResult> Load(Guid id)
        {            
            var res = _repo.Load(id);
            return Task.FromResult(res.asPessoaEnderecoResult());
        }

        public Task<ResultPage<PessoaEnderecoResult>> Page(int page, int size, string? ordeBy="", string? orderDirection = "", string? search = "")
        {
            IQueryable<PessoaEnderecoResult> result;
                        
            if (!string.IsNullOrEmpty(search) && search != "")
            {
                result = _PessoaEndereco.Query().AsQueryable().Where(p => p.Nome.ToLower().Contains(search.ToLower()));
            }
            else
            {
                result = _PessoaEndereco.Query().AsQueryable();
            }
            
            if (!string.IsNullOrEmpty(ordeBy))
            {
                string _direction = string.IsNullOrEmpty(orderDirection) ? "asc" : orderDirection;
                result = result.AsQueryable().DynamicOrderBy(ordeBy, _direction).AsQueryable();
            }

            int qtd = result.Count();
            result = result.AsQueryable().ToPage(page, size);
            
            ResultPage<PessoaEnderecoResult> tmp = new ResultPage<PessoaEnderecoResult>();
            tmp.Items = result;
            tmp.TotalItems = qtd;
            return Task.FromResult(tmp);
        }

        public PessoaEndereco Update(PessoaEnderecoUpdateCommand model)
        {
            var data = DateTime.UtcNow;
            //model.DataAlteracao = data;

            //if (model.Pago)
            //{
            //    model.DataPagamento = data;
            //}

            if (!string.IsNullOrEmpty(model.Nome))
            {
                return _repo.Update(model.asPessoaEndereco());
            }
            else throw new Exception("Campo nome está nulo"); //passar para classe de validacao no modelo
        }



        
        public Task<IQueryable<PessoaEnderecoResult>> List()
        {
            return Task.FromResult(_PessoaEndereco.Query().AsQueryable());
        }


    }
}
