using Domain.Dto;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface ICategoriaService
    {
        public Task<ResultPage<CategoriaResult>> Page(int page, int size, string? ordeBy = "", string? orderDirection = "", string? search = "");
        public Task<IQueryable<CategoriaResult>> List();
        public Task<CategoriaResult> Load(int id);
        public Categoria Insert(CategoriaInsertCommand model);
        public Categoria Update(CategoriaUpdateCommand model);
        public void Delete(int id);
        public Task<IList<CategoriaResult>> ListarCategoriasUsuario(string emailUsuario);
    }
}
