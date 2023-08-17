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

    public class DocumentoItemDto
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }

    }
    public class DocumentoItemResult : DocumentoItemDto
    {
        
    }

    public class DocumentoItemInsertCommand : DocumentoItemDto
    {

    }
    public class DocumentoItemUpdateCommand : DocumentoItemDto
    {
        
    }
}
