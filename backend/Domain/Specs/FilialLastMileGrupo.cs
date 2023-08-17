using Domain.Dto;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Specs
{
    public static class FilialLastMileGrupoSpecs
    {
        public static FilialLastMileGrupoResult asFilialLastMileGrupoResult(this FilialLastMileGrupo tmp)
        {
            return new FilialLastMileGrupoResult()
            {
               Id = tmp.Id,
            };
        }

        public static FilialLastMileGrupo asFilialLastMileGrupo(this FilialLastMileGrupoInsertCommand tmp)
        {
            return new FilialLastMileGrupo()
            {
                
            };
        }
        public static FilialLastMileGrupo asFilialLastMileGrupo(this FilialLastMileGrupoUpdateCommand tmp)
        {
            return new FilialLastMileGrupo()
            {                
                Id=tmp.Id,
            };
        }

    }
}
