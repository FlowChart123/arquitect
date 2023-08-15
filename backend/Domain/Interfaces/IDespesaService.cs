using Domain.Dto;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IDespesaService
    {
        public Task<ResultPage<DespesaResult>> Page(int page, int size, string? ordeBy = "", string? orderDirection = "", string? search = "");
        public Task<IQueryable<DespesaResult>> List();
        public Task<DespesaResult> Load(int id);
        public Despesa Insert(DespesaInsertCommand model);
        public Despesa Update(DespesaUpdateCommand model);
        public void Delete(int id);
        public Task<IList<DespesaResult>> ListarDespesasUsuario(string emailUsuario);
        public Task<IList<DespesaResult>> ListarDespesasUsuarioNaoPagasMesesAnterior(string emailUsuario);
    }
}
