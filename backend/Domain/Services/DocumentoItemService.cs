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


    public class DocumentoItemService  : IDocumentoItemService
    {
        private readonly IRepositoy<DocumentoItem> _repo;
        private readonly IDocumentoItemRepository _DocumentoItem;

        public DocumentoItemService(IRepositoy<DocumentoItem> repo, IDocumentoItemRepository sup)
        {
            _repo = repo;
            _DocumentoItem = sup;
        }

        public void Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public DocumentoItem Insert(DocumentoItemInsertCommand model)
        {
            var data = DateTime.UtcNow;

            if (!string.IsNullOrEmpty(model.Nome))
            {
                return _repo.Insert(model.asDocumentoItem());
            }
            else throw new Exception("Campo nome está nulo"); //passar para classe de validacao no modelo
        }
      

        public Task<DocumentoItemResult> Load(Guid id)
        {            
            var res = _repo.Load(id);
            return Task.FromResult(res.asDocumentoItemResult());
        }

        public Task<ResultPage<DocumentoItemResult>> Page(int page, int size, string? ordeBy="", string? orderDirection = "", string? search = "")
        {
            IQueryable<DocumentoItemResult> result;
                        
            if (!string.IsNullOrEmpty(search) && search != "")
            {
                result = _DocumentoItem.Query().AsQueryable().Where(p => p.Nome.ToLower().Contains(search.ToLower()));
            }
            else
            {
                result = _DocumentoItem.Query().AsQueryable();
            }
            
            if (!string.IsNullOrEmpty(ordeBy))
            {
                string _direction = string.IsNullOrEmpty(orderDirection) ? "asc" : orderDirection;
                result = result.AsQueryable().DynamicOrderBy(ordeBy, _direction).AsQueryable();
            }

            int qtd = result.Count();
            result = result.AsQueryable().ToPage(page, size);
            
            ResultPage<DocumentoItemResult> tmp = new ResultPage<DocumentoItemResult>();
            tmp.Items = result;
            tmp.TotalItems = qtd;
            return Task.FromResult(tmp);
        }

        public DocumentoItem Update(DocumentoItemUpdateCommand model)
        {
            var data = DateTime.UtcNow;
            //model.DataAlteracao = data;

            //if (model.Pago)
            //{
            //    model.DataPagamento = data;
            //}

            if (!string.IsNullOrEmpty(model.Nome))
            {
                return _repo.Update(model.asDocumentoItem());
            }
            else throw new Exception("Campo nome está nulo"); //passar para classe de validacao no modelo
        }



        
        public Task<IQueryable<DocumentoItemResult>> List()
        {
            return Task.FromResult(_DocumentoItem.Query().AsQueryable());
        }


    }
}
