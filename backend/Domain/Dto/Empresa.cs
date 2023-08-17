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

    public class EmpresaDto
    {
        public int Id { get; set; }
        public string Nome { get; set; }

    }
    public class EmpresaResult : EmpresaDto
    {
        
    }

    public class EmpresaInsertCommand : EmpresaDto
    {

    }
    public class EmpresaUpdateCommand : EmpresaDto
    {
        
    }
}
