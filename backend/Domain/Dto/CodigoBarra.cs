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

    public class CodigoBarraDto
    {
        public Guid Id { get; set; }
                
        public string CodigoBarras { get; set; } = null!;

        public decimal? Altura { get; set; }

        public decimal? Largura { get; set; }

        public decimal? Comprimento { get; set; }

    }
    public class CodigoBarraResult : CodigoBarraDto
    {
        
    }

    public class CodigoBarraInsertCommand : CodigoBarraDto
    {

    }
    public class CodigoBarraUpdateCommand : CodigoBarraDto
    {
        
    }
}
