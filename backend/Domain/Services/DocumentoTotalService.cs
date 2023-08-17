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


    public class DocumentoTotalService  : IDocumentoTotalService
    {
        private readonly IRepositoy<DocumentoTotal> _repo;
        private readonly IDocumentoTotalRepository _DocumentoTotal;

        public DocumentoTotalService(IRepositoy<DocumentoTotal> repo, IDocumentoTotalRepository sup)
        {
            _repo = repo;
            _DocumentoTotal = sup;
        }

        public void Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public DocumentoTotal Insert(DocumentoTotalInsertCommand model)
        {
            var data = DateTime.UtcNow;

            if (!string.IsNullOrEmpty(model.Nome))
            {
                return _repo.Insert(model.asDocumentoTotal());
            }
            else throw new Exception("Campo nome está nulo"); //passar para classe de validacao no modelo
        }
      

        public Task<DocumentoTotalResult> Load(Guid id)
        {            
            var res = _repo.Load(id);
            return Task.FromResult(res.asDocumentoTotalResult());
        }

        public Task<ResultPage<DocumentoTotalResult>> Page(int page, int size, string? ordeBy="", string? orderDirection = "", string? search = "")
        {
            IQueryable<DocumentoTotalResult> result;
                        
            if (!string.IsNullOrEmpty(search) && search != "")
            {
                result = _DocumentoTotal.Query().AsQueryable().Where(p => p.Nome.ToLower().Contains(search.ToLower()));
            }
            else
            {
                result = _DocumentoTotal.Query().AsQueryable();
            }
            
            if (!string.IsNullOrEmpty(ordeBy))
            {
                string _direction = string.IsNullOrEmpty(orderDirection) ? "asc" : orderDirection;
                result = result.AsQueryable().DynamicOrderBy(ordeBy, _direction).AsQueryable();
            }

            int qtd = result.Count();
            result = result.AsQueryable().ToPage(page, size);
            
            ResultPage<DocumentoTotalResult> tmp = new ResultPage<DocumentoTotalResult>();
            tmp.Items = result;
            tmp.TotalItems = qtd;
            return Task.FromResult(tmp);
        }

        public DocumentoTotal Update(DocumentoTotalUpdateCommand model)
        {
            var data = DateTime.UtcNow;
            //model.DataAlteracao = data;

            //if (model.Pago)
            //{
            //    model.DataPagamento = data;
            //}

            if (!string.IsNullOrEmpty(model.Nome))
            {
                return _repo.Update(model.asDocumentoTotal());
            }
            else throw new Exception("Campo nome está nulo"); //passar para classe de validacao no modelo
        }



        
        public Task<IQueryable<DocumentoTotalResult>> List()
        {
            return Task.FromResult(_DocumentoTotal.Query().AsQueryable());
        }


    }
}
