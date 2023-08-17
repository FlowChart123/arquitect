using Domain.Dto;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Specs
{
    public static class CategoriaSpecs
    {
        public static CategoriaResult asCategoriaResult(this Categoria tmp)
        {
            return new CategoriaResult()
            {
               Id = tmp.Id,
               Nome = tmp.Nome
            };
        }

        public static Categoria asCategoria(this CategoriaInsertCommand tmp)
        {
            return new Categoria()
            {
                Id = tmp.Id,
                Nome = tmp.Nome
            };
        }
        public static Categoria asCategoria(this CategoriaUpdateCommand tmp)
        {
            return new Categoria()
            {
                Id = tmp.Id,
                Nome = tmp.Nome
            };
        }

    }
}
