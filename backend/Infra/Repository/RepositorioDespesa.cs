//using Domain.Interfaces.IDespesa;
using Entities.Models;
using Infra.Configuracao;
using Infra.Repositorio.Generics;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
using DataContext = Infra.Configuracao.DataContext;

namespace Infra.Repositorio
{
   
    //public class RepositorioDespesa : RepositoryGenerics<Despesa>, InterfaceDespesa
    //{

    //    private readonly DbContextOptions<DataContext> _OptionsBuilder;

    //    public RepositorioDespesa()
    //    {
    //        _OptionsBuilder = new DbContextOptions<DataContext>();
    //    }

    //    public async Task<IList< Despesa>> ListarDespesasUsuario(string emailUsuario)
    //    {
    //        using (var banco = new DataContext(_OptionsBuilder))
    //        {
    //            return await
    //               (from s in banco.SistemaFinanceiro
    //                join c in banco.Categoria on s.Id equals c.IdSistema
    //                join us in banco.UsuarioSistemaFinanceiro on s.Id equals us.IdSistema
    //                join d in banco.Despesa on c.Id equals d.IdCategoria
    //                where us.EmailUsuario.Equals(emailUsuario) && s.Mes == d.Mes && s.Ano == d.Ano
    //                select d).AsNoTracking().ToListAsync();
    //        }
    //    }

    //    public async Task<IList<Despesa>> ListarDespesasUsuarioNaoPagasMesesAnterior(string emailUsuario)
    //    {
    //        using (var banco = new DataContext(_OptionsBuilder))
    //        {
    //            return await
    //               (from s in banco.SistemaFinanceiro
    //                join c in banco.Categoria on s.Id equals c.IdSistema
    //                join us in banco.UsuarioSistemaFinanceiro on s.Id equals us.IdSistema
    //                join d in banco.Despesa on c.Id equals d.IdCategoria
    //                where us.EmailUsuario.Equals(emailUsuario) && d.Mes < DateTime.Now.Month && !d.Pago
    //                select d).AsNoTracking().ToListAsync();
    //        }
    //    }



       
    //}

   

}
