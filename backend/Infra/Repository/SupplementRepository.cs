using Domain.Interfaces.Repository;
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
using System.Collections.Immutable;
using Infra.Abstract;
using Domain.Dto;
using Microsoft.AspNetCore.Mvc.Razor.Infrastructure;
using Domain.Specs;
using Microsoft.CodeAnalysis.Operations;
using System.Linq.Expressions;

namespace Infra.Repositorio
{
    public class SupplementRepository : RepositoryBase<Supplement>, ISupplement
    {     

        //ISUPLEMENT
        public IList<SupplementResult> Query()
        {
            var res = _context.Supplements.Select(o => o.asSupplementResult()).ToList();
            return res;
        }
    }

}
