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

    public class FilialDto
    {
        public int Id { get; set; }
        public string Nome { get; set; }

    }
    public class FilialResult : FilialDto
    {
        
    }

    public class FilialInsertCommand : FilialDto
    {

    }
    public class FilialUpdateCommand : FilialDto
    {
        
    }
}
