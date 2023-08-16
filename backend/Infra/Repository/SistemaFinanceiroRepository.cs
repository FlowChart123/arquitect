using Domain.Dto;
using Domain.Interfaces.Repository;
using Domain.Specs;
using Entities.Models;
using Infra.Abstract;
using Microsoft.EntityFrameworkCore;

namespace Infra.Repositorio
{
    public class SistemaFinanceiroRepository : RepositoryBase<SistemaFinanceiro>, ISistemaFinanceiroRepository
    {
        //ISistemaFinanceiroREPOSITORY
        
        public async Task<IList<SistemaFinanceiroResult>> ListaSistemasUsuario(string emailUsuario)
        {
            return await
                (from s in _context.SistemaFinanceiro
                join us in _context.UsuarioSistemaFinanceiro on s.Id equals us.IdSistema
                    where us.EmailUsuario.Equals(emailUsuario)
                select s.asSistemaFinanceiroResult()).AsNoTracking().ToListAsync();
        }

        public IList<SistemaFinanceiroResult> Query()
        {
            var res = _context.SistemaFinanceiro.Select(o => o.asSistemaFinanceiroResult()).ToList();
            return res;
        }
    }
}