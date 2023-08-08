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
using Infra.Specs;
using Microsoft.CodeAnalysis.Operations;
using System.Linq.Expressions;

namespace Infra.Repositorio
{
    public class SupplementRepository : RepositoryBase<SupplementDto, Supplement>, ISupplement
    {

        //INHERITS
        public override SupplementDto entityToDto(Supplement T)
        {            
            return T.asSupplementResult();            
        }

        public override Supplement parseDto(SupplementDto dto)
        {
            var tmp = new Supplement()
            {
                Name = dto.name
            };
            return tmp;
                                    
        }


        //ISUPLEMENT
        public IList<SupplementDto> Query()
        {
            using (var c = GetContext())
            {
                var res = c.Supplements.Select(o=>o.asSupplementResult()).ToList();
                return res;
            }
        }
    }

}
