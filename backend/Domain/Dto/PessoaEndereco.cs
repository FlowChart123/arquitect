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

    public class PessoaEnderecoDto
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }

    }
    public class PessoaEnderecoResult : PessoaEnderecoDto
    {
     
    }

    public class PessoaEnderecoInsertCommand : PessoaEnderecoDto
    {

    }
    public class PessoaEnderecoUpdateCommand : PessoaEnderecoDto
    {
        
    }
}
