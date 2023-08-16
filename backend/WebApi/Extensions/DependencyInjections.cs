//using Domain.Interfaces.ICategoria;
//using Domain.Interfaces.IDespesa;
//using Domain.Interfaces.ISistemaFinanceiro;
//using Domain.Interfaces.IUsuarioSistemaFinanceiro;
using Infra.Repositorio;

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
using Domain.Interfaces;
using Domain.Services;

namespace WebApi.Extensions
{
    public static class DependencyInjections
    {

        //  REPOSITORIOS
        public static IServiceCollection RegisterRepositories(this IServiceCollection services) => services    
            .AddScoped<IRepositoy<Supplement>,SupplementRepository>()
            .AddScoped<ISupplement, SupplementRepository>()

            .AddScoped<IRepositoy<Despesa>, DespesaRepository>()
            .AddScoped<IDespesaRepository, DespesaRepository>()

            .AddScoped<IJWTManager, JWTMAnagerRepo>()
            .AddScoped<ISupplement, SupplementRepository>();


        //SERVICOS
        public static IServiceCollection RegisterServices(this IServiceCollection services) => services
            .AddScoped<ISupplementService, SupplementService>()
            .AddScoped<IDespesaService, DespesaService>();



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
