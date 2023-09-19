
using Entities.Models;
using Infra.Configuracao;
using Microsoft.EntityFrameworkCore;
using Microsoft.Win32.SafeHandles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Infra.Repository.Generics
{
    public class GenericListRepository
    {
        private readonly DbContextOptions<DataContext> _OptionsBuilder;
        protected DataContext _context { get; set; }

        public GenericListRepository()
        {
            _OptionsBuilder = new DbContextOptions<DataContext>();
            this._context = new DataContext(_OptionsBuilder);
        }

        
    }
}
