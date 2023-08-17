using Domain.Dto;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Specs
{
    public static class FilialLastMileGrupoItemSpecs
    {
        public static FilialLastMileGrupoItemResult asFilialLastMileGrupoItemResult(this FilialLastMileGrupoItem tmp)
        {
            return new FilialLastMileGrupoItemResult()
            {
               Id = tmp.Id,
            };
        }

        public static FilialLastMileGrupoItem asFilialLastMileGrupoItem(this FilialLastMileGrupoItemInsertCommand tmp)
        {
            return new FilialLastMileGrupoItem()
            {
                
            };
        }
        public static FilialLastMileGrupoItem asFilialLastMileGrupoItem(this FilialLastMileGrupoItemUpdateCommand tmp)
        {
            return new FilialLastMileGrupoItem()
            {                
                Id=tmp.Id,
            };
        }

    }
}
