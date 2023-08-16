using Domain.Dto;
using Domain.Interfaces.Repository;
using Domain.Specs;
using Entities.Models;
using Infra.Abstract;
using Microsoft.EntityFrameworkCore;

namespace Infra.Repositorio
{
    public class CategoriaRepository : RepositoryBase<Categoria>, ICategoriaRepository
    {

        //ICategoriaREPOSITORY
        public async Task<IList<CategoriaResult>> ListarCategoriasUsuario(string emailUsuario)
        {

            return await (from s in _context.SistemaFinanceiro
             join c in _context.Categoria on s.Id equals c.IdSistema
             join us in _context.UsuarioSistemaFinanceiro on s.Id equals us.IdSistema
             where us.EmailUsuario.Equals(emailUsuario) && us.SistemaAtual
             select c.asCategoriaResult()).AsNoTracking().ToListAsync();
        }

        public IList<CategoriaResult> Query()
        {

            var res = _context.Categoria.Select(o => o.asCategoriaResult()).ToList();
            return res;
        }
    }
}