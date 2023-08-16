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


    public class CategoriaService  : ICategoriaService
    {
        private readonly IRepositoy<Categoria> _repo;
        private readonly ICategoriaRepository _Categoria;

        public CategoriaService(IRepositoy<Categoria> repo, ICategoriaRepository sup)
        {
            _repo = repo;
            _Categoria = sup;
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Categoria Insert(CategoriaInsertCommand model)
        {
            var data = DateTime.UtcNow;

            if (!string.IsNullOrEmpty(model.Nome))
            {
                return _repo.Insert(model.asCategoria());
            }
            else throw new Exception("Campo nome está nulo"); //passar para classe de validacao no modelo
        }
      

        public Task<CategoriaResult> Load(int id)
        {            
            var res = _repo.Load(id);
            return Task.FromResult(res.asCategoriaResult());
        }

        public Task<ResultPage<CategoriaResult>> Page(int page, int size, string? ordeBy="", string? orderDirection = "", string? search = "")
        {
            IQueryable<CategoriaResult> result;
                        
            if (!string.IsNullOrEmpty(search) && search != "")
            {
                result = _Categoria.Query().AsQueryable().Where(p => p.Nome.ToLower().Contains(search.ToLower()));
            }
            else
            {
                result = _Categoria.Query().AsQueryable();
            }
            
            if (!string.IsNullOrEmpty(ordeBy))
            {
                string _direction = string.IsNullOrEmpty(orderDirection) ? "asc" : orderDirection;
                result = result.AsQueryable().DynamicOrderBy(ordeBy, _direction).AsQueryable();
            }

            int qtd = result.Count();
            result = result.AsQueryable().ToPage(page, size);
            
            ResultPage<CategoriaResult> tmp = new ResultPage<CategoriaResult>();
            tmp.Items = result;
            tmp.TotalItems = qtd;
            return Task.FromResult(tmp);
        }

        public Categoria Update(CategoriaUpdateCommand model)
        {
            var data = DateTime.UtcNow;
            //model.DataAlteracao = data;

            //if (model.Pago)
            //{
            //    model.DataPagamento = data;
            //}

            if (!string.IsNullOrEmpty(model.Nome))
            {
                return _repo.Update(model.asCategoria());
            }
            else throw new Exception("Campo nome está nulo"); //passar para classe de validacao no modelo
        }


        public Task<IList<CategoriaResult>> ListarCategoriasUsuario(string emailUsuario)
        {
            var res = _Categoria.ListarCategoriasUsuario(emailUsuario);
            return res;
        }

        
        public Task<IQueryable<CategoriaResult>> List()
        {
            return Task.FromResult(_Categoria.Query().AsQueryable());
        }


    }
}
