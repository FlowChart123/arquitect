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
        
        public string Cnpj { get; set; } = null!;

        public string? Fantasia { get; set; }

        public string InscricaoEstadual { get; set; } = null!;

        public string? InscricaoMunicipal { get; set; }                

    }
    public class PessoaJuridicaResult : PessoaJuridicaDto
    {
        public Guid Id { get; set; }
    }

    public class PessoaJuridicaInsertCommand : PessoaJuridicaDto
    {

    }
    public class PessoaJuridicaUpdateCommand : PessoaJuridicaDto
    {
        public Guid Id { get; set; }
    }
}
