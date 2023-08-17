using Domain.Dto;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Specs
{
    public static class EmpresaSpecs
    {
        public static EmpresaResult asEmpresaResult(this Empresa tmp)
        {
            return new EmpresaResult()
            {
               Id = tmp.Id,
            };
        }

        public static Empresa asEmpresa(this EmpresaInsertCommand tmp)
        {
            return new Empresa()
            {
                
            };
        }
        public static Empresa asEmpresa(this EmpresaUpdateCommand tmp)
        {
            return new Empresa()
            {                
                Id=tmp.Id,
            };
        }

    }
}
