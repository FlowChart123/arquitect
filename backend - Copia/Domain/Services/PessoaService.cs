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
using Microsoft.EntityFrameworkCore.Metadata.Conventions;

namespace Domain.Services
{


    public class PessoaService  : IPessoaService
    {
        private readonly IRepositoy<Pessoa> _repo;
        private readonly IPessoaRepository _pessoa;
        private readonly IRepositoy<PessoaFisica> _pessoa_fisica;
        private readonly IRepositoy<PessoaJuridica> _pessoa_juridica;
        private readonly IRepositoy<PessoaFisicaComplemento> _pessoa_fisica_complemento;

        public PessoaService(IPessoaRepository pessoa, IRepositoy<Pessoa> repo, 
            IRepositoy<PessoaFisica> pessoa_fisica,
            IRepositoy<PessoaJuridica> pessoa_juridica,
            IRepositoy<PessoaFisicaComplemento> pessoa_fisica_complemento)
        {
            _pessoa = pessoa;
            _repo = repo;
            _pessoa_fisica = pessoa_fisica;
            _pessoa_juridica = pessoa_juridica;
            _pessoa_fisica_complemento = pessoa_fisica_complemento;
        }

        public void Delete(Guid id)
        {
            _repo.Delete(null, id);
        }
            
        public Task<PessoaResult> Load(Guid id)
        {
            var res = _repo.Load(null, id);
            return Task.FromResult( res.asPessoaResult());
        }

        public Task<ResultPage<PessoaResult>> Page(int page, int size, string? ordeBy="", string? orderDirection = "", string? search = "")
        {
            IQueryable<PessoaResult> result;
                        
            if (!string.IsNullOrEmpty(search) && search != "")
            {
                result = _pessoa.Query().AsQueryable().Where(p => p.Nome.ToLower().Contains(search.ToLower()) || p.DocNum.Contains(search) );
            }
            else
            {
                result = _pessoa.Query().AsQueryable();
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

        public PessoaResult Insert(PessoaInsertCommand model)
        {
                        
            if (!string.IsNullOrEmpty(model.Nome))
            {
                var res = model.asPessoa();
                var pessoa = _repo.Insert(res);
                if (pessoa.PessoaFisica != null)
                {
                    
                    pessoa.PessoaFisica.Id = pessoa.Id;
                    var pessoaFisica = _pessoa_fisica.InsertOrUpdate(pessoa.PessoaFisica);                    
                    if (pessoaFisica.PessoaFisicaComplemento!=null)
                    {
                        pessoaFisica.PessoaFisicaComplemento.Id = pessoa.Id;
                        var pfc = _pessoa_fisica_complemento.InsertOrUpdate(pessoaFisica.PessoaFisicaComplemento);
                    }
                }
                if (pessoa.PessoaJuridica!=null)
                {
                    pessoa.PessoaJuridica.Id = pessoa.Id;
                    var pj = _pessoa_juridica.InsertOrUpdate(pessoa.PessoaJuridica);
                }

                return pessoa.asPessoaResult();
            }
            else throw new Exception("Campo nome está nulo"); //passar para classe de validacao no modelo
        }

        
        public Task<IQueryable<PessoaResult>> List()
        {
            return Task.FromResult(_pessoa.Query().AsQueryable());
        }

        public PessoaResult Update(PessoaUpdateCommand model)
        {
            if (!string.IsNullOrEmpty(model.Nome))
            {
                var res = model.asPessoa();
                var pessoa = _repo.Update(res);
                if (pessoa.PessoaFisica != null)
                {

                    pessoa.PessoaFisica.Id = pessoa.Id;
                    var pessoaFisica = _pessoa_fisica.InsertOrUpdate(pessoa.PessoaFisica);
                    if (pessoaFisica.PessoaFisicaComplemento != null)
                    {
                        pessoaFisica.PessoaFisicaComplemento.Id = pessoa.Id;
                        var pfc = _pessoa_fisica_complemento.InsertOrUpdate(pessoaFisica.PessoaFisicaComplemento);
                    }
                }
                if (pessoa.PessoaJuridica != null)
                {
                    pessoa.PessoaJuridica.Id = pessoa.Id;
                    var pj = _pessoa_juridica.InsertOrUpdate(pessoa.PessoaJuridica);
                }


                return pessoa.asPessoaResult();
            }
            else throw new Exception("Campo nome está nulo"); //passar para classe de validacao no modelo
        }
    }
}
