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

    public class PessoaFisicaDto
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }

    }
    public class PessoaFisicaResult : PessoaFisicaDto
    {
          
    }

    public class PessoaFisicaInsertCommand : PessoaFisicaDto
    {

    }
    public class PessoaFisicaUpdateCommand : PessoaFisicaDto
    {
        
    }
}
