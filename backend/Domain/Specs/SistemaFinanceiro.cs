using Domain.Dto;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Specs
{
    public static class SistemaFinanceiroSpecs
    {
        public static SistemaFinanceiroResult asSistemaFinanceiroResult(this SistemaFinanceiro tmp)
        {
            return new SistemaFinanceiroResult()
            {
                Id = tmp.Id,
                Ano = tmp.Ano,
                AnoCopia = tmp.AnoCopia,
                DiaFechamento = tmp.DiaFechamento,
                GerarCopiaDespesa = tmp.GerarCopiaDespesa,
                Mes = tmp.Mes,
                MesCopia = tmp.MesCopia,
                Nome = tmp.Nome
            };
        }

        public static SistemaFinanceiro asSistemaFinanceiro(this SistemaFinanceiroInsertCommand tmp)
        {
            return new SistemaFinanceiro()
            {
                Ano = tmp.Ano,
                AnoCopia = tmp.AnoCopia,
                DiaFechamento = tmp.DiaFechamento,
                GerarCopiaDespesa = tmp.GerarCopiaDespesa,
                Mes = tmp.Mes,
                MesCopia = tmp.MesCopia,
                Nome = tmp.Nome
               
            };
        }
        public static SistemaFinanceiro asSistemaFinanceiro(this SistemaFinanceiroUpdateCommand tmp)
        {
            return new SistemaFinanceiro()
            {
                Id=tmp.Id,
                Ano = tmp.Ano,
                AnoCopia = tmp.AnoCopia,
                DiaFechamento = tmp.DiaFechamento,
                GerarCopiaDespesa = tmp.GerarCopiaDespesa,
                Mes = tmp.Mes,
                MesCopia = tmp.MesCopia,
                Nome = tmp.Nome
            };
        }

    }
}
