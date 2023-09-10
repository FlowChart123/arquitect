//using Domain.Interfaces.ICategoria;
//using Domain.Interfaces.IDespesa;
//using Domain.Interfaces.ISistemaFinanceiro;
//using Domain.Interfaces.IUsuarioSistemaFinanceiro;
using Infra.Repositorio;



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
using Infra.Repository.Generics;
using Infra.Repository;
using Infra.Configuracao;

namespace WebApi.Extensions
{
    public static class DependencyInjections
    {

        //  REPOSITORIOS
        public static IServiceCollection RegisterRepositories(this IServiceCollection services) => services                            
            .AddScoped <IUnitOfWork, UnitOfWork>()
            .AddScoped<IPessoaRepository, PessoaRepository>()
            .AddScoped<IRepositoy<Pessoa>, PessoaRepository>()
            .AddScoped<IRepositoy<PessoaFisica>, PessoaFisicaRepository>()
            .AddScoped<IRepositoy<PessoaJuridica>, PessoaJuridicaRepository>()
            .AddScoped<IRepositoy<PessoaFisicaComplemento>, PessoaFisicaComplementoRepository>()
            .AddSingleton<GenericListRepository, GenericListRepository>()
            .AddScoped<IJWTManager, JWTMAnagerRepo>();



        //SERVICOS
        public static IServiceCollection RegisterServices(this IServiceCollection services) => services
            .AddScoped<IPessoaService, PessoaService>();
            
    }
}
