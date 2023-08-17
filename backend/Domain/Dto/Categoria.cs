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

    public class CategoriaDto
    {
        public int Id { get; set; }
        public string Nome { get; set; }

    }
    public class CategoriaResult : CategoriaDto
    {
         
    }

    public class CategoriaInsertCommand : CategoriaDto
    {

    }
    public class CategoriaUpdateCommand : CategoriaDto
    {
        
    }
}
