using Domain.Interfaces.ISupplement;
using Entities.Models;
using Infra.Configuracao;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infra.Extensions;

namespace Infra.Repositorio
{
    public class RepositorioSupplements : ISupplement
    {

        private readonly DbContextOptions<DataContext> _OptionsBuilder;
        public RepositorioSupplements()
        {
            _OptionsBuilder = new DbContextOptions<DataContext>();
        }

        public async Task<IQueryable<Supplement>> GetQueryable()
        {
            using (var _context = new DataContext(_OptionsBuilder))
            {
                var query = await _context.Set<Supplement>().ToListAsync();
                var result = query.AsQueryable();
                return result;
            }
        }


    }


  

}
