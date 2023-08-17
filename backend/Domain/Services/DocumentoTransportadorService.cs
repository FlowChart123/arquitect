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


    public class DocumentoTransportadorService  : IDocumentoTransportadorService
    {
        private readonly IRepositoy<DocumentoTransportador> _repo;
        private readonly IDocumentoTransportadorRepository _DocumentoTransportador;

        public DocumentoTransportadorService(IRepositoy<DocumentoTransportador> repo, IDocumentoTransportadorRepository sup)
        {
            _repo = repo;
            _DocumentoTransportador = sup;
        }

        public void Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public DocumentoTransportador Insert(DocumentoTransportadorInsertCommand model)
        {
            var data = DateTime.UtcNow;

            if (!string.IsNullOrEmpty(model.Nome))
            {
                return _repo.Insert(model.asDocumentoTransportador());
            }
            else throw new Exception("Campo nome está nulo"); //passar para classe de validacao no modelo
        }
      

        public Task<DocumentoTransportadorResult> Load(Guid id)
        {            
            var res = _repo.Load(id);
            return Task.FromResult(res.asDocumentoTransportadorResult());
        }

        public Task<ResultPage<DocumentoTransportadorResult>> Page(int page, int size, string? ordeBy="", string? orderDirection = "", string? search = "")
        {
            IQueryable<DocumentoTransportadorResult> result;
                        
            if (!string.IsNullOrEmpty(search) && search != "")
            {
                result = _DocumentoTransportador.Query().AsQueryable().Where(p => p.Nome.ToLower().Contains(search.ToLower()));
            }
            else
            {
                result = _DocumentoTransportador.Query().AsQueryable();
            }
            
            if (!string.IsNullOrEmpty(ordeBy))
            {
                string _direction = string.IsNullOrEmpty(orderDirection) ? "asc" : orderDirection;
                result = result.AsQueryable().DynamicOrderBy(ordeBy, _direction).AsQueryable();
            }

            int qtd = result.Count();
            result = result.AsQueryable().ToPage(page, size);
            
            ResultPage<DocumentoTransportadorResult> tmp = new ResultPage<DocumentoTransportadorResult>();
            tmp.Items = result;
            tmp.TotalItems = qtd;
            return Task.FromResult(tmp);
        }

        public DocumentoTransportador Update(DocumentoTransportadorUpdateCommand model)
        {
            var data = DateTime.UtcNow;
            //model.DataAlteracao = data;

            //if (model.Pago)
            //{
            //    model.DataPagamento = data;
            //}

            if (!string.IsNullOrEmpty(model.Nome))
            {
                return _repo.Update(model.asDocumentoTransportador());
            }
            else throw new Exception("Campo nome está nulo"); //passar para classe de validacao no modelo
        }



        
        public Task<IQueryable<DocumentoTransportadorResult>> List()
        {
            return Task.FromResult(_DocumentoTransportador.Query().AsQueryable());
        }


    }
}
