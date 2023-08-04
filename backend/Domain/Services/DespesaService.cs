using Domain.Dto;
using Domain.Interfaces.Generics;
using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Domain.Services
{
    public class DespesaService : IService<DespesaDto>, IDisposable
    {
        private readonly IRepository<DespesaDto> _repository;
        

        public DespesaService(IRepository<DespesaDto> repository)
        {
            _repository = repository;            
        }

        public void Dispose()
        {
            _repository.Dispose();
        }
        public async Task AddAsync(DespesaDto dto)
        {          
            _repository.Add(dto);
            await _repository.CommitAsync();
        }

        public async Task DeleteAsync(int id)
        {
             _repository.DeleteAsync(id);
        }


        public Task<DespesaDto> GetByIdAsync(int id, string[] includes = null)
        {
            return _repository.GetByIdAsync(id, includes: includes);
        }

        public async Task UpdateAsync(DespesaDto dto)
        {

            //long idd = dto.AssociadoId;
            //var original = _context.Set<Associados>().AsNoTracking().FirstOrDefault(p => p.AssociadoId == dto.AssociadoId);
            //dto.Senha = original.Senha;
            //dto.DataInclusao = original.DataInclusao;
            //dto.DataUltimaAlteracao = System.DateTime.Now;
            //dto.DataUltimaTrocaSenha = original.DataUltimaTrocaSenha;
            //dto.DataUltimoLogin = original.DataUltimoLogin;

            //foreach (Despesa x in dto.Dependentes)
            //{
            //    //A IDÉIA É VIR NA DTO OS DEPENDENTES PARA ATUALIZAÇÃO DIRETA
            //    int id = Convert.ToInt32(x.AssociadoId);
            //    var dep = await GetByIdAsync(id);
            //    dep.AssociadoIdPai = x.AssociadoIdPai;
            //    _context.Entry(dep).State = EntityState.Modified;
            //}

            //_context.Entry(dto).State = EntityState.Modified;

            //try
            //{
            //    _context.Update(dto);

            //}
            //catch (Exception ex)
            //{
            //    var msg = ex.Message;

            //}

            //try
            //{
            //    _context.SaveChanges();

            //}
            //catch (Exception ex)
            //{
            //}



            await _repository.CommitAsync();

        }

        public async Task<ResultPage<DespesaDto>> GetAllAsync(Expression<Func<DespesaDto, bool>> filter = null, string[] includes = null, int? page = 1, int? limit = null)
        {
            return await _repository.GetAllAsync(filter: filter, includes: includes, limit: limit, page: page);
        }
    }
}
