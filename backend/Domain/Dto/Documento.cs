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

    public class DocumentoDto
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }

    }
    public class DocumentoResult : DocumentoDto
    {
        
    }

    public class DocumentoInsertCommand : DocumentoDto
    {

    }
    public class DocumentoUpdateCommand : DocumentoDto
    {
        
    }
}
