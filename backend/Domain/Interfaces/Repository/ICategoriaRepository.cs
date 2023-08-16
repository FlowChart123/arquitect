using Domain.Dto;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces.Repository
{
    public interface ICategoriaRepository
    {        
        public Task<IList<CategoriaResult>> ListarCategoriasUsuario(string emailUsuario);
        public IList<CategoriaResult> Query();
    }
}
