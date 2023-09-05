using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Dto
{
    public class SupplementResult
    {
        public int id { get; set; }
        public string name { get; set; }
    }

    public class SupplementInsertCommand
    {
        public string Name { get; set; }
    }
    public class SupplementUpdateCommand : Bairro
    {
    }
}
