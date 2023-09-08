using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Configuracao
{
    public class UnitOfWork : IUnitOfWork
    {

        private readonly DbContextOptions<DataContext> _OptionsBuilder;
        protected DataContext _context { get; set; }

        public UnitOfWork()
        {
            _OptionsBuilder = new DbContextOptions<DataContext>();
            this._context = new DataContext(_OptionsBuilder);
        }

        public DataContext GetContext()
        {
            return this._context;
        }
    }
}
