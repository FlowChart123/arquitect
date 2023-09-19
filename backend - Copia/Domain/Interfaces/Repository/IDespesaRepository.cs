using Domain.Dto;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces.Repository
{
    public interface IDespesaRepository
    {        
        public Task<IList<DespesaResult>> ListarDespesasUsuario(string emailUsuario);
        public Task<IList<DespesaResult>> ListarDespesasUsuarioNaoPagasMesesAnterior(string emailUsuario);
        public IList<DespesaResult> Query();
    }
}
