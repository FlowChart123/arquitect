using Entities.IdentityModels;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata;
using System.Reflection.Emit;
using Entities.IdentityModels;

namespace Infra.Configuracao
{
    public partial class DataContext : IdentityDbContext<ApplicationUser>
    {


        #region Dbsets

        public virtual DbSet<AppRouteStatus> AppRouteStatuses { get; set; }

        public virtual DbSet<AppRouteUser> AppRouteUsers { get; set; }

        public virtual DbSet<AppRouteUserImagem> AppRouteUserImagems { get; set; }

        public virtual DbSet<AppRouteUserPessoa> AppRouteUserPessoas { get; set; }

        public virtual DbSet<AppRouteUserVeiculo> AppRouteUserVeiculos { get; set; }       

        public virtual DbSet<Bairro> Bairros { get; set; }

        public virtual DbSet<Canal> Canals { get; set; }

        public virtual DbSet<Cep> Ceps { get; set; }

        public virtual DbSet<CfopCte> CfopCtes { get; set; }

        public virtual DbSet<ChaveValor> ChaveValors { get; set; }

        public virtual DbSet<Ciot> Ciots { get; set; }

        public virtual DbSet<CiotDt> CiotDts { get; set; }

        public virtual DbSet<CiotStatus> CiotStatuses { get; set; }

        public virtual DbSet<Cliente> Clientes { get; set; }

        public virtual DbSet<ClienteCodigo> ClienteCodigos { get; set; }

        public virtual DbSet<CodigoBarra> CodigoBarras { get; set; }

        public virtual DbSet<CondicaoFaturamento> CondicaoFaturamentos { get; set; }

        public virtual DbSet<Config> Configs { get; set; }

        public virtual DbSet<CteStatusSefaz> CteStatusSefazs { get; set; }

        public virtual DbSet<CteStatusSistema> CteStatusSistemas { get; set; }

        public virtual DbSet<Documento> Documentos { get; set; }

        public virtual DbSet<Documento1> Documentos1 { get; set; }

        public virtual DbSet<DocumentoCte> DocumentoCtes { get; set; }

        public virtual DbSet<DocumentoEletronico> DocumentoEletronicos { get; set; }

        public virtual DbSet<DocumentoFilialGrupo> DocumentoFilialGrupos { get; set; }

        public virtual DbSet<DocumentoFrete> DocumentoFretes { get; set; }

        public virtual DbSet<DocumentoImposto> DocumentoImpostos { get; set; }

        public virtual DbSet<DocumentoItem> DocumentoItems { get; set; }

        public virtual DbSet<DocumentoTotal> DocumentoTotals { get; set; }

        public virtual DbSet<DocumentoTransportador> DocumentoTransportadors { get; set; }

        public virtual DbSet<DocumentoVolume> DocumentoVolumes { get; set; }

        public virtual DbSet<DocumentoVolume1> DocumentoVolumes1 { get; set; }

        public virtual DbSet<Dt> Dts { get; set; }

        public virtual DbSet<DtMdfe> DtMdves { get; set; }

        public virtual DbSet<DtMdfeDtRomaneio> DtMdfeDtRomaneios { get; set; }

        public virtual DbSet<DtRomaneioCarga> DtRomaneioCargas { get; set; }

        public virtual DbSet<DtStatus> DtStatuses { get; set; }

        public virtual DbSet<Empresa> Empresas { get; set; }

        public virtual DbSet<Endereco> Enderecos { get; set; }

        public virtual DbSet<EnderecoTipo> EnderecoTipos { get; set; }

        public virtual DbSet<Estado> Estados { get; set; }

        public virtual DbSet<Filial> Filials { get; set; }

        public virtual DbSet<FilialLastMile> FilialLastMiles { get; set; }

        public virtual DbSet<FilialLastMileGrupo> FilialLastMileGrupos { get; set; }

        public virtual DbSet<FilialLastMileGrupoItem> FilialLastMileGrupoItems { get; set; }

        public virtual DbSet<LogProcessamento> LogProcessamentos { get; set; }

        public virtual DbSet<LoteEletronico> LoteEletronicos { get; set; }

        public virtual DbSet<MenuItem> MenuItems { get; set; }

        public virtual DbSet<Modal> Modals { get; set; }

        public virtual DbSet<Motoristum> Motorista { get; set; }

        public virtual DbSet<Municipio> Municipios { get; set; }

        public virtual DbSet<Pai> Pais { get; set; }

        public virtual DbSet<Pessoa> Pessoas { get; set; }

        public virtual DbSet<PessoaEndereco> PessoaEnderecos { get; set; }

        public virtual DbSet<PessoaFisica> PessoaFisicas { get; set; }

        public virtual DbSet<PessoaFisicaComplemento> PessoaFisicaComplementos { get; set; }

        public virtual DbSet<PessoaFuncao> PessoaFuncaos { get; set; }

        public virtual DbSet<PessoaJuridica> PessoaJuridicas { get; set; }

        public virtual DbSet<PessoaJuridicaComplemento> PessoaJuridicaComplementos { get; set; }

        public virtual DbSet<PessoaOutro> PessoaOutros { get; set; }

        public virtual DbSet<PessoaTipoContato> PessoaTipoContatos { get; set; }

        public virtual DbSet<PessoaTipoContatoItem> PessoaTipoContatoItems { get; set; }

        public virtual DbSet<Produto> Produtos { get; set; }

        public virtual DbSet<Romaneio> Romaneios { get; set; }

        public virtual DbSet<RomaneioCarga> RomaneioCargas { get; set; }

        public virtual DbSet<RomaneioChave> RomaneioChaves { get; set; }

        public virtual DbSet<RomaneioDocumento> RomaneioDocumentos { get; set; }

        public virtual DbSet<Segmento> Segmentos { get; set; }

        public virtual DbSet<Tenant> Tenants { get; set; }

        public virtual DbSet<TipoContum> TipoConta { get; set; }

        public virtual DbSet<TipoCte> TipoCtes { get; set; }

        public virtual DbSet<TipoDocumento> TipoDocumentos { get; set; }

        public virtual DbSet<TipoRntrc> TipoRntrcs { get; set; }

        public virtual DbSet<TipoServicoPrestado> TipoServicoPrestados { get; set; }

        public virtual DbSet<Transportador> Transportadors { get; set; }

        public virtual DbSet<Transportador1> Transportadors1 { get; set; }

        public virtual DbSet<TransportadorLastMile> TransportadorLastMiles { get; set; }

        public virtual DbSet<TransportadorLastMileGrupo> TransportadorLastMileGrupos { get; set; }

        public virtual DbSet<TransportadorLastMileGrupoItem> TransportadorLastMileGrupoItems { get; set; }

        public virtual DbSet<Veiculo> Veiculos { get; set; }

        public virtual DbSet<Veiculo1> Veiculos1 { get; set; }

        public virtual DbSet<VeiculoTipo> VeiculoTipos { get; set; }


        #endregion


    }
}
