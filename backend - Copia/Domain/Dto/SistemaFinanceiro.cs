using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Dto
{

    public class SistemaFinanceiroDto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public int Mes { get; set; }
        public int Ano { get; set; }
        public int DiaFechamento { get; set; }
        public bool GerarCopiaDespesa { get; set; }
        public int MesCopia { get; set; }
        public int AnoCopia { get; set; }
    }
    public class SistemaFinanceiroResult : SistemaFinanceiroDto
    {
      
    }

    public class SistemaFinanceiroInsertCommand : SistemaFinanceiroDto
    {

    }
    public class SistemaFinanceiroUpdateCommand : SistemaFinanceiroDto
    {
        
    }

}
