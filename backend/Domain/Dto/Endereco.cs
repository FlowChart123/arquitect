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

    public class EnderecoDto
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }

    }
    public class EnderecoResult : EnderecoDto
    {
        
    }

    public class EnderecoInsertCommand : EnderecoDto
    {

    }
    public class EnderecoUpdateCommand : EnderecoDto
    {
        
    }
}
