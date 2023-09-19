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

    public class RomaneioCargaDto
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }

    }
    public class RomaneioCargaResult : RomaneioCargaDto
    {
          
    }

    public class RomaneioCargaInsertCommand : RomaneioCargaDto
    {

    }
    public class RomaneioCargaUpdateCommand : RomaneioCargaDto
    {
        
    }
}
