//using Domain.Interfaces.ISistemaFinanceiro;
using Entities.Models;
using Infra.Configuracao;
using Infra.Repositorio.Generics;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataContext = Infra.Configuracao.DataContext;

namespace Infra.Repositorio
{
    //public class RepositorioSistemaFinanceiro : RepositoryGenerics<SistemaFinanceiro>, InterfaceSistemaFinanceiro
    //{

    //    private readonly DbContextOptions<DataContext> _OptionsBuilder;

    //    public RepositorioSistemaFinanceiro()
    //    {
    //        _OptionsBuilder = new DbContextOptions<DataContext>();
    //    }

    //    public async Task<IList<SistemaFinanceiro>> ListaSistemasUsuario(string emailUsuario)
    //    {
    //        using (var banco = new DataContext(_OptionsBuilder))
    //        {
    //            return await
    //               (from s in banco.SistemaFinanceiro 
    //                join us in banco.UsuarioSistemaFinanceiro on s.Id equals us.IdSistema                   
    //                where us.EmailUsuario.Equals(emailUsuario) 
    //                select s).AsNoTracking().ToListAsync();
    //        }
    //    }
    //}
}
