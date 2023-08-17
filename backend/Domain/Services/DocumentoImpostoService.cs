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


    public class DocumentoImpostoService  : IDocumentoImpostoService
    {
        private readonly IRepositoy<DocumentoImposto> _repo;
        private readonly IDocumentoImpostoRepository _DocumentoImposto;

        public DocumentoImpostoService(IRepositoy<DocumentoImposto> repo, IDocumentoImpostoRepository sup)
        {
            _repo = repo;
            _DocumentoImposto = sup;
        }

        public void Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public DocumentoImposto Insert(DocumentoImpostoInsertCommand model)
        {
            var data = DateTime.UtcNow;

            if (!string.IsNullOrEmpty(model.Nome))
            {
                return _repo.Insert(model.asDocumentoImposto());
            }
            else throw new Exception("Campo nome está nulo"); //passar para classe de validacao no modelo
        }
      

        public Task<DocumentoImpostoResult> Load(Guid id)
        {            
            var res = _repo.Load(id);
            return Task.FromResult(res.asDocumentoImpostoResult());
        }

        public Task<ResultPage<DocumentoImpostoResult>> Page(int page, int size, string? ordeBy="", string? orderDirection = "", string? search = "")
        {
            IQueryable<DocumentoImpostoResult> result;
                        
            if (!string.IsNullOrEmpty(search) && search != "")
            {
                result = _DocumentoImposto.Query().AsQueryable().Where(p => p.Nome.ToLower().Contains(search.ToLower()));
            }
            else
            {
                result = _DocumentoImposto.Query().AsQueryable();
            }
            
            if (!string.IsNullOrEmpty(ordeBy))
            {
                string _direction = string.IsNullOrEmpty(orderDirection) ? "asc" : orderDirection;
                result = result.AsQueryable().DynamicOrderBy(ordeBy, _direction).AsQueryable();
            }

            int qtd = result.Count();
            result = result.AsQueryable().ToPage(page, size);
            
            ResultPage<DocumentoImpostoResult> tmp = new ResultPage<DocumentoImpostoResult>();
            tmp.Items = result;
            tmp.TotalItems = qtd;
            return Task.FromResult(tmp);
        }

        public DocumentoImposto Update(DocumentoImpostoUpdateCommand model)
        {
            var data = DateTime.UtcNow;
            //model.DataAlteracao = data;

            //if (model.Pago)
            //{
            //    model.DataPagamento = data;
            //}

            if (!string.IsNullOrEmpty(model.Nome))
            {
                return _repo.Update(model.asDocumentoImposto());
            }
            else throw new Exception("Campo nome está nulo"); //passar para classe de validacao no modelo
        }



        
        public Task<IQueryable<DocumentoImpostoResult>> List()
        {
            return Task.FromResult(_DocumentoImposto.Query().AsQueryable());
        }


    }
}
