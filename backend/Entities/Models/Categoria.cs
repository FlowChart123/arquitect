using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{

    [Table("Categoria")]
    public class Categoria : BaseEntity
    {
        [ForeignKey("SistemaFinanceiro")]
        [Column(Order = 1)]
        public int IdSistema { get; set; }
        public String Nome { get; set; }
       // public virtual SistemaFinanceiro SistemaFinanceiro { get; set; }
    }
}
