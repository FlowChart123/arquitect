using Domain.Dto;
using Domain.Interfaces.Generics;
using Domain.Models;
using Infra.Configuracao;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Entities.Models;
using Infra.Base;

namespace Infra.Repositories
{
    public class DespesaRepository : BaseRepository<DespesaDto>
    {
        public DespesaRepository(DataContext context) : base(context)
        {
        }
    }
}
