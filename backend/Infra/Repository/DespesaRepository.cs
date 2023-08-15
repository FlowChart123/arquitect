using Domain.Dto;
using Domain.Interfaces.Repository;
using Domain.Specs;
using Entities.Models;
using Infra.Abstract;
using Microsoft.EntityFrameworkCore;

namespace Infra.Repositorio
{
    public class DespesaRepository : RepositoryBase<Despesa>, IDespesaRepository
    {

        //IDESPESAREPOSITORY
        public async Task<IList<DespesaResult>> ListarDespesasUsuario(string emailUsuario)
        {

            return await
                   (from s in _context.SistemaFinanceiro
                    join c in _context.Categoria on s.Id equals c.IdSistema
                    join us in _context.UsuarioSistemaFinanceiro on s.Id equals us.IdSistema
                    join de in _context.Despesa on c.Id equals de.IdCategoria
                    where us.EmailUsuario.Equals(emailUsuario) && s.Mes == de.Mes && s.Ano == de.Ano
                    select de.asDespesaResult()).AsNoTracking().ToListAsync();
        }

        public async Task<IList<DespesaResult>> ListarDespesasUsuarioNaoPagasMesesAnterior(string emailUsuario)
        {
            return await
              (from s in _context.SistemaFinanceiro
               join c in _context.Categoria on s.Id equals c.IdSistema
               join us in _context.UsuarioSistemaFinanceiro on s.Id equals us.IdSistema
               join d in _context.Despesa on c.Id equals d.IdCategoria
               where us.EmailUsuario.Equals(emailUsuario) && d.Mes < DateTime.Now.Month && !d.Pago
               select d.asDespesaResult()).AsNoTracking().ToListAsync();
        }

        public IList<DespesaResult> Query()
        {

            var res = _context.Despesa.Select(o => o.asDespesaResult()).ToList();
            return res;
        }
    }
}