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

    public class PessoaDto
    {        
        public string Nome { get; set; }        
        public DateTime DataCadastro { get; set; }
    }

    public class PessoaResult : PessoaDto
    {
        public Guid Id { get; set; }
        public bool IsFisica { get; set; }        
        public string? DocNum { get; set; }  
        public PessoaFisica? pessoaFisica { get; set; }
    }

    public class PessoaInsertCommand 
    {
        public string? Nome { get; set; }
        public PessoaFisica? pessoaFisica { get; set; }
    }

    public class PessoaUpdateCommand : PessoaDto
    {
        public Guid Id { get; set; }
        public PessoaFisica? pessoaFisica { get; set; }
    }   
}
