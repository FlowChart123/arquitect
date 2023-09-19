using Domain.Dto;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces.Repository
{
    public interface IPessoaJuridicaRepository
    {        
        public IList<PessoaJuridicaResult> Query();
    }
}
