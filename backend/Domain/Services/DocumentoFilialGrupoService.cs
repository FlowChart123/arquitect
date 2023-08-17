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


    public class DocumentoFilialGrupoService  : IDocumentoFilialGrupoService
    {
        private readonly IRepositoy<DocumentoFilialGrupo> _repo;
        private readonly IDocumentoFilialGrupoRepository _DocumentoFilialGrupo;

        public DocumentoFilialGrupoService(IRepositoy<DocumentoFilialGrupo> repo, IDocumentoFilialGrupoRepository sup)
        {
            _repo = repo;
            _DocumentoFilialGrupo = sup;
        }

        public void Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public DocumentoFilialGrupo Insert(DocumentoFilialGrupoInsertCommand model)
        {
            var data = DateTime.UtcNow;

            if (!string.IsNullOrEmpty(model.Nome))
            {
                return _repo.Insert(model.asDocumentoFilialGrupo());
            }
            else throw new Exception("Campo nome está nulo"); //passar para classe de validacao no modelo
        }
      

        public Task<DocumentoFilialGrupoResult> Load(Guid id)
        {            
            var res = _repo.Load(id);
            return Task.FromResult(res.asDocumentoFilialGrupoResult());
        }

        public Task<ResultPage<DocumentoFilialGrupoResult>> Page(int page, int size, string? ordeBy="", string? orderDirection = "", string? search = "")
        {
            IQueryable<DocumentoFilialGrupoResult> result;
                        
            if (!string.IsNullOrEmpty(search) && search != "")
            {
                result = _DocumentoFilialGrupo.Query().AsQueryable().Where(p => p.Nome.ToLower().Contains(search.ToLower()));
            }
            else
            {
                result = _DocumentoFilialGrupo.Query().AsQueryable();
            }
            
            if (!string.IsNullOrEmpty(ordeBy))
            {
                string _direction = string.IsNullOrEmpty(orderDirection) ? "asc" : orderDirection;
                result = result.AsQueryable().DynamicOrderBy(ordeBy, _direction).AsQueryable();
            }

            int qtd = result.Count();
            result = result.AsQueryable().ToPage(page, size);
            
            ResultPage<DocumentoFilialGrupoResult> tmp = new ResultPage<DocumentoFilialGrupoResult>();
            tmp.Items = result;
            tmp.TotalItems = qtd;
            return Task.FromResult(tmp);
        }

        public DocumentoFilialGrupo Update(DocumentoFilialGrupoUpdateCommand model)
        {
            var data = DateTime.UtcNow;
            //model.DataAlteracao = data;

            //if (model.Pago)
            //{
            //    model.DataPagamento = data;
            //}

            if (!string.IsNullOrEmpty(model.Nome))
            {
                return _repo.Update(model.asDocumentoFilialGrupo());
            }
            else throw new Exception("Campo nome está nulo"); //passar para classe de validacao no modelo
        }



        
        public Task<IQueryable<DocumentoFilialGrupoResult>> List()
        {
            return Task.FromResult(_DocumentoFilialGrupo.Query().AsQueryable());
        }


    }
}
