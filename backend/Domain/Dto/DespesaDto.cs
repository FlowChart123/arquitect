using Domain.Models;
using Entities.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Dto
{
    public class DespesaDto : BaseEntity
    {
        public int Ano { get; set; }
        public DateTime DataAlteracao { get; set; }
        public DateTime DataCadastro { get; set; }
        public DateTime DataPagamento { get; set; }
        public DateTime DataVencimento { get; set; }
        public bool DespesaAtrasada { get; set; }
        public int IdCategoria { get; set; }
        public int Mes { get; set; }
        public bool Pago { get; set; }
        public EnumTipoDespesa TipoDespesa { get; set; }
        public decimal Valor { get; set; }
    }
    public class DespesaList : DespesaDto
    {

    }
}
