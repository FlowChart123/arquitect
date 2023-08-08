using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Dto
{
    public class ResultPage<T>
    {
        public int TotalItems { get; set; }
        public IList<T> Items { get; set; }
    }
}
