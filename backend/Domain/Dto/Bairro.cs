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

    public class BairroDto
    {
        public int Id { get; set; }
        public string Nome { get; set; }

    }
    public class BairroResult : BairroDto
    {
        public int Id { get; set; }    
    }

    public class BairroInsertCommand : BairroDto
    {

    }
    public class BairroUpdateCommand : BairroDto
    {
        
    }
}
