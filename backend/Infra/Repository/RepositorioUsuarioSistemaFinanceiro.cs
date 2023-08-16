using Domain.Interfaces.IUsuarioSistemaFinanceiro;
using Entities.Models;
using Infra.Configuracao;

using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataContext = Infra.Configuracao.DataContext;

namespace Infra.Repositorio
{
    //public class RepositorioUsuarioSistemaFinanceiro : RepositoryGenerics<UsuarioSistemaFinanceiro>, InterfaceUsuarioSistemaFinanceiro
    //{

    //    private readonly DbContextOptions<DataContext> _OptionsBuilder;

    //    public RepositorioUsuarioSistemaFinanceiro()
    //    {
    //        _OptionsBuilder = new DbContextOptions<DataContext>();
    //    }

    //    public async Task<IList<UsuarioSistemaFinanceiro>> ListarUsuariosSistema(int IdSistema)
    //    {
    //        using (var banco = new DataContext(_OptionsBuilder))
    //        {
    //            return await
    //                banco.UsuarioSistemaFinanceiro
    //                .Where(s => s.IdSistema == IdSistema).AsNoTracking()
    //                .ToListAsync();
    //        }
    //    }

    //    public async Task<UsuarioSistemaFinanceiro> ObterUsuarioPorEmail(string emailUsuario)
    //    {
    //        using (var banco = new DataContext(_OptionsBuilder))
    //        {
    //            return await
    //                banco.UsuarioSistemaFinanceiro.AsNoTracking().FirstOrDefaultAsync(x => x.EmailUsuario.Equals(emailUsuario));
    //        }
    //    }

    //    public async Task RemoveUsuarios(List<UsuarioSistemaFinanceiro> usuarios)
    //    {
    //        using (var banco = new DataContext(_OptionsBuilder))
    //        {
    //            banco.UsuarioSistemaFinanceiro
    //           .RemoveRange(usuarios);

    //            await banco.SaveChangesAsync();
    //        }
    //    }
    //}
}
