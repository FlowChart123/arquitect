//using Domain.Interfaces.ICategoria;
//using Domain.Interfaces.IDespesa;
//using Domain.Interfaces.ISistemaFinanceiro;
//using Domain.Interfaces.IUsuarioSistemaFinanceiro;
using Infra.Repositorio;
using Infra.Repositorio.Generics;
using Domain.Interfaces.InterfaceServicos;
using Domain.Servicos;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using WebApi.Token;
using Entities.Models;
using Domain.Interfaces.Repository;
using Infra.Abstract;
using Domain.Dto;

namespace WebApi.Extensions
{
    public static class DependencyInjections
    {

        // INTERFACE E REPOSITORIO
        public static IServiceCollection RegisterRepositories(this IServiceCollection services) => services    
            .AddScoped<IRepositoy<SupplementDto,Supplement>,SupplementRepository>()
            .AddScoped<IJWTManager, JWTMAnagerRepo>()
            .AddScoped<ISupplement, SupplementRepository>();
        
        
        

        // SERVIÇO DOMINIO
        //public static IServiceCollection RegisterDomains(this IServiceCollection services) => services



    }
}


            //.AddSingleton<ICategoriaServico, CategoriaServico>()
            //.AddSingleton<IDespesaServico, DespesaServico>()
            //.AddSingleton<ISistemaFinanceiroServico, SistemaFinanceiroServico>()
            //.AddSingleton<IUsuarioSistemaFinanceiroServico, UsuarioSistemaFinanceiroServico>();




//.AddSingleton(typeof(InterfaceGeneric<>), typeof(RepositoryGenerics<>))
//.AddSingleton<InterfaceCategoria, RepositorioCategoria>()
//.AddSingleton<InterfaceDespesa, RepositorioDespesa>()
//.AddSingleton<InterfaceSistemaFinanceiro, RepositorioSistemaFinanceiro>()
//.AddSingleton<InterfaceUsuarioSistemaFinanceiro, RepositorioUsuarioSistemaFinanceiro>()
