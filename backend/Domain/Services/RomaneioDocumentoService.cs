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


    public class RomaneioDocumentoService  : IRomaneioDocumentoService
    {
        private readonly IRepositoy<RomaneioDocumento> _repo;
        private readonly IRomaneioDocumentoRepository _RomaneioDocumento;

        public RomaneioDocumentoService(IRepositoy<RomaneioDocumento> repo, IRomaneioDocumentoRepository sup)
        {
            _repo = repo;
            _RomaneioDocumento = sup;
        }

        public void Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public RomaneioDocumento Insert(RomaneioDocumentoInsertCommand model)
        {
            var data = DateTime.UtcNow;

            if (!string.IsNullOrEmpty(model.Nome))
            {
                return _repo.Insert(model.asRomaneioDocumento());
            }
            else throw new Exception("Campo nome está nulo"); //passar para classe de validacao no modelo
        }
      

        public Task<RomaneioDocumentoResult> Load(Guid id)
        {            
            var res = _repo.Load(id);
            return Task.FromResult(res.asRomaneioDocumentoResult());
        }

        public Task<ResultPage<RomaneioDocumentoResult>> Page(int page, int size, string? ordeBy="", string? orderDirection = "", string? search = "")
        {
            IQueryable<RomaneioDocumentoResult> result;
                        
            if (!string.IsNullOrEmpty(search) && search != "")
            {
                result = _RomaneioDocumento.Query().AsQueryable().Where(p => p.Nome.ToLower().Contains(search.ToLower()));
            }
            else
            {
                result = _RomaneioDocumento.Query().AsQueryable();
            }
            
            if (!string.IsNullOrEmpty(ordeBy))
            {
                string _direction = string.IsNullOrEmpty(orderDirection) ? "asc" : orderDirection;
                result = result.AsQueryable().DynamicOrderBy(ordeBy, _direction).AsQueryable();
            }

            int qtd = result.Count();
            result = result.AsQueryable().ToPage(page, size);
            
            ResultPage<RomaneioDocumentoResult> tmp = new ResultPage<RomaneioDocumentoResult>();
            tmp.Items = result;
            tmp.TotalItems = qtd;
            return Task.FromResult(tmp);
        }

        public RomaneioDocumento Update(RomaneioDocumentoUpdateCommand model)
        {
            var data = DateTime.UtcNow;
            //model.DataAlteracao = data;

            //if (model.Pago)
            //{
            //    model.DataPagamento = data;
            //}

            if (!string.IsNullOrEmpty(model.Nome))
            {
                return _repo.Update(model.asRomaneioDocumento());
            }
            else throw new Exception("Campo nome está nulo"); //passar para classe de validacao no modelo
        }



        
        public Task<IQueryable<RomaneioDocumentoResult>> List()
        {
            return Task.FromResult(_RomaneioDocumento.Query().AsQueryable());
        }


    }
}
