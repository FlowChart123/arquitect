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


namespace Infra.Configuracao
{
    public partial class DataContext : IdentityDbContext<ApplicationUser>
    {


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            OnModelCreatingIdentity(modelBuilder);


            modelBuilder.Entity<AppRouteStatus>(entity =>
            {
                entity.ToTable("AppRouteStatus");

                entity.Property(e => e.Id).ValueGeneratedNever();
                entity.Property(e => e.Descricao)
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<AppRouteUser>(entity =>
            {
                entity.ToTable("AppRouteUser");

                entity.Property(e => e.Id).ValueGeneratedNever();
                entity.Property(e => e.Celular)
                    .HasMaxLength(14)
                    .IsUnicode(false);
                entity.Property(e => e.CelularCodigoConfirmacao)
                    .HasMaxLength(50)
                    .IsUnicode(false);
                entity.Property(e => e.Cpf)
                    .HasMaxLength(14)
                    .IsUnicode(false);
                entity.Property(e => e.DataCadastro)
                    .HasDefaultValueSql("(getdate())")
                    .HasColumnType("datetime");
                entity.Property(e => e.UltimoAcesso).HasColumnType("datetime");

                entity.HasOne(d => d.AppRouteStatus).WithMany(p => p.AppRouteUsers)
                    .HasForeignKey(d => d.AppRouteStatusId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_AppRouteUser_AppRouteStatus");
            });

            modelBuilder.Entity<AppRouteUserImagem>(entity =>
            {
                entity.ToTable("AppRouteUserImagem");

                entity.Property(e => e.Id).ValueGeneratedNever();
                entity.Property(e => e.NomeArquivo)
                    .HasMaxLength(100)
                    .IsUnicode(false);
                entity.Property(e => e.Placa)
                    .HasMaxLength(8)
                    .IsUnicode(false);
                entity.Property(e => e.TipoImagem)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdAppRouteUserNavigation).WithMany(p => p.AppRouteUserImagems)
                    .HasForeignKey(d => d.IdAppRouteUser)
                    .HasConstraintName("FK_AppRouteUserImagem_AppRouteUser");
            });

            modelBuilder.Entity<AppRouteUserPessoa>(entity =>
            {
                entity.ToTable("AppRouteUserPessoa");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.HasOne(d => d.AppRouteUserNavigation).WithMany(p => p.AppRouteUserPessoas)
                    .HasForeignKey(d => d.AppRouteUser)
                    .HasConstraintName("FK_AppRouteUserPessoa_AppRouteUser");

                entity.HasOne(d => d.PessoaFuncao).WithMany(p => p.AppRouteUserPessoas)
                    .HasForeignKey(d => d.PessoaFuncaoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_AppRouteUserPessoa_PessoaFuncao");

                entity.HasOne(d => d.Pessoa).WithMany(p => p.AppRouteUserPessoas)
                    .HasForeignKey(d => d.PessoaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_AppRouteUserPessoa_Pessoa");
            });

            modelBuilder.Entity<AppRouteUserVeiculo>(entity =>
            {
                entity.ToTable("AppRouteUserVeiculo");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.HasOne(d => d.Veiculo).WithMany(p => p.AppRouteUserVeiculos)
                    .HasForeignKey(d => d.VeiculoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_AppRouteUserVeiculo_Veiculo");
            });

            modelBuilder.Entity<Bairro>(entity =>
            {
                entity.ToTable("Bairro");

                entity.Property(e => e.Id).ValueGeneratedNever();
                entity.Property(e => e.DataCadastro)
                    .HasDefaultValueSql("(getdate())")
                    .HasColumnType("datetime");
                entity.Property(e => e.Nome)
                    .HasMaxLength(60)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Canal>(entity =>
            {
                entity.ToTable("Canal", "tnt");

                entity.Property(e => e.Descricao)
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Cep>(entity =>
            {
                entity
                    .HasNoKey()
                    .ToTable("Cep");

                entity.HasIndex(e => e.Cep1, "IX_Cep");

                entity.HasIndex(e => new { e.Uf, e.NomeOficial }, "IX_CepUf_NomeOficial");

                entity.Property(e => e.Bairro1Acento)
                    .HasMaxLength(72)
                    .HasColumnName("Bairro1_Acento");
                entity.Property(e => e.Bairro1Oficial)
                    .HasMaxLength(72)
                    .HasColumnName("Bairro1_Oficial");
                entity.Property(e => e.Cep1)
                    .HasMaxLength(8)
                    .HasColumnName("CEP");
                entity.Property(e => e.Chave)
                    .HasMaxLength(8)
                    .HasColumnName("CHAVE");
                entity.Property(e => e.CidadeAcento)
                    .HasMaxLength(80)
                    .HasColumnName("Cidade_Acento");
                entity.Property(e => e.CidadeOficial)
                    .HasMaxLength(80)
                    .HasColumnName("Cidade_Oficial");
                entity.Property(e => e.CodMun)
                    .HasMaxLength(7)
                    .HasColumnName("Cod_Mun");
                entity.Property(e => e.Ddd)
                    .HasMaxLength(7)
                    .HasColumnName("DDD");
                entity.Property(e => e.Flags).HasColumnName("FLAGS");
                entity.Property(e => e.Lados).HasColumnName("LADOS");
                entity.Property(e => e.Latitude)
                    .HasMaxLength(15)
                    .HasColumnName("latitude");
                entity.Property(e => e.Liminfimpa).HasColumnName("LIMINFIMPA");
                entity.Property(e => e.Liminfpar).HasColumnName("LIMINFPAR");
                entity.Property(e => e.Limsupimpa).HasColumnName("LIMSUPIMPA");
                entity.Property(e => e.Limsuppar).HasColumnName("LIMSUPPAR");
                entity.Property(e => e.LogComplemento)
                    .HasMaxLength(100)
                    .HasColumnName("log_complemento");
                entity.Property(e => e.Longitude)
                    .HasMaxLength(15)
                    .HasColumnName("longitude");
                entity.Property(e => e.NomeAcento)
                    .HasMaxLength(100)
                    .HasColumnName("Nome_Acento");
                entity.Property(e => e.NomeCepEsp)
                    .HasMaxLength(80)
                    .HasColumnName("nome_cep_esp");
                entity.Property(e => e.NomeOficial)
                    .HasMaxLength(100)
                    .HasColumnName("Nome_Oficial");
                entity.Property(e => e.TipoAcento)
                    .HasMaxLength(50)
                    .HasColumnName("Tipo_Acento");
                entity.Property(e => e.TipoOficial)
                    .HasMaxLength(50)
                    .HasColumnName("Tipo_Oficial");
                entity.Property(e => e.Uf)
                    .HasMaxLength(2)
                    .HasColumnName("UF");
            });

            modelBuilder.Entity<CfopCte>(entity =>
            {
                entity.ToTable("CfopCTe");

                entity.Property(e => e.Id).ValueGeneratedNever();
                entity.Property(e => e.Descricao)
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<ChaveValor>(entity =>
            {
                entity.ToTable("ChaveValor");

                entity.HasIndex(e => new { e.TenantId, e.Chave, e.Valor }, "UC_ChaveValor").IsUnique();

                entity.Property(e => e.Id).ValueGeneratedNever();
                entity.Property(e => e.Chave)
                    .HasMaxLength(100)
                    .IsUnicode(false);
                entity.Property(e => e.DataCadastro).HasColumnType("datetime");
                entity.Property(e => e.Valor)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.Tenant).WithMany(p => p.ChaveValors)
                    .HasForeignKey(d => d.TenantId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ChaveValor_TenantId_Tenant");
            });

            modelBuilder.Entity<Ciot>(entity =>
            {
                entity.ToTable("Ciot", "tnt");

                entity.Property(e => e.Id).ValueGeneratedNever();
                entity.Property(e => e.DataCadastro).HasColumnType("datetime");
                entity.Property(e => e.DataCancelamento).HasColumnType("datetime");
                entity.Property(e => e.DataEmissao).HasColumnType("datetime");
                entity.Property(e => e.DataFechamento).HasColumnType("datetime");
                entity.Property(e => e.DataRetificacao).HasColumnType("datetime");
                entity.Property(e => e.Numero)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.HasOne(d => d.CiotStatus).WithMany(p => p.Ciots)
                    .HasForeignKey(d => d.CiotStatusId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Ciot_CiotStatusId_CiotStatus");

                entity.HasOne(d => d.Filial).WithMany(p => p.Ciots)
                    .HasForeignKey(d => d.FilialId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Ciot_FilialId_Filial");

                entity.HasOne(d => d.Tenant).WithMany(p => p.Ciots)
                    .HasForeignKey(d => d.TenantId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Ciot_TenantId_Tenant");
            });

            modelBuilder.Entity<CiotDt>(entity =>
            {
                entity.ToTable("CiotDt", "tnt");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.HasOne(d => d.Ciot).WithMany(p => p.CiotDts)
                    .HasForeignKey(d => d.CiotId)
                    .HasConstraintName("FK_CiotDt_CiotId_CiotDt");

                entity.HasOne(d => d.Dt).WithMany(p => p.CiotDts)
                    .HasForeignKey(d => d.DtId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CiotDt_DtId_Dt");
            });

            modelBuilder.Entity<CiotStatus>(entity =>
            {
                entity.ToTable("CiotStatus");

                entity.Property(e => e.Id).ValueGeneratedNever();
                entity.Property(e => e.Descricao)
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Cliente>(entity =>
            {
                entity.ToTable("Cliente", "tnt");

                entity.Property(e => e.Id).ValueGeneratedNever();
                entity.Property(e => e.CfopCteId).HasColumnName("CfopCTeId");
                entity.Property(e => e.DiaPagamentoMes)
                    .HasMaxLength(50)
                    .IsUnicode(false);
                entity.Property(e => e.DiaPagamentoSemana)
                    .HasMaxLength(50)
                    .IsUnicode(false);
                entity.Property(e => e.InicioContagemPrazo)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.Canal).WithMany(p => p.Clientes)
                    .HasForeignKey(d => d.CanalId)
                    .HasConstraintName("FK_Cliente_CanalId_Canal");

                entity.HasOne(d => d.CfopCte).WithMany(p => p.Clientes)
                    .HasForeignKey(d => d.CfopCteId)
                    .HasConstraintName("FK_Cliente_CfopCTeId_CfopCTe");

                entity.HasOne(d => d.ClienteCodigo).WithMany(p => p.Clientes)
                    .HasForeignKey(d => d.ClienteCodigoId)
                    .HasConstraintName("FK_Cliente_ClienteCodigoId_ClienteCodigo");

                entity.HasOne(d => d.CondicaoFaturamento).WithMany(p => p.Clientes)
                    .HasForeignKey(d => d.CondicaoFaturamentoId)
                    .HasConstraintName("FK_Cliente_CondicaoFaturamentoId_CondicaoFaturamento");

                entity.HasOne(d => d.FaturamentoFilial).WithMany(p => p.Clientes)
                    .HasForeignKey(d => d.FaturamentoFilialId)
                    .HasConstraintName("FK_Cliente_FaturamentoFilialId_Filial");

                entity.HasOne(d => d.IdNavigation).WithOne(p => p.Cliente)
                    .HasForeignKey<Cliente>(d => d.Id)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Cliente_Id_Pessoa");
            });

            modelBuilder.Entity<ClienteCodigo>(entity =>
            {
                entity.ToTable("ClienteCodigo", "tnt");

                entity.Property(e => e.Descricao)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.Tenant).WithMany(p => p.ClienteCodigos)
                    .HasForeignKey(d => d.TenantId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ClienteCodigo_TenantId_Tenant");
            });

            modelBuilder.Entity<CodigoBarra>(entity =>
            {
                entity.ToTable("CodigoBarra");

                entity.Property(e => e.Id).ValueGeneratedNever();
                entity.Property(e => e.Altura).HasColumnType("numeric(10, 3)");
                entity.Property(e => e.CodigoBarras)
                    .HasMaxLength(20)
                    .IsUnicode(false);
                entity.Property(e => e.Comprimento).HasColumnType("numeric(10, 3)");
                entity.Property(e => e.Largura).HasColumnType("numeric(10, 3)");
                entity.Property(e => e.Peso).HasColumnType("numeric(18, 3)");
            });

            modelBuilder.Entity<CondicaoFaturamento>(entity =>
            {
                entity.ToTable("CondicaoFaturamento");

                entity.Property(e => e.Id).ValueGeneratedNever();
                entity.Property(e => e.Descricao)
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Config>(entity =>
            {
                entity.ToTable("Config");

                entity.Property(e => e.Id).ValueGeneratedNever();
                entity.Property(e => e.Banco)
                    .HasMaxLength(50)
                    .IsUnicode(false);
                entity.Property(e => e.PastaTenant)
                    .HasMaxLength(100)
                    .IsUnicode(false);
                entity.Property(e => e.PastaXml)
                    .HasMaxLength(100)
                    .IsUnicode(false);
                entity.Property(e => e.PastaXmlProcessados)
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<CteStatusSefaz>(entity =>
            {
                entity.ToTable("CTeStatusSefaz");

                entity.Property(e => e.Id).ValueGeneratedNever();
                entity.Property(e => e.Descricao)
                    .HasMaxLength(500)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<CteStatusSistema>(entity =>
            {
                entity.ToTable("CTeStatusSistema");

                entity.Property(e => e.Id).ValueGeneratedNever();
                entity.Property(e => e.Descricao)
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Documento>(entity =>
            {
                entity.ToTable("Documento");

                entity.Property(e => e.Id).ValueGeneratedNever();
                entity.Property(e => e.Chave)
                    .HasMaxLength(44)
                    .IsUnicode(false);
                entity.Property(e => e.DataCadastro)
                    .HasDefaultValueSql("(getdate())")
                    .HasColumnType("datetime");
                entity.Property(e => e.DataEmissao).HasColumnType("datetime");
                entity.Property(e => e.NumeroCliente)
                    .HasMaxLength(20)
                    .IsUnicode(false);
                entity.Property(e => e.Serie)
                    .HasMaxLength(10)
                    .IsUnicode(false);
                entity.Property(e => e.XPed)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("xPed");

                entity.HasOne(d => d.Destinatario).WithMany(p => p.DocumentoDestinatarios)
                    .HasForeignKey(d => d.DestinatarioId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Documento_DestinatarioId_Pessoa");

                entity.HasOne(d => d.Emitente).WithMany(p => p.DocumentoEmitentes)
                    .HasForeignKey(d => d.EmitenteId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Documento_EmitenteId_Pessoa");

                entity.HasOne(d => d.Remetente).WithMany(p => p.DocumentoRemetentes)
                    .HasForeignKey(d => d.RemetenteId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Documento_RemetenteId_Pessoa");

                entity.HasOne(d => d.TipoDocumento).WithMany(p => p.Documentos)
                    .HasForeignKey(d => d.TipoDocumentoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Documento_IdTipoDocumento_TipoDocumento");
            });

            modelBuilder.Entity<Documento1>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PK_Documento_Id");

                entity.ToTable("Documento", "tnt");

                entity.HasIndex(e => new { e.TenantId, e.DocumentoId }, "UC_Documento_TenantId_DocumentoId").IsUnique();

                entity.Property(e => e.Id).ValueGeneratedNever();
                entity.Property(e => e.DataEntrada).HasColumnType("datetime");

                entity.HasOne(d => d.Documento).WithMany(p => p.Documento1s)
                    .HasForeignKey(d => d.DocumentoId)
                    .HasConstraintName("FK_Documento_DocumentoId_Documento");

                entity.HasOne(d => d.Tenant).WithMany(p => p.Documento1s)
                    .HasForeignKey(d => d.TenantId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Documento_TenantId_Tenant");
            });

            modelBuilder.Entity<DocumentoCte>(entity =>
            {
                entity.ToTable("DocumentoCTe", "tnt");

                entity.Property(e => e.Id).ValueGeneratedNever();
                entity.Property(e => e.CaracteristicaServico)
                    .HasMaxLength(30)
                    .IsUnicode(false);
                entity.Property(e => e.CaracteristicaTransporte)
                    .HasMaxLength(15)
                    .IsUnicode(false);
                entity.Property(e => e.CteStatusSefazId).HasColumnName("CTeStatusSefazId");
                entity.Property(e => e.CteStatusSistemaId).HasColumnName("CTeStatusSistemaId");
                entity.Property(e => e.IndicadorTipoCte)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("IndicadorTipoCTe");
                entity.Property(e => e.Recibo)
                    .HasMaxLength(50)
                    .IsUnicode(false);
                entity.Property(e => e.TipoCteId).HasColumnName("TipoCTeId");

                entity.HasOne(d => d.CteStatusSefaz).WithMany(p => p.DocumentoCtes)
                    .HasForeignKey(d => d.CteStatusSefazId)
                    .HasConstraintName("FK_DocumentoCTe_CTeStatusSefazId_CTeStatusSefaz");

                entity.HasOne(d => d.CteStatusSistema).WithMany(p => p.DocumentoCtes)
                    .HasForeignKey(d => d.CteStatusSistemaId)
                    .HasConstraintName("FK_DocumentoCTe_CTeStatusSistemaId_CTeStatusSistema");

                entity.HasOne(d => d.DocumentoFrete).WithMany(p => p.DocumentoCtes)
                    .HasForeignKey(d => d.DocumentoFreteId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_DocumentoCTe_DocumentoFreteId_DocumentoFrete");

                entity.HasOne(d => d.Expedidor).WithMany(p => p.DocumentoCteExpedidors)
                    .HasForeignKey(d => d.ExpedidorId)
                    .HasConstraintName("FK_DocumentoCTe_ExpedidorId_Pessoa");

                entity.HasOne(d => d.FilialDestino).WithMany(p => p.DocumentoCtes)
                    .HasForeignKey(d => d.FilialDestinoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_DocumentoCTe_FilialDestinoId_Empresa");

                entity.HasOne(d => d.FilialOrigem).WithMany(p => p.DocumentoCtes)
                    .HasForeignKey(d => d.FilialOrigemId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_DocumentoCTe_FilialOrigemId_Filial");

                entity.HasOne(d => d.IdNavigation).WithOne(p => p.DocumentoCte)
                    .HasForeignKey<DocumentoCte>(d => d.Id)
                    .HasConstraintName("FK_DocumentoCTe_Id_TntDocumento");

                entity.HasOne(d => d.Modal).WithMany(p => p.DocumentoCtes)
                    .HasForeignKey(d => d.ModalId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_DocumentoCTe_ModalId_Modal");

                entity.HasOne(d => d.MunicipioFinalTransporte).WithMany(p => p.DocumentoCteMunicipioFinalTransportes)
                    .HasForeignKey(d => d.MunicipioFinalTransporteId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_DocumentoCTe_MunicipioFinalTransporteId_Municipio");

                entity.HasOne(d => d.MunicipioInicioTransporte).WithMany(p => p.DocumentoCteMunicipioInicioTransportes)
                    .HasForeignKey(d => d.MunicipioInicioTransporteId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_DocumentoCTe_MunicipioInicioTransporteId_Municipio");

                entity.HasOne(d => d.Recebedor).WithMany(p => p.DocumentoCteRecebedors)
                    .HasForeignKey(d => d.RecebedorId)
                    .HasConstraintName("FK_DocumentoCTe_RecebedorId_Pessoa");

                entity.HasOne(d => d.TipoCte).WithMany(p => p.DocumentoCtes)
                    .HasForeignKey(d => d.TipoCteId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_DocumentoCTe_TipoCTeId_TipoCTe");

                entity.HasOne(d => d.TipoServicoPrestado).WithMany(p => p.DocumentoCtes)
                    .HasForeignKey(d => d.TipoServicoPrestadoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_DocumentoCTe_TipoServicoPrestadoId_TipoServicoPrestado");

                entity.HasOne(d => d.TomadorServico).WithMany(p => p.DocumentoCtes)
                    .HasForeignKey(d => d.TomadorServicoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_DocumentoCTe_TomadorServicoId_Cliente");
            });

            modelBuilder.Entity<DocumentoEletronico>(entity =>
            {
                entity.ToTable("DocumentoEletronico", "tnt");

                entity.Property(e => e.Id).ValueGeneratedNever();
                entity.Property(e => e.CteStatusSefazId).HasColumnName("CTeStatusSefazId");
                entity.Property(e => e.CteStatusSistemaId).HasColumnName("CTeStatusSistemaId");
                entity.Property(e => e.DataCadastro)
                    .HasDefaultValueSql("(getdate())")
                    .HasColumnType("datetime");

                entity.HasOne(d => d.Documento).WithMany(p => p.DocumentoEletronicos)
                    .HasForeignKey(d => d.DocumentoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_DocumentoEletronico_DocumentoId_DocumentoCTe");

                entity.HasOne(d => d.LoteEletronico).WithMany(p => p.DocumentoEletronicos)
                    .HasForeignKey(d => d.LoteEletronicoId)
                    .HasConstraintName("FK_DocumentoEletronico_LoteEletronicoId_LoteEletronico");
            });

            modelBuilder.Entity<DocumentoFilialGrupo>(entity =>
            {
                entity.ToTable("DocumentoFilialGrupo", "tnt");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.HasOne(d => d.EnderecoServico).WithMany(p => p.DocumentoFilialGrupos)
                    .HasForeignKey(d => d.EnderecoServicoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_DocumentoRegiao_IdEnderecoServicoId_Endereco");

                entity.HasOne(d => d.IdNavigation).WithOne(p => p.DocumentoFilialGrupo)
                    .HasForeignKey<DocumentoFilialGrupo>(d => d.Id)
                    .HasConstraintName("FK_DocumentoRegiao_Id_Documento");
            });

            modelBuilder.Entity<DocumentoFrete>(entity =>
            {
                entity.ToTable("DocumentoFrete", "tnt");

                entity.Property(e => e.Id).ValueGeneratedNever();
                entity.Property(e => e.Aliquota).HasColumnType("numeric(10, 4)");
                entity.Property(e => e.BaseDeCalculo).HasColumnType("numeric(18, 2)");
                entity.Property(e => e.BaseDeCalculoOutraUf).HasColumnType("numeric(18, 2)");
                entity.Property(e => e.BaseDeCalculoStretido)
                    .HasColumnType("numeric(18, 8)")
                    .HasColumnName("BaseDeCalculoSTRetido");
                entity.Property(e => e.CreditoOutorgado).HasColumnType("numeric(18, 2)");
                entity.Property(e => e.Cst)
                    .HasMaxLength(2)
                    .IsUnicode(false);
                entity.Property(e => e.Despacho).HasColumnType("numeric(18, 2)");
                entity.Property(e => e.Frete).HasColumnType("numeric(18, 2)");
                entity.Property(e => e.FreteExcedente).HasColumnType("numeric(18, 2)");
                entity.Property(e => e.FretePeso).HasColumnType("numeric(18, 2)");
                entity.Property(e => e.FreteValor).HasColumnType("numeric(18, 2)");
                entity.Property(e => e.Gris).HasColumnType("numeric(18, 2)");
                entity.Property(e => e.IcmsIss).HasColumnType("numeric(18, 2)");
                entity.Property(e => e.IcmsOutraUf).HasColumnType("numeric(18, 2)");
                entity.Property(e => e.IcmsStretido)
                    .HasColumnType("numeric(18, 2)")
                    .HasColumnName("IcmsSTRetido");
                entity.Property(e => e.ImpostoArecolher)
                    .HasColumnType("numeric(18, 2)")
                    .HasColumnName("ImpostoARecolher");
                entity.Property(e => e.Outros).HasColumnType("numeric(18, 2)");
                entity.Property(e => e.Pedagio).HasColumnType("numeric(18, 2)");
                entity.Property(e => e.PercentualIcmsOutraUf).HasColumnType("numeric(10, 4)");
                entity.Property(e => e.PercentualIcmsRetido).HasColumnType("numeric(10, 4)");
                entity.Property(e => e.PercentualReducaoBaseCalculo).HasColumnType("numeric(10, 4)");
                entity.Property(e => e.PercentualReducaoBaseCalculoOutraUf).HasColumnType("numeric(10, 4)");
                entity.Property(e => e.TaxaDeColeta).HasColumnType("numeric(18, 2)");
                entity.Property(e => e.TaxaDeEntrega).HasColumnType("numeric(18, 2)");
                entity.Property(e => e.Tde).HasColumnType("numeric(18, 2)");
                entity.Property(e => e.Trt).HasColumnType("numeric(18, 2)");
            });

            modelBuilder.Entity<DocumentoImposto>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PK_DocumentoPadraoImposto");

                entity.ToTable("DocumentoImposto");

                entity.Property(e => e.Id).ValueGeneratedNever();
                entity.Property(e => e.CEnq)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("cEnq");
                entity.Property(e => e.CofinsCst)
                    .HasMaxLength(2)
                    .IsUnicode(false);
                entity.Property(e => e.CofinspCofins)
                    .HasColumnType("numeric(18, 2)")
                    .HasColumnName("CofinspCOFINS");
                entity.Property(e => e.CofinsvBc)
                    .HasColumnType("numeric(18, 2)")
                    .HasColumnName("CofinsvBC");
                entity.Property(e => e.CofinsvCofins).HasColumnType("numeric(18, 2)");
                entity.Property(e => e.Icms)
                    .HasMaxLength(100)
                    .IsUnicode(false);
                entity.Property(e => e.IcmsCst)
                    .HasMaxLength(2)
                    .IsUnicode(false);
                entity.Property(e => e.IpiCst)
                    .HasMaxLength(2)
                    .IsUnicode(false);
                entity.Property(e => e.Orig)
                    .HasMaxLength(1)
                    .IsUnicode(false);
                entity.Property(e => e.PIcms)
                    .HasColumnType("numeric(18, 2)")
                    .HasColumnName("pIcms");
                entity.Property(e => e.PisCst)
                    .HasMaxLength(2)
                    .IsUnicode(false);
                entity.Property(e => e.PispPis)
                    .HasColumnType("numeric(18, 2)")
                    .HasColumnName("PispPIS");
                entity.Property(e => e.PisvBc).HasColumnType("numeric(18, 2)");
                entity.Property(e => e.PisvPis).HasColumnType("numeric(18, 2)");
                entity.Property(e => e.VBc)
                    .HasColumnType("numeric(18, 2)")
                    .HasColumnName("vBC");
                entity.Property(e => e.VIcms)
                    .HasColumnType("numeric(18, 2)")
                    .HasColumnName("vIcms");

                entity.HasOne(d => d.IdNavigation).WithOne(p => p.DocumentoImposto)
                    .HasForeignKey<DocumentoImposto>(d => d.Id)
                    .HasConstraintName("FK_DocumentoImposto_Id_Documento");
            });

            modelBuilder.Entity<DocumentoItem>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PK_DocumentoPadraoItem");

                entity.ToTable("DocumentoItem");

                entity.Property(e => e.Id).ValueGeneratedNever();
                entity.Property(e => e.CEan)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("cEan");
                entity.Property(e => e.CEantrib)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("cEANTrib");
                entity.Property(e => e.CProd)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("cProd");
                entity.Property(e => e.Cfop)
                    .HasMaxLength(4)
                    .IsUnicode(false);
                entity.Property(e => e.NItem).HasColumnName("nItem");
                entity.Property(e => e.Ncm)
                    .HasMaxLength(8)
                    .IsUnicode(false);
                entity.Property(e => e.QCom)
                    .HasColumnType("numeric(18, 5)")
                    .HasColumnName("qCom");
                entity.Property(e => e.QTrib)
                    .HasColumnType("numeric(18, 2)")
                    .HasColumnName("qTrib");
                entity.Property(e => e.Quantidade).HasColumnType("numeric(18, 3)");
                entity.Property(e => e.UCom)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("uCom");
                entity.Property(e => e.UTrib)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("uTrib");
                entity.Property(e => e.VProd)
                    .HasColumnType("numeric(18, 2)")
                    .HasColumnName("vProd");
                entity.Property(e => e.VUnCom)
                    .HasColumnType("numeric(18, 5)")
                    .HasColumnName("vUnCom");
                entity.Property(e => e.VUnTrib)
                    .HasColumnType("numeric(18, 5)")
                    .HasColumnName("vUnTrib");
                entity.Property(e => e.XPed)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("xPed");

                entity.HasOne(d => d.Documento).WithMany(p => p.DocumentoItems)
                    .HasForeignKey(d => d.DocumentoId)
                    .HasConstraintName("FK_DocumentoItem_DocumentoId_Documento");

                entity.HasOne(d => d.Produto).WithMany(p => p.DocumentoItems)
                    .HasForeignKey(d => d.ProdutoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_DocumentoPadraoItem_ProdutoId_Produto");
            });

            modelBuilder.Entity<DocumentoTotal>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PK_DocumentoPadraoTotal");

                entity.ToTable("DocumentoTotal");

                entity.Property(e => e.Id).ValueGeneratedNever();
                entity.Property(e => e.MetragemCubica).HasColumnType("numeric(10, 3)");
                entity.Property(e => e.PesoBruto).HasColumnType("numeric(10, 3)");
                entity.Property(e => e.PesoCubado).HasColumnType("numeric(10, 3)");
                entity.Property(e => e.PesoLiquido).HasColumnType("numeric(10, 3)");
                entity.Property(e => e.ValorNota).HasColumnType("numeric(18, 2)");
                entity.Property(e => e.Volumes).HasColumnType("numeric(10, 0)");

                entity.HasOne(d => d.IdNavigation).WithOne(p => p.DocumentoTotal)
                    .HasForeignKey<DocumentoTotal>(d => d.Id)
                    .HasConstraintName("FK_DocumentoTotal_Id_Documento");
            });

            modelBuilder.Entity<DocumentoTransportador>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PK_DocumentoPadraoTransportador");

                entity.ToTable("DocumentoTransportador");

                entity.Property(e => e.Id).ValueGeneratedNever();
                entity.Property(e => e.Cnpj)
                    .HasMaxLength(20)
                    .IsUnicode(false);
                entity.Property(e => e.InscricaoEstadual)
                    .HasMaxLength(14)
                    .IsUnicode(false);
                entity.Property(e => e.Municipio)
                    .HasMaxLength(60)
                    .IsUnicode(false);
                entity.Property(e => e.Nome)
                    .HasMaxLength(60)
                    .IsUnicode(false);
                entity.Property(e => e.Uf)
                    .HasMaxLength(2)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdNavigation).WithOne(p => p.DocumentoTransportador)
                    .HasForeignKey<DocumentoTransportador>(d => d.Id)
                    .HasConstraintName("FK_DocumentoPadraoTransportador_Id_Documento");
            });

            modelBuilder.Entity<DocumentoVolume>(entity =>
            {
                entity.ToTable("DocumentoVolume");

                entity.Property(e => e.Id).ValueGeneratedNever();
                entity.Property(e => e.VolumeChave)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.Documento).WithMany(p => p.DocumentoVolumes)
                    .HasForeignKey(d => d.DocumentoId)
                    .HasConstraintName("FK_DocumentoVolume_DocumentoId_Documento");
            });

            modelBuilder.Entity<DocumentoVolume1>(entity =>
            {
                entity.ToTable("DocumentoVolume", "tnt");

                entity.HasIndex(e => new { e.DocumentoId, e.VolumeChave }, "UC_DocumentoVolume_DocumentoId_VolumeChave").IsUnique();

                entity.Property(e => e.Id).ValueGeneratedNever();
                entity.Property(e => e.VolumeChave)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.Documento).WithMany(p => p.DocumentoVolume1s)
                    .HasForeignKey(d => d.DocumentoId)
                    .HasConstraintName("FK_DocumentoVolume_DocumentoId_Documento");
            });

            modelBuilder.Entity<Dt>(entity =>
            {
                entity.ToTable("Dt", "tnt");

                entity.Property(e => e.Id).ValueGeneratedNever();
                entity.Property(e => e.DataCadastro)
                    .HasDefaultValueSql("(getdate())")
                    .HasColumnType("datetime");
                entity.Property(e => e.DataEmissao).HasColumnType("datetime");

                entity.HasOne(d => d.DtStatus).WithMany(p => p.Dts)
                    .HasForeignKey(d => d.DtStatusId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Dt_DtStatusId_DtStatus");

                entity.HasOne(d => d.Filial).WithMany(p => p.Dts)
                    .HasForeignKey(d => d.FilialId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Dt_FilialId_Filial");

                entity.HasOne(d => d.Tenant).WithMany(p => p.Dts)
                    .HasForeignKey(d => d.TenantId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Dt_TenantId_Tenant");
            });

            modelBuilder.Entity<DtMdfe>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PK_DtMdfe");

                entity.ToTable("DtMDFe", "tnt");

                entity.Property(e => e.Id).ValueGeneratedNever();
                entity.Property(e => e.CepFinalTransporte)
                    .HasMaxLength(8)
                    .IsUnicode(false);
                entity.Property(e => e.CepInicioTransporte)
                    .HasMaxLength(8)
                    .IsUnicode(false);
                entity.Property(e => e.DataCadastro).HasColumnType("datetime");
                entity.Property(e => e.Distancia).HasColumnType("numeric(10, 2)");
                entity.Property(e => e.Modelo)
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.HasOne(d => d.Dt).WithMany(p => p.DtMdves)
                    .HasForeignKey(d => d.DtId)
                    .HasConstraintName("FK_DtMdfe_DtId_Dt");

                entity.HasOne(d => d.Modal).WithMany(p => p.DtMdves)
                    .HasForeignKey(d => d.ModalId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_DtMdfe_ModalId_Modal");
            });

            modelBuilder.Entity<DtMdfeDtRomaneio>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PK_DtMdfeRomaneio");

                entity.ToTable("DtMDFeDtRomaneio", "tnt");

                entity.HasIndex(e => new { e.DtMdfeId, e.DtRomaneioId }, "UC_DtMDFeDtRomaneio_DtMDFeId_DtRomaneioId").IsUnique();

                entity.Property(e => e.Id).ValueGeneratedNever();
                entity.Property(e => e.DtMdfeId).HasColumnName("DtMDFeId");

                entity.HasOne(d => d.DtMdfe).WithMany(p => p.DtMdfeDtRomaneios)
                    .HasForeignKey(d => d.DtMdfeId)
                    .HasConstraintName("FK_DtMDFeDtRomaneio_DtMDFeId_DtMdfe");

                entity.HasOne(d => d.DtRomaneio).WithMany(p => p.DtMdfeDtRomaneios)
                    .HasForeignKey(d => d.DtRomaneioId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_DtMDFeDtRomaneio_DtRomaneioId_DtRomaneio");
            });

            modelBuilder.Entity<DtRomaneioCarga>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PK_DtRomaneio");

                entity.ToTable("DtRomaneioCarga", "tnt");

                entity.HasIndex(e => new { e.DtId, e.RomaneioCargaId }, "UC_DtRomaneio_DtId_RomaneioId").IsUnique();

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.HasOne(d => d.Dt).WithMany(p => p.DtRomaneioCargas)
                    .HasForeignKey(d => d.DtId)
                    .HasConstraintName("FK_DtRomaneio_DtId_Dt");

                entity.HasOne(d => d.RomaneioCarga).WithMany(p => p.DtRomaneioCargas)
                    .HasForeignKey(d => d.RomaneioCargaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_DtRomaneio_RomaneioCargaId_Romaneio");
            });

            modelBuilder.Entity<DtStatus>(entity =>
            {
                entity.ToTable("DtStatus");

                entity.Property(e => e.Id).ValueGeneratedNever();
                entity.Property(e => e.Descricao)
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Empresa>(entity =>
            {
                entity.ToTable("Empresa", "tnt");

                entity.Property(e => e.Nome)
                    .HasMaxLength(80)
                    .IsUnicode(false);

                entity.HasOne(d => d.Tenant).WithMany(p => p.Empresas)
                    .HasForeignKey(d => d.TenantId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Empresa_TenantId_Tenant");
            });

            modelBuilder.Entity<Endereco>(entity =>
            {
                entity.ToTable("Endereco");

                entity.Property(e => e.Id).ValueGeneratedNever();
                entity.Property(e => e.Cep)
                    .HasMaxLength(8)
                    .IsUnicode(false);
                entity.Property(e => e.CodigoIbge)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasColumnName("CodigoIBGE");
                entity.Property(e => e.Complemento)
                    .HasMaxLength(100)
                    .IsUnicode(false);
                entity.Property(e => e.DataCadastro)
                    .HasDefaultValueSql("(getdate())")
                    .HasColumnType("datetime");
                entity.Property(e => e.EnderecoDocumento)
                    .HasMaxLength(100)
                    .IsUnicode(false);
                entity.Property(e => e.Logradouro)
                    .HasMaxLength(100)
                    .IsUnicode(false);
                entity.Property(e => e.NomeBairro)
                    .HasMaxLength(60)
                    .IsUnicode(false);
                entity.Property(e => e.NomeMunicipio)
                    .HasMaxLength(60)
                    .IsUnicode(false);
                entity.Property(e => e.Numero)
                    .HasMaxLength(20)
                    .IsUnicode(false);
                entity.Property(e => e.Referencia)
                    .HasMaxLength(100)
                    .IsUnicode(false);
                entity.Property(e => e.Tipo)
                    .HasMaxLength(50)
                    .IsUnicode(false);
                entity.Property(e => e.Uf)
                    .HasMaxLength(2)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<EnderecoTipo>(entity =>
            {
                entity.ToTable("EnderecoTipo");

                entity.Property(e => e.Id).ValueGeneratedNever();
                entity.Property(e => e.Descricao)
                    .HasMaxLength(60)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Estado>(entity =>
            {
                entity.ToTable("Estado");

                entity.Property(e => e.Id).ValueGeneratedNever();
                entity.Property(e => e.CepFinal)
                    .HasMaxLength(8)
                    .IsUnicode(false);
                entity.Property(e => e.CepInicial)
                    .HasMaxLength(8)
                    .IsUnicode(false);
                entity.Property(e => e.Nome)
                    .HasMaxLength(60)
                    .IsUnicode(false);
                entity.Property(e => e.Uf)
                    .HasMaxLength(2)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdPaisNavigation).WithMany(p => p.Estados)
                    .HasForeignKey(d => d.IdPais)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Estado_IdPais_Pais");
            });

            modelBuilder.Entity<Filial>(entity =>
            {
                entity.ToTable("Filial", "tnt");

                entity.Property(e => e.DataCadastro)
                    .HasDefaultValueSql("(getdate())")
                    .HasColumnType("datetime");
                entity.Property(e => e.SenhaCertificado)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.HasOne(d => d.Empresa).WithMany(p => p.Filials)
                    .HasForeignKey(d => d.EmpresaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Filial_EmpresaId_Empresa");

                entity.HasOne(d => d.FilialPai).WithMany(p => p.InverseFilialPai)
                    .HasForeignKey(d => d.FilialPaiId)
                    .HasConstraintName("FK_Filial_FilialPaiId_Filial");
            });

            modelBuilder.Entity<FilialLastMile>(entity =>
            {
                entity.ToTable("FilialLastMile", "tnt");

                entity.Property(e => e.Id).ValueGeneratedNever();
                entity.Property(e => e.CepFinal)
                    .HasMaxLength(8)
                    .IsUnicode(false);
                entity.Property(e => e.CepInicial)
                    .HasMaxLength(8)
                    .IsUnicode(false);
                entity.Property(e => e.DataCadastro)
                    .HasDefaultValueSql("(getdate())")
                    .HasColumnType("datetime");

                entity.HasOne(d => d.Bairro).WithMany(p => p.FilialLastMiles)
                    .HasForeignKey(d => d.BairroId)
                    .HasConstraintName("FK_FilialRegiao_BairroId_Bairro");

                entity.HasOne(d => d.Estado).WithMany(p => p.FilialLastMiles)
                    .HasForeignKey(d => d.EstadoId)
                    .HasConstraintName("FK_FilialLastMile_EstadoId_Estado");

                entity.HasOne(d => d.Filial).WithMany(p => p.FilialLastMiles)
                    .HasForeignKey(d => d.FilialId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_FilialLastMile_FilialId_Filial");
            });

            modelBuilder.Entity<FilialLastMileGrupo>(entity =>
            {
                entity.ToTable("FilialLastMileGrupo", "tnt");

                entity.Property(e => e.Id).ValueGeneratedNever();
                entity.Property(e => e.Codigo)
                    .HasMaxLength(60)
                    .IsUnicode(false);
                entity.Property(e => e.Nome)
                    .HasMaxLength(60)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<FilialLastMileGrupoItem>(entity =>
            {
                entity.ToTable("FilialLastMileGrupoItem", "tnt");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.HasOne(d => d.FilialLastMileGrupo).WithMany(p => p.FilialLastMileGrupoItems)
                    .HasForeignKey(d => d.FilialLastMileGrupoId)
                    .HasConstraintName("FK_FilialLastMileGrupoItem_FilialLastMileGrupoItem_FilialLastMileGrupo");

                entity.HasOne(d => d.FilialLastMile).WithMany(p => p.FilialLastMileGrupoItems)
                    .HasForeignKey(d => d.FilialLastMileId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_FilialLastMileGrupoItem_FilialLastMileId_FilialLastMile");
            });

            modelBuilder.Entity<LogProcessamento>(entity =>
            {
                entity.ToTable("LogProcessamento");

                entity.Property(e => e.Id).ValueGeneratedNever();
                entity.Property(e => e.DataCadastro).HasColumnType("datetime");
                entity.Property(e => e.Final).HasColumnType("datetime");
                entity.Property(e => e.Inicio).HasColumnType("datetime");
                entity.Property(e => e.Tarefa)
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<LoteEletronico>(entity =>
            {
                entity.ToTable("LoteEletronico", "tnt");

                entity.HasIndex(e => new { e.TenantId, e.FilialId }, "IX_LoteEletronico_TenantId_FilialId");

                entity.Property(e => e.Id).ValueGeneratedNever();
                entity.Property(e => e.CteStatusSefazId).HasColumnName("CTeStatusSefazId");
                entity.Property(e => e.DataCadastro).HasColumnType("datetime");
                entity.Property(e => e.EnvioData).HasColumnType("datetime");
                entity.Property(e => e.Recibo)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.HasOne(d => d.CteStatusSefaz).WithMany(p => p.LoteEletronicos)
                    .HasForeignKey(d => d.CteStatusSefazId)
                    .HasConstraintName("FK_LoteEletronico_CTeStatusSefazId_CTeStatusSefaz");

                entity.HasOne(d => d.Filial).WithMany(p => p.LoteEletronicos)
                    .HasForeignKey(d => d.FilialId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_LoteEletronico_FilialId_Filial");

                entity.HasOne(d => d.Tenant).WithMany(p => p.LoteEletronicos)
                    .HasForeignKey(d => d.TenantId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_LoteEletronico_TenantId_Tenant");
            });

            modelBuilder.Entity<MenuItem>(entity =>
            {
                entity.ToTable("MenuItem");

                entity.Property(e => e.Id).ValueGeneratedNever();
                entity.Property(e => e.CssClass).HasMaxLength(100);
                entity.Property(e => e.FullPath).HasMaxLength(4000);
                entity.Property(e => e.GroupName).HasMaxLength(100);
                entity.Property(e => e.MenuText).HasMaxLength(100);
                entity.Property(e => e.Url).HasMaxLength(100);

                entity.HasOne(d => d.AspNetRoleClaims).WithMany(p => p.MenuItems).HasForeignKey(d => d.AspNetRoleClaimsId);

                entity.HasOne(d => d.MenuItemParent).WithMany(p => p.InverseMenuItemParent).HasForeignKey(d => d.MenuItemParentId);
            });

            modelBuilder.Entity<Modal>(entity =>
            {
                entity.ToTable("Modal");

                entity.Property(e => e.Id).ValueGeneratedNever();
                entity.Property(e => e.Descricao)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Motoristum>(entity =>
            {
                entity.ToTable("Motorista", "tnt");

                entity.HasIndex(e => new { e.TenantId, e.PessoaId }, "UC_Motorista_TenantId_PessoaId").IsUnique();

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.HasOne(d => d.Pessoa).WithMany(p => p.Motorista)
                    .HasForeignKey(d => d.PessoaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Motorista_PessoaId_Pessoa");

                entity.HasOne(d => d.Tenant).WithMany(p => p.Motorista)
                    .HasForeignKey(d => d.TenantId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Motorista_TenantId_Tenant");
            });

            modelBuilder.Entity<Municipio>(entity =>
            {
                entity.ToTable("Municipio");

                entity.HasIndex(e => new { e.CodigoIbge, e.Nome }, "IX_MunicipioCodigoIBGENome");

                entity.HasIndex(e => new { e.Uf, e.Nome }, "IX_MunicipioUF_Nome");

                entity.Property(e => e.Id).ValueGeneratedNever();
                entity.Property(e => e.CepMax)
                    .HasMaxLength(8)
                    .IsUnicode(false);
                entity.Property(e => e.CepMin)
                    .HasMaxLength(8)
                    .IsUnicode(false);
                entity.Property(e => e.Chave)
                    .HasMaxLength(8)
                    .IsUnicode(false);
                entity.Property(e => e.CidadeAcento)
                    .HasMaxLength(80)
                    .IsUnicode(false);
                entity.Property(e => e.CodigoIbge)
                    .HasMaxLength(7)
                    .IsUnicode(false)
                    .HasColumnName("CodigoIBGE");
                entity.Property(e => e.Ddd)
                    .HasMaxLength(3)
                    .IsUnicode(false);
                entity.Property(e => e.Latitude)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("latitude");
                entity.Property(e => e.Longitude)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("longitude");
                entity.Property(e => e.Nome)
                    .HasMaxLength(80)
                    .IsUnicode(false);
                entity.Property(e => e.TipoCidade)
                    .HasMaxLength(1)
                    .IsUnicode(false);
                entity.Property(e => e.Uf)
                    .HasMaxLength(2)
                    .IsUnicode(false);

                entity.HasOne(d => d.MunicipioPai).WithMany(p => p.InverseMunicipioPai)
                    .HasForeignKey(d => d.MunicipioPaiId)
                    .HasConstraintName("FK_Municipio_MunicipioPaiId_Municipio");
            });

            modelBuilder.Entity<Pai>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();
                entity.Property(e => e.Nome)
                    .HasMaxLength(60)
                    .IsUnicode(false);
                entity.Property(e => e.Sigla)
                    .HasMaxLength(3)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Pessoa>(entity =>
            {
                entity.ToTable("Pessoa");

                entity.Property(e => e.Id).ValueGeneratedNever();
                entity.Property(e => e.DataCadastro)
                    .HasDefaultValueSql("(getdate())")
                    .HasColumnType("datetime");
                entity.Property(e => e.Nome)
                    .HasMaxLength(80)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<PessoaEndereco>(entity =>
            {
                entity.ToTable("PessoaEndereco");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.HasOne(d => d.Endereco).WithMany(p => p.PessoaEnderecos)
                    .HasForeignKey(d => d.EnderecoId)
                    .HasConstraintName("FK_PessoaEndereco_EnderecoId_Endereco");

                entity.HasOne(d => d.EnderecoTipo).WithMany(p => p.PessoaEnderecos)
                    .HasForeignKey(d => d.EnderecoTipoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PessoaEndereco_EnderecoTipo");

                entity.HasOne(d => d.Pessoa).WithMany(p => p.PessoaEnderecos)
                    .HasForeignKey(d => d.PessoaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PessoaEndereco_PessoaId_Pessoa");
            });

            modelBuilder.Entity<PessoaFisica>(entity =>
            {
                entity.ToTable("PessoaFisica");

                entity.Property(e => e.Id).ValueGeneratedNever();
                entity.Property(e => e.Cpf)
                    .HasMaxLength(14)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdNavigation).WithOne(p => p.PessoaFisica)
                    .HasForeignKey<PessoaFisica>(d => d.Id)
                    .HasConstraintName("FK_PessoaFisica_Id_Pessoa");
            });

            modelBuilder.Entity<PessoaFisicaComplemento>(entity =>
            {
                entity.ToTable("PessoaFisicaComplemento");

                entity.Property(e => e.Id).ValueGeneratedNever();
                entity.Property(e => e.Cnh)
                    .HasMaxLength(60)
                    .IsUnicode(false);
                entity.Property(e => e.CnhCategoria)
                    .HasMaxLength(20)
                    .IsUnicode(false);
                entity.Property(e => e.CnhEmissao).HasColumnType("date");
                entity.Property(e => e.CnhPrimeiraHabilitacao).HasColumnType("date");
                entity.Property(e => e.CnhValidade).HasColumnType("date");
                entity.Property(e => e.Nacionalidade)
                    .HasMaxLength(50)
                    .IsUnicode(false);
                entity.Property(e => e.NascimentoData).HasColumnType("date");
                entity.Property(e => e.NascimentoMunicipio)
                    .HasMaxLength(60)
                    .IsUnicode(false);
                entity.Property(e => e.NascimentoUf)
                    .HasMaxLength(2)
                    .IsUnicode(false);
                entity.Property(e => e.NomeMae)
                    .HasMaxLength(60)
                    .IsUnicode(false);
                entity.Property(e => e.NomePai)
                    .HasMaxLength(60)
                    .IsUnicode(false);
                entity.Property(e => e.Rg)
                    .HasMaxLength(50)
                    .IsUnicode(false);
                entity.Property(e => e.RgEmissaoData).HasColumnType("date");
                entity.Property(e => e.RgEmissaoMunicipio)
                    .HasMaxLength(60)
                    .IsUnicode(false);
                entity.Property(e => e.RgEmissaoUf)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasColumnName("RgEmissaoUF");

                entity.HasOne(d => d.IdNavigation).WithOne(p => p.PessoaFisicaComplemento)
                    .HasForeignKey<PessoaFisicaComplemento>(d => d.Id)
                    .HasConstraintName("FK_PessoaFisicaComplemento_PessoaFisica");
            });

            modelBuilder.Entity<PessoaFuncao>(entity =>
            {
                entity.ToTable("PessoaFuncao");

                entity.Property(e => e.Id).ValueGeneratedNever();
                entity.Property(e => e.Descricao)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<PessoaJuridica>(entity =>
            {
                entity.ToTable("PessoaJuridica");

                entity.Property(e => e.Id).ValueGeneratedNever();
                entity.Property(e => e.Cnpj)
                    .HasMaxLength(18)
                    .IsUnicode(false);
                entity.Property(e => e.Fantasia)
                    .HasMaxLength(80)
                    .IsUnicode(false);
                entity.Property(e => e.InscricaoEstadual)
                    .HasMaxLength(14)
                    .IsUnicode(false);
                entity.Property(e => e.InscricaoMunicipal)
                    .HasMaxLength(14)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdNavigation).WithOne(p => p.PessoaJuridica)
                    .HasForeignKey<PessoaJuridica>(d => d.Id)
                    .HasConstraintName("FK_PessoaJuridica_Id_Pessoa");
            });

            modelBuilder.Entity<PessoaJuridicaComplemento>(entity =>
            {
                entity.ToTable("PessoaJuridicaComplemento");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.HasOne(d => d.IdNavigation).WithOne(p => p.PessoaJuridicaComplemento)
                    .HasForeignKey<PessoaJuridicaComplemento>(d => d.Id)
                    .HasConstraintName("FK_PessoaJuridicaComplemento_PessoaJuridica");
            });

            modelBuilder.Entity<PessoaOutro>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();
                entity.Property(e => e.Codigo)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdNavigation).WithOne(p => p.PessoaOutro)
                    .HasForeignKey<PessoaOutro>(d => d.Id)
                    .HasConstraintName("FK_PessoaOutros_Id_Pessoa");
            });

            modelBuilder.Entity<PessoaTipoContato>(entity =>
            {
                entity.ToTable("PessoaTipoContato");

                entity.Property(e => e.Id).ValueGeneratedNever();
                entity.Property(e => e.Descricao)
                    .HasMaxLength(60)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<PessoaTipoContatoItem>(entity =>
            {
                entity.ToTable("PessoaTipoContatoItem");

                entity.Property(e => e.Id).ValueGeneratedNever();
                entity.Property(e => e.Valor)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.PessoaTipoContato).WithMany(p => p.PessoaTipoContatoItems)
                    .HasForeignKey(d => d.PessoaTipoContatoId)
                    .HasConstraintName("FK_PessoaTipoContatoItem_PessoaTipoContato");
            });

            modelBuilder.Entity<Produto>(entity =>
            {
                entity.ToTable("Produto");

                entity.HasIndex(e => new { e.PessoaId, e.Descricao }, "IX_Produto_PessoaId_Descricao");

                entity.HasIndex(e => new { e.PessoaId, e.Codigo }, "UC_Produto_PessoaId_Codigo").IsUnique();

                entity.Property(e => e.Id).ValueGeneratedNever();
                entity.Property(e => e.Codigo)
                    .HasMaxLength(30)
                    .IsUnicode(false);
                entity.Property(e => e.DataCadastro)
                    .HasDefaultValueSql("(getdate())")
                    .HasColumnType("datetime");
                entity.Property(e => e.Descricao)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.HasOne(d => d.Pessoa).WithMany(p => p.Produtos)
                    .HasForeignKey(d => d.PessoaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Produto_PessoaId_Pessoa");
            });

            modelBuilder.Entity<Romaneio>(entity =>
            {
                entity.ToTable("Romaneio", "tnt");

                entity.Property(e => e.Id).ValueGeneratedNever();
                entity.Property(e => e.DataCadastro)
                    .HasDefaultValueSql("(getdate())")
                    .HasColumnType("datetime");
                entity.Property(e => e.DataEmissao).HasColumnType("datetime");

                entity.HasOne(d => d.Tenant).WithMany(p => p.Romaneios)
                    .HasForeignKey(d => d.TenantId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Romaneio_TenantId_Tenant");
            });

            modelBuilder.Entity<RomaneioCarga>(entity =>
            {
                entity.ToTable("RomaneioCarga", "tnt");

                entity.Property(e => e.Id).ValueGeneratedNever();
                entity.Property(e => e.DitanciaKm).HasColumnType("numeric(18, 3)");
                entity.Property(e => e.MetragemCubica).HasColumnType("numeric(18, 3)");
                entity.Property(e => e.PesoBruto).HasColumnType("numeric(18, 3)");

                entity.HasOne(d => d.IdNavigation).WithOne(p => p.RomaneioCarga)
                    .HasForeignKey<RomaneioCarga>(d => d.Id)
                    .HasConstraintName("FK_RomaneioCarga_Id_Romaneio");

                entity.HasOne(d => d.Veiculo).WithMany(p => p.RomaneioCargas)
                    .HasForeignKey(d => d.VeiculoId)
                    .HasConstraintName("FK_RomaneioCarga_VeiculoId_Veiculo");

                entity.HasOne(d => d.VeiculoTipo).WithMany(p => p.RomaneioCargas)
                    .HasForeignKey(d => d.VeiculoTipoId)
                    .HasConstraintName("FK_RomaneioCarga_VeiculoTipoId_VeiculoTipo");
            });

            modelBuilder.Entity<RomaneioChave>(entity =>
            {
                entity.ToTable("RomaneioChave", "tnt");

                entity.Property(e => e.Id).ValueGeneratedNever();
                entity.Property(e => e.Chave)
                    .HasMaxLength(44)
                    .IsUnicode(false);
                entity.Property(e => e.DataCadastro).HasColumnType("datetime");

                entity.HasOne(d => d.Romaneio).WithMany(p => p.RomaneioChaves)
                    .HasForeignKey(d => d.RomaneioId)
                    .HasConstraintName("FK_RomaneioChave_Romaneio");
            });

            modelBuilder.Entity<RomaneioDocumento>(entity =>
            {
                entity.ToTable("RomaneioDocumento", "tnt");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.HasOne(d => d.IdNavigation).WithOne(p => p.RomaneioDocumento)
                    .HasForeignKey<RomaneioDocumento>(d => d.Id)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_RomaneioDocumento_Id_Documento");

                entity.HasOne(d => d.Romaneio).WithMany(p => p.RomaneioDocumentos)
                    .HasForeignKey(d => d.RomaneioId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_RomaneioDocumento_Id_Romaneio");
            });

            modelBuilder.Entity<Segmento>(entity =>
            {
                entity.ToTable("Segmento", "tnt");

                entity.Property(e => e.Descricao)
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Tenant>(entity =>
            {
                entity.ToTable("Tenant");

                entity.Property(e => e.Id).ValueGeneratedNever();
                entity.Property(e => e.DataCadastro)
                    .HasDefaultValueSql("(getdate())")
                    .HasColumnType("datetime");
                entity.Property(e => e.Decricao).HasColumnType("text");
                entity.Property(e => e.Nome)
                    .HasMaxLength(80)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TipoContum>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();
                entity.Property(e => e.Nome)
                    .HasMaxLength(60)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TipoCte>(entity =>
            {
                entity.ToTable("TipoCTe");

                entity.Property(e => e.Id).ValueGeneratedNever();
                entity.Property(e => e.Descricao)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TipoDocumento>(entity =>
            {
                entity.ToTable("TipoDocumento");

                entity.Property(e => e.Id).ValueGeneratedNever();
                entity.Property(e => e.Nome)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TipoRntrc>(entity =>
            {
                entity.ToTable("TipoRntrc");

                entity.Property(e => e.Id).ValueGeneratedNever();
                entity.Property(e => e.Codigo)
                    .HasMaxLength(5)
                    .IsUnicode(false);
                entity.Property(e => e.Descricao)
                    .HasMaxLength(200)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TipoServicoPrestado>(entity =>
            {
                entity.ToTable("TipoServicoPrestado");

                entity.Property(e => e.Id).ValueGeneratedNever();
                entity.Property(e => e.Descricao)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Transportador>(entity =>
            {
                entity.ToTable("Transportador");

                entity.Property(e => e.Id).ValueGeneratedNever();
                entity.Property(e => e.DataCadastro).HasColumnType("datetime");
                entity.Property(e => e.DataVerificacao).HasColumnType("datetime");
                entity.Property(e => e.Rntrc)
                    .HasMaxLength(10)
                    .IsUnicode(false);
                entity.Property(e => e.RntrcValidade).HasColumnType("date");

                entity.HasOne(d => d.IdNavigation).WithOne(p => p.Transportador)
                    .HasForeignKey<Transportador>(d => d.Id)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Transportador_Id_Pessoa");

                entity.HasOne(d => d.TipoRntrc).WithMany(p => p.Transportadors)
                    .HasForeignKey(d => d.TipoRntrcId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Transportador_TipoRntrcId_TipoRntrc");
            });

            modelBuilder.Entity<Transportador1>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PK_Transportador_1");

                entity.ToTable("Transportador", "tnt");

                entity.Property(e => e.Id).ValueGeneratedNever();
                entity.Property(e => e.Agencia)
                    .HasMaxLength(10)
                    .IsUnicode(false);
                entity.Property(e => e.AgencidaDigito)
                    .HasMaxLength(2)
                    .IsUnicode(false);
                entity.Property(e => e.Banco)
                    .HasMaxLength(3)
                    .IsUnicode(false);
                entity.Property(e => e.ChavePix)
                    .HasMaxLength(100)
                    .IsUnicode(false);
                entity.Property(e => e.CnpjCpfFavorecido)
                    .HasMaxLength(18)
                    .IsUnicode(false);
                entity.Property(e => e.Conta)
                    .HasMaxLength(10)
                    .IsUnicode(false);
                entity.Property(e => e.ContaDigito)
                    .HasMaxLength(2)
                    .IsUnicode(false);
                entity.Property(e => e.NomeFavorecido)
                    .HasMaxLength(60)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdNavigation).WithOne(p => p.Transportador1)
                    .HasForeignKey<Transportador1>(d => d.Id)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Transportador_TitularId_Pessoa");

                entity.HasOne(d => d.Tenant).WithMany(p => p.Transportador1s)
                    .HasForeignKey(d => d.TenantId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Transportador_TenantId_Tenant");

                entity.HasOne(d => d.TipoConta).WithMany(p => p.Transportador1s)
                    .HasForeignKey(d => d.TipoContaId)
                    .HasConstraintName("FK_Transportador_TipoContaId_TipoConta");

                entity.HasOne(d => d.Transportador).WithMany(p => p.Transportador1s)
                    .HasForeignKey(d => d.TransportadorId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Transportador_TransportadorId_Transportador");
            });

            modelBuilder.Entity<TransportadorLastMile>(entity =>
            {
                entity.ToTable("TransportadorLastMile", "tnt");

                entity.Property(e => e.Id).ValueGeneratedNever();
                entity.Property(e => e.CepFinal)
                    .HasMaxLength(8)
                    .IsUnicode(false);
                entity.Property(e => e.CepInicial)
                    .HasMaxLength(8)
                    .IsUnicode(false);
                entity.Property(e => e.DataCadastro)
                    .HasDefaultValueSql("(getdate())")
                    .HasColumnType("datetime");

                entity.HasOne(d => d.Estado).WithMany(p => p.TransportadorLastMiles)
                    .HasForeignKey(d => d.EstadoId)
                    .HasConstraintName("FK_TransportadorLastMile_EstadoId_Estado");
            });

            modelBuilder.Entity<TransportadorLastMileGrupo>(entity =>
            {
                entity.ToTable("TransportadorLastMileGrupo", "tnt");

                entity.Property(e => e.Id).ValueGeneratedNever();
                entity.Property(e => e.Codigo)
                    .HasMaxLength(60)
                    .IsUnicode(false);
                entity.Property(e => e.Nome)
                    .HasMaxLength(60)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TransportadorLastMileGrupoItem>(entity =>
            {
                entity.ToTable("TransportadorLastMileGrupoItem", "tnt");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.HasOne(d => d.TransportadorLastMileGrupo).WithMany(p => p.TransportadorLastMileGrupoItems)
                    .HasForeignKey(d => d.TransportadorLastMileGrupoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TransportadorLastMileGrupoItem_TransportadorLastMileGrupoItem_TransportadorLastMileGrupo");

                entity.HasOne(d => d.TransportadorLastMile).WithMany(p => p.TransportadorLastMileGrupoItems)
                    .HasForeignKey(d => d.TransportadorLastMileId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TransportadorLastMileGrupoItem_TransportadorLastMileId_TransportadorLastMile");
            });

            modelBuilder.Entity<Veiculo>(entity =>
            {
                entity.ToTable("Veiculo");

                entity.Property(e => e.Id).ValueGeneratedNever();
                entity.Property(e => e.CapacidadeM3).HasColumnType("numeric(10, 0)");
                entity.Property(e => e.CapacidadePeso).HasColumnType("numeric(10, 0)");
                entity.Property(e => e.Chassi)
                    .HasMaxLength(50)
                    .IsUnicode(false);
                entity.Property(e => e.Combustivel)
                    .HasMaxLength(50)
                    .IsUnicode(false);
                entity.Property(e => e.Cor)
                    .HasMaxLength(50)
                    .IsUnicode(false);
                entity.Property(e => e.DataCadastro)
                    .HasDefaultValueSql("(getdate())")
                    .HasColumnType("datetime");
                entity.Property(e => e.MarcaModelo)
                    .HasMaxLength(50)
                    .IsUnicode(false);
                entity.Property(e => e.NumeroCrv)
                    .HasMaxLength(50)
                    .IsUnicode(false);
                entity.Property(e => e.Placa)
                    .HasMaxLength(8)
                    .IsUnicode(false);
                entity.Property(e => e.Renavan)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.Proprietario).WithMany(p => p.Veiculos)
                    .HasForeignKey(d => d.ProprietarioId)
                    .HasConstraintName("FK_Veiculo_ProprietarioId_Pessoa");

                entity.HasOne(d => d.VieculoTipo).WithMany(p => p.Veiculos)
                    .HasForeignKey(d => d.VieculoTipoId)
                    .HasConstraintName("FK_Veiculo_VeiculoTipoId_VeiculoTipo");
            });

            modelBuilder.Entity<Veiculo1>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PK_Veiculo_1");

                entity.ToTable("Veiculo", "tnt");

                entity.Property(e => e.Id).ValueGeneratedNever();
                entity.Property(e => e.DataCadastro)
                    .HasDefaultValueSql("(getdate())")
                    .HasColumnType("datetime");

                entity.HasOne(d => d.Motorista).WithMany(p => p.Veiculo1s)
                    .HasForeignKey(d => d.MotoristaId)
                    .HasConstraintName("FK_Veiculo_MotoristaId_Motorista");

                entity.HasOne(d => d.Tenant).WithMany(p => p.Veiculo1s)
                    .HasForeignKey(d => d.TenantId)
                    .HasConstraintName("FK_Veiculo_TenantId_Tenant");

                entity.HasOne(d => d.Veiculo).WithMany(p => p.Veiculo1s)
                    .HasForeignKey(d => d.VeiculoId)
                    .HasConstraintName("FK_Veiculo_VeiculoId_Veiculo");
            });

            modelBuilder.Entity<VeiculoTipo>(entity =>
            {
                entity.ToTable("VeiculoTipo");

                entity.Property(e => e.Nome)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            base.OnModelCreating(modelBuilder);
        }


    }
}
