using Entities.Enums;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Dto
{

    public class DespesaDto
    {
        public int Ano { get; set; }
        public string Nome { get; set; }
        public DateTime DataAlteracao { get; set; }
        public DateTime DataCadastro { get; set; }
        public DateTime DataPagamento { get; set; }
        public DateTime DataVencimento { get; set; }
        public bool DespesaAntrasada { get; set; }
        public int IdCategoria { get; set; }
        public int Mes { get; set; }
        public bool Pago { get; set; }
        public int TipoDespesa { get; set; }
        public decimal Valor { get; set; }
        public int Id { get; set; }
    }
    public class DespesaResult : DespesaDto
    {
        
    
    }

    public class DespesaInsertCommand 
    {
        public int Ano { get; set; }
        public string Nome { get; set; }
        public DateTime DataVencimento { get; set; }
        public bool DespesaAntrasada { get; set; }
        public int IdCategoria { get; set; }
        public int Mes { get; set; }
        public bool Pago { get; set; }
        public int TipoDespesa { get; set; }
        public decimal Valor { get; set; }
        public DateTime DataCadastro { get; set; }

    }
    public class DespesaUpdateCommand : DespesaDto
    {
        
    }
}
