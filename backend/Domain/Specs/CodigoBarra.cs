using Domain.Dto;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Specs
{
    public static class CodigoBarraSpecs
    {
        public static CodigoBarraResult asCodigoBarraResult(this CodigoBarra tmp)
        {
            return new CodigoBarraResult()
            {
               Id = tmp.Id,
               Altura = tmp.Altura,
               CodigoBarras = tmp.CodigoBarras,
               Comprimento = tmp.Comprimento,
               Largura = tmp.Largura,
            };
        }

        public static CodigoBarra asCodigoBarra(this CodigoBarraInsertCommand tmp)
        {
            return new CodigoBarra()
            {
                Id = tmp.Id,
                Altura = tmp.Altura,
                CodigoBarras = tmp.CodigoBarras,
                Comprimento = tmp.Comprimento,
                Largura = tmp.Largura,
            };
        }
        public static CodigoBarra asCodigoBarra(this CodigoBarraUpdateCommand tmp)
        {
            return new CodigoBarra()
            {
                Id = tmp.Id,
                Altura = tmp.Altura,
                CodigoBarras = tmp.CodigoBarras,
                Comprimento = tmp.Comprimento,
                Largura = tmp.Largura,
            };
        }

    }
}
