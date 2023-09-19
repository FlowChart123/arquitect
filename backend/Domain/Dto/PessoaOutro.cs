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

    public class PessoaOutroDto
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }

    }
    public class PessoaOutroResult : PessoaOutroDto
    {
          
    }

    public class PessoaOutroInsertCommand : PessoaOutroDto
    {

    }
    public class PessoaOutroUpdateCommand : PessoaOutroDto
    {
        
    }
}
