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

    public class PessoaJuridicaDto
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }

    }
    public class PessoaJuridicaResult : PessoaJuridicaDto
    {
        
    }

    public class PessoaJuridicaInsertCommand : PessoaJuridicaDto
    {

    }
    public class PessoaJuridicaUpdateCommand : PessoaJuridicaDto
    {
        
    }
}
