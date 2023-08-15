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


    public class DespesaService  : IDespesaService
    {
        private readonly IRepositoy<Despesa> _repo;
        private readonly IDespesaRepository _despesa;

        public DespesaService(IRepositoy<Despesa> repo, IDespesaRepository sup)
        {
            _repo = repo;
            _despesa = sup;
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Despesa Insert(DespesaInsertCommand model)
        {
            var data = DateTime.UtcNow;
            model.DataCadastro = data;
            model.Ano = data.Year;
            model.Mes = data.Month;

            if (!string.IsNullOrEmpty(model.Nome))
            {
                return _repo.Insert(model.asDespesa());
            }
            else throw new Exception("Campo nome está nulo"); //passar para classe de validacao no modelo
        }
      

        public Task<DespesaResult> Load(int id)
        {            
            var res = _repo.Load(id);
            return Task.FromResult(res.asDespesaResult());
        }

        public Task<ResultPage<DespesaResult>> Page(int page, int size, string? ordeBy="", string? orderDirection = "", string? search = "")
        {
            IQueryable<DespesaResult> result;
                        
            if (!string.IsNullOrEmpty(search) && search != "")
            {
                result = _despesa.Query().AsQueryable().Where(p => p.Nome.ToLower().Contains(search.ToLower()));
            }
            else
            {
                result = _despesa.Query().AsQueryable();
            }
            
            if (!string.IsNullOrEmpty(ordeBy))
            {
                string _direction = string.IsNullOrEmpty(orderDirection) ? "asc" : orderDirection;
                result = result.AsQueryable().DynamicOrderBy(ordeBy, _direction).AsQueryable();
            }

            int qtd = result.Count();
            result = result.AsQueryable().ToPage(page, size);
            
            ResultPage<DespesaResult> tmp = new ResultPage<DespesaResult>();
            tmp.Items = result;
            tmp.TotalItems = qtd;
            return Task.FromResult(tmp);
        }

        public Despesa Update(DespesaUpdateCommand model)
        {
            var data = DateTime.UtcNow;
            model.DataAlteracao = data;

            if (model.Pago)
            {
                model.DataPagamento = data;
            }

            if (!string.IsNullOrEmpty(model.Nome))
            {
                return _repo.Update(model.asDespesa());
            }
            else throw new Exception("Campo nome está nulo"); //passar para classe de validacao no modelo
        }


        public Task<IList<DespesaResult>> ListarDespesasUsuario(string emailUsuario)
        {
            var res = _despesa.ListarDespesasUsuario(emailUsuario);
            return res;
        }

        public Task<IList<DespesaResult>> ListarDespesasUsuarioNaoPagasMesesAnterior(string emailUsuario)
        {
            var res = _despesa.ListarDespesasUsuarioNaoPagasMesesAnterior(emailUsuario);
            return res;
        }

        public Task<IQueryable<DespesaResult>> List()
        {
            throw new NotImplementedException();
        }
    }
}
