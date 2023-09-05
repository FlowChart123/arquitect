//using Domain.Interfaces.ICategoria;
//using Domain.Interfaces.IDespesa;
//using Domain.Interfaces.ISistemaFinanceiro;
//using Domain.Interfaces.IUsuarioSistemaFinanceiro;
using Infra.Repositorio;


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
using Infra.Repository.Generics;

namespace WebApi.Extensions
{
    public static class DependencyInjections
    {

        //  REPOSITORIOS
        public static IServiceCollection RegisterRepositories(this IServiceCollection services) => services                
            //.AddScoped<ISupplement, SupplementRepository>()


            //.AddScoped<IRepositoy<Bairro>, BairroRepository>()
            //.AddScoped<IBairroRepository, BairroRepository>()


            .AddScoped<IRepositoy<CodigoBarra>, CodigoBarraRepository>()
            .AddScoped<ICodigoBarraRepository, CodigoBarraRepository>()

            .AddScoped<IRepositoy<Documento>, DocumentoRepository>()
            .AddScoped<IDocumentoRepository, DocumentoRepository>()


            .AddScoped<IRepositoy<DocumentoFilialGrupo>, DocumentoFilialGrupoRepository>()
            .AddScoped<IDocumentoFilialGrupoRepository, DocumentoFilialGrupoRepository>()

            .AddScoped<IRepositoy<DocumentoImposto>, DocumentoImpostoRepository>()
            .AddScoped<IDocumentoImpostoRepository, DocumentoImpostoRepository>()

            .AddScoped<IRepositoy<DocumentoItem>, DocumentoItemRepository>()
            .AddScoped<IDocumentoItemRepository, DocumentoItemRepository>()

            .AddScoped<IRepositoy<DocumentoTotal>, DocumentoTotalRepository>()
            .AddScoped<IDocumentoTotalRepository, DocumentoTotalRepository>()

            .AddScoped<IRepositoy<DocumentoTransportador>, DocumentoTransportadorRepository>()
            .AddScoped<IDocumentoTransportadorRepository, DocumentoTransportadorRepository>()

            .AddScoped<IRepositoy<Empresa>, EmpresaRepository>()
            .AddScoped<IEmpresaRepository, EmpresaRepository>()

            .AddScoped<IRepositoy<Endereco>, EnderecoRepository>()
            .AddScoped<IEnderecoRepository, EnderecoRepository>()

            .AddScoped<IRepositoy<Filial>, FilialRepository>()
            .AddScoped<IFilialRepository, FilialRepository>()

            .AddScoped<IRepositoy<FilialLastMileGrupo>, FilialLastMileGrupoRepository>()
            .AddScoped<IFilialLastMileGrupoRepository, FilialLastMileGrupoRepository>()

            .AddScoped<IRepositoy<FilialLastMileGrupoItem>, FilialLastMileGrupoItemRepository>()
            .AddScoped<IFilialLastMileGrupoItemRepository, FilialLastMileGrupoItemRepository>()


            //.AddScoped<IRepositoy<FilialLastMile>, FilialLastMileRepository>()
            //.AddScoped<FilialLastMileRepository, FilialLastMileRepository>()

            .AddScoped<IRepositoy<Pessoa>, PessoaRepository>()
            .AddScoped<IPessoaRepository, PessoaRepository>()

            .AddScoped<IRepositoy<PessoaEndereco>, PessoaEnderecoRepository>()
            .AddScoped<IPessoaEnderecoRepository, PessoaEnderecoRepository>()

            .AddScoped<IRepositoy<PessoaFisica>, PessoaFisicaRepository>()
            .AddScoped<IPessoaFisicaRepository, PessoaFisicaRepository>()

            .AddScoped<IRepositoy<PessoaJuridica>, PessoaJuridicaRepository>()
            .AddScoped<IPessoaJuridicaRepository, PessoaJuridicaRepository>()

            .AddScoped<IRepositoy<PessoaOutro>, PessoaOutroRepository>()
            .AddScoped<IPessoaOutroRepository, PessoaOutroRepository>()

            .AddScoped<IRepositoy<Produto>, ProdutoRepository>()
            .AddScoped<IProdutoRepository, ProdutoRepository>()

            .AddScoped<IRepositoy<Romaneio>, RomaneioRepository>()
            .AddScoped<IRomaneioRepository, RomaneioRepository>()

            .AddScoped<IRepositoy<RomaneioCarga>, RomaneioCargaRepository>()
            .AddScoped<IRomaneioCargaRepository, RomaneioCargaRepository>()

            .AddScoped<IRepositoy<RomaneioDocumento>, RomaneioDocumentoRepository>()
            .AddScoped<IRomaneioDocumentoRepository, RomaneioDocumentoRepository>()


            .AddSingleton<GenericListRepository, GenericListRepository>()

            .AddScoped<IJWTManager, JWTMAnagerRepo>();
            


        //SERVICOS
        public static IServiceCollection RegisterServices(this IServiceCollection services) => services
            .AddScoped<IBairroService, BairroService>()
            .AddScoped<ICodigoBarraService, CodigoBarraService>()
            .AddScoped<IDocumentoFilialGrupoService, DocumentoFilialGrupoService>()
            .AddScoped<IDocumentoImpostoService, DocumentoImpostoService>()
            .AddScoped<IDocumentoItemService, DocumentoItemService>()
            .AddScoped<IDocumentoService, DocumentoService>()
            .AddScoped<IDocumentoTotalService, DocumentoTotalService>()
            .AddScoped<IDocumentoTransportadorService, DocumentoTransportadorService>()
            .AddScoped<IEmpresaService, EmpresaService>()
            .AddScoped<IEnderecoService, EnderecoService>()
            .AddScoped<IFilialLastMileGrupoItemService, FilialLastMileGrupoItemService>()
            .AddScoped<IFilialLastMileGrupoService, FilialLastMileGrupoService>()
            .AddScoped<IFilialLastMileGrupoItemService, FilialLastMileGrupoItemService>()
            .AddScoped<IFilialService, FilialService>()
            .AddScoped<IPessoaService, PessoaService>()
            .AddScoped<IPessoaEnderecoService, PessoaEnderecoService>()
            .AddScoped<IPessoaFisicaService, PessoaFisicaService>()
            .AddScoped<IPessoaJuridicaService, PessoaJuridicaService>()
            .AddScoped<IPessoaOutroService, PessoaOutroService>()
            .AddScoped<IProdutoService, ProdutoService>()
            .AddScoped<IRomaneioService, RomaneioService>()
            .AddScoped<IRomaneioCargaService, RomaneioCargaService>()
            .AddScoped<IRomaneioDocumentoService, RomaneioDocumentoService>()
            .AddScoped<IBairroService, BairroService>();



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
