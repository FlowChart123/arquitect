using Domain.Dto;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Specs
{
    public static class DespesaSpecs
    {
        public static DespesaResult asDespesaResult(this Despesa tmp)
        {
            return new DespesaResult()
            {
               Id = tmp.Id,
               Ano = tmp.Ano,
               Nome = tmp.Nome,
               DataAlteracao = tmp.DataAlteracao,
               DespesaAntrasada = tmp.DespesaAntrasada,
               DataCadastro = tmp.DataCadastro,
               DataPagamento = tmp.DataPagamento,
               DataVencimento = tmp.DataVencimento,
               IdCategoria = tmp.IdCategoria,
               Mes=tmp.Mes,
               Pago = tmp.Pago,
               TipoDespesa = tmp.TipoDespesa,
               Valor=tmp.Valor,               
            };
        }

        public static Despesa asDespesa(this DespesaInsertCommand tmp)
        {
            return new Despesa()
            {
                
                Ano = tmp.Ano,
                Nome= tmp.Nome,                
                DespesaAntrasada = tmp.DespesaAntrasada,
                DataCadastro = tmp.DataCadastro,
                DataVencimento = tmp.DataVencimento,
                IdCategoria = tmp.IdCategoria,
                Mes = tmp.Mes,
                Pago = tmp.Pago,
                TipoDespesa = tmp.TipoDespesa,
                Valor = tmp.Valor,
            };
        }
        public static Despesa asDespesa(this DespesaUpdateCommand tmp)
        {
            return new Despesa()
            {                
                Id=tmp.Id,
                Ano = tmp.Ano,
                Nome = tmp.Nome,
                DataAlteracao = tmp.DataAlteracao,
                DespesaAntrasada = tmp.DespesaAntrasada,
                DataCadastro = tmp.DataCadastro,
                DataPagamento = tmp.DataPagamento,
                DataVencimento = tmp.DataVencimento,
                IdCategoria = tmp.IdCategoria,
                Mes = tmp.Mes,
                Pago = tmp.Pago,
                TipoDespesa = tmp.TipoDespesa,
                Valor = tmp.Valor,
            };
        }

    }
}
