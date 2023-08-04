using Entities.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Entities.Models;
using System.Reflection.Metadata;
using System.Reflection.Emit;
using Infra.Mappings;

/*
 Oficial

Manage Nuget Package
Microsoft.EntityframeCore
Microsoft.EntityFrameworkCore.Design
Microsoft.EntityFrameworkCore.Tools
Microsoft.EntityFrameworkCore.SqlServer

Migrations
Add-Migration Inicial -Context BancoContext
update-Database -Context DataContext
Definir o projeto Api como Projeto Inicial
Console PM> preciso estar no Projeto Infra

Scaffold-DataContext "Server=192.168.0.12;Initial Catalog=Prototipo;Persist Security Info=False;User ID=sa;Password=@oncetsis05083#;MultipleActiveResultSets=True;TrustServerCertificate=True" Microsoft.EntityFrameworkCore.SqlServer -OutputDir Models  -Context DataContext

Artigo
--https://learn.microsoft.com/pt-br/ef/core/managing-schemas/scaffolding/templates?tabs=dotnet-core-cli
Adicionar Templates scafold 
dotnet new install Microsoft.EntityFrameworkCore.Templates
dotnet new ef- templates


"email": "admin@gmail.com",
"senha": "@Admin123",
*/


namespace Infra.Configuracao
{
    public class DataContext : IdentityDbContext<ApplicationUser> 
    {
        public DataContext(DbContextOptions options) : base(options)
        {
        }


        #region Dbsets
        public DbSet<SistemaFinanceiro> SistemaFinanceiro { set; get; }
        public DbSet<UsuarioSistemaFinanceiro> UsuarioSistemaFinanceiro { set; get; }
        public DbSet<Categoria> Categoria { set; get; }
        public DbSet<Despesa> Despesa { set; get; }

        public DbSet<Bairro> Bairros { get; set; }

        public  DbSet<CodigoBarra> CodigoBarras { get; set; }

        public  DbSet<Documento> Documentos { get; set; }

        public  DbSet<Documento1> Documentos1 { get; set; }

        public  DbSet<DocumentoFilialGrupo> DocumentoFilialGrupos { get; set; }

        public  DbSet<DocumentoImposto> DocumentoImpostos { get; set; }

        public  DbSet<DocumentoItem> DocumentoItems { get; set; }

        public  DbSet<DocumentoTotal> DocumentoTotals { get; set; }

        public  DbSet<DocumentoTransportador> DocumentoTransportadors { get; set; }

        public  DbSet<Empresa> Empresas { get; set; }

        public  DbSet<Endereco> Enderecos { get; set; }

        public  DbSet<Estado> Estados { get; set; }

        public  DbSet<Filial> Filials { get; set; }

        public  DbSet<FilialLastMile> FilialLastMiles { get; set; }

        public  DbSet<FilialLastMileGrupo> FilialLastMileGrupos { get; set; }

        public  DbSet<FilialLastMileGrupoItem> FilialLastMileGrupoItems { get; set; }

        public  DbSet<Municipio> Municipios { get; set; }

        public  DbSet<Pais> Pais { get; set; }

        public  DbSet<Pessoa> Pessoas { get; set; }

        public  DbSet<PessoaEndereco> PessoaEnderecos { get; set; }

        public  DbSet<PessoaFisica> PessoaFisicas { get; set; }

        public  DbSet<PessoaJuridica> PessoaJuridicas { get; set; }

        public  DbSet<PessoaOutro> PessoaOutros { get; set; }

        public  DbSet<Produto> Produtos { get; set; }

        public  DbSet<Romaneio> Romaneios { get; set; }

        public  DbSet<RomaneioCarga> RomaneioCargas { get; set; }

        public  DbSet<RomaneioDocumento> RomaneioDocumentos { get; set; }

        public DbSet<Supplement> Supplements { get; set; }

        public  DbSet<Tenant> Tenants { get; set; }

        public  DbSet<TipoContum> TipoConta { get; set; }

        public  DbSet<TipoDocumento> TipoDocumentos { get; set; }

        public  DbSet<TipoRntrc> TipoRntrcs { get; set; }

        public  DbSet<Transportador> Transportadors { get; set; }

        public  DbSet<Transportador1> Transportadors1 { get; set; }

        public  DbSet<TransportadorLastMile> TransportadorLastMiles { get; set; }

        public  DbSet<TransportadorLastMileGrupo> TransportadorLastMileGrupos { get; set; }

        public  DbSet<TransportadorLastMileGrupoItem> TransportadorLastMileGrupoItems { get; set; }

        public  DbSet<Veiculo> Veiculos { get; set; }

        public  DbSet<Veiculo1> Veiculos1 { get; set; }

        public  DbSet<VeiculoTipo> VeiculoTipos { get; set; }

        #endregion


    
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            //optionsBuilder.LogTo(Console.WriteLine);

            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(GetOverlapConnection());
                base.OnConfiguring(optionsBuilder);
            }
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<ApplicationUser>().ToTable("AspNetUsers").HasKey(t => t.Id);


            builder.Entity<Supplement>().ToTable("Supplements").HasKey(t => t.Id);

            builder.Entity<Bairro>(entity =>
            {
                entity.ToTable("Bairro");

                entity.Property(e => e.Id).ValueGeneratedNever();
                entity.Property(e => e.Nome)
                    .HasMaxLength(60)
                    .IsUnicode(false);

                entity.HasOne(d => d.Municipio).WithMany(p => p.Bairros)
                    .HasForeignKey(d => d.MunicipioId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Bairro_MunicipioId_Municipio");
            });

            builder.Entity<CodigoBarra>(entity =>
            {
                entity.ToTable("CodigoBarra");

                entity.HasIndex(e => e.CodigoBarras, "UC_CodigoBarra").IsUnique();

                entity.Property(e => e.Id).ValueGeneratedNever();
                entity.Property(e => e.Altura).HasColumnType("numeric(10, 3)");
                entity.Property(e => e.CodigoBarras)
                    .HasMaxLength(20)
                    .IsUnicode(false);
                entity.Property(e => e.Comprimento).HasColumnType("numeric(10, 0)");
                entity.Property(e => e.Largura).HasColumnType("numeric(10, 3)");
            });

            builder.Entity<Documento>(entity =>
            {
                entity.ToTable("Documento");

                entity.HasIndex(e => e.Chave, "UC_DocumentoChave").IsUnique();

                entity.HasIndex(e => new { e.EmitenteId, e.TipoDocumentoId, e.Numero, e.Serie, e.NumeroCliente }, "UC_Documento_IdEmitente_IdTipoDocumento_Numero_Serie_NumeroCliente").IsUnique();

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

            builder.Entity<Documento1>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PK_Documento_Id");

                entity.ToTable("Documento", "tnt");

                entity.Property(e => e.Id).ValueGeneratedNever();
                entity.Property(e => e.Ativo)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");
                entity.Property(e => e.DataEntrada).HasColumnType("datetime");

                entity.HasOne(d => d.Documento).WithMany(p => p.Documento1s)
                    .HasForeignKey(d => d.DocumentoId)
                    .HasConstraintName("FK_Documento_DocumentoId_Documento");

                entity.HasOne(d => d.Tenant).WithMany(p => p.Documento1s)
                    .HasForeignKey(d => d.TenantId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Documento_TenantId_Tenant");
            });

            builder.Entity<DocumentoFilialGrupo>(entity =>
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

            builder.Entity<DocumentoImposto>(entity =>
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

            builder.Entity<DocumentoItem>(entity =>
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
                entity.Property(e => e.QCom).HasColumnName("qCom");
                entity.Property(e => e.QTrib)
                    .HasColumnType("numeric(18, 2)")
                    .HasColumnName("qTrib");
                entity.Property(e => e.Quantidade).HasColumnType("numeric(18, 3)");
                entity.Property(e => e.UCom).HasColumnName("uCom");
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

                entity.HasOne(d => d.DocumentoPadrao).WithMany(p => p.DocumentoItems)
                    .HasForeignKey(d => d.DocumentoPadraoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_DocumentoItem_DocumentoPadraoId_Documento");

                entity.HasOne(d => d.Produto).WithMany(p => p.DocumentoItems)
                    .HasForeignKey(d => d.ProdutoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_DocumentoPadraoItem_ProdutoId_Produto");
            });

            builder.Entity<DocumentoTotal>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PK_DocumentoPadraoTotal");

                entity.ToTable("DocumentoTotal");

                entity.Property(e => e.Id).ValueGeneratedNever();
                entity.Property(e => e.MetragemCubica).HasColumnType("numeric(10, 3)");
                entity.Property(e => e.PesoBruto).HasColumnType("numeric(10, 3)");
                entity.Property(e => e.PesoCubado).HasColumnType("numeric(10, 3)");
                entity.Property(e => e.PesoLiquido).HasColumnType("numeric(10, 3)");
                entity.Property(e => e.ValorDaNota).HasColumnType("numeric(18, 2)");
                entity.Property(e => e.Volumes).HasColumnType("numeric(10, 0)");

                entity.HasOne(d => d.IdNavigation).WithOne(p => p.DocumentoTotal)
                    .HasForeignKey<DocumentoTotal>(d => d.Id)
                    .HasConstraintName("FK_DocumentoTotal_Id_Documento");
            });

            builder.Entity<DocumentoTransportador>(entity =>
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

            builder.Entity<Empresa>(entity =>
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

            builder.Entity<Endereco>(entity =>
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
                    .HasMaxLength(20)
                    .IsUnicode(false);
                entity.Property(e => e.DataCadastro)
                    .HasDefaultValueSql("(getdate())")
                    .HasColumnType("datetime");
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
                entity.Property(e => e.Tipo)
                    .HasMaxLength(20)
                    .IsUnicode(false);
                entity.Property(e => e.TipoEndereco)
                    .HasMaxLength(20)
                    .IsUnicode(false);
                entity.Property(e => e.Uf)
                    .HasMaxLength(2)
                    .IsUnicode(false);
            });

            builder.Entity<Estado>(entity =>
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

            builder.Entity<Filial>(entity =>
            {
                entity.ToTable("Filial", "tnt");

                entity.Property(e => e.Id).ValueGeneratedNever();
                entity.Property(e => e.Ativo)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");
                entity.Property(e => e.DataCadastro)
                    .HasDefaultValueSql("(getdate())")
                    .HasColumnType("datetime");

                entity.HasOne(d => d.Empresa).WithMany(p => p.Filials)
                    .HasForeignKey(d => d.EmpresaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Filial_EmpresaId_Empresa");

                entity.HasOne(d => d.FilialPai).WithMany(p => p.InverseFilialPai)
                    .HasForeignKey(d => d.FilialPaiId)
                    .HasConstraintName("FK_Filial_FilialPaiId_Filial");
            });

            builder.Entity<FilialLastMile>(entity =>
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

                entity.HasOne(d => d.Municipio).WithMany(p => p.FilialLastMiles)
                    .HasForeignKey(d => d.MunicipioId)
                    .HasConstraintName("FK_FilialLastMile_MunicipioId_Municipio");
            });

            builder.Entity<FilialLastMileGrupo>(entity =>
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

            builder.Entity<FilialLastMileGrupoItem>(entity =>
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

            builder.Entity<Municipio>(entity =>
            {
                entity.ToTable("Municipio");

                entity.Property(e => e.Id).ValueGeneratedNever();
                entity.Property(e => e.Cep)
                    .HasMaxLength(8)
                    .IsUnicode(false);
                entity.Property(e => e.CodigoIbge).HasColumnName("CodigoIBGE");
                entity.Property(e => e.Nome)
                    .HasMaxLength(60)
                    .IsUnicode(false);
                entity.Property(e => e.Uf)
                    .HasMaxLength(2)
                    .IsUnicode(false);

                entity.HasOne(d => d.MunicipioPai).WithMany(p => p.InverseMunicipioPai)
                    .HasForeignKey(d => d.MunicipioPaiId)
                    .HasConstraintName("FK_Municipio_MunicipioPaiId_Municipio");
            });

            builder.Entity<Pais>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();
                entity.Property(e => e.Nome)
                    .HasMaxLength(60)
                    .IsUnicode(false);
                entity.Property(e => e.Sigla)
                    .HasMaxLength(3)
                    .IsUnicode(false);
            });

            builder.Entity<Pessoa>(entity =>
            {
                entity.ToTable("Pessoa");

                entity.Property(e => e.Id).ValueGeneratedNever();
                entity.Property(e => e.DataCadastro)
                    .HasDefaultValueSql("(getdate())")
                    .HasColumnType("datetime");
                entity.Property(e => e.Fantasia)
                    .HasMaxLength(80)
                    .IsUnicode(false);
                entity.Property(e => e.Nome)
                    .HasMaxLength(80)
                    .IsUnicode(false);
            });

            builder.Entity<PessoaEndereco>(entity =>
            {
                entity.ToTable("PessoaEndereco");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.HasOne(d => d.Endereco).WithMany(p => p.PessoaEnderecos)
                    .HasForeignKey(d => d.EnderecoId)
                    .HasConstraintName("FK_PessoaEndereco_EnderecoId_Endereco");

                entity.HasOne(d => d.Pessoa).WithMany(p => p.PessoaEnderecos)
                    .HasForeignKey(d => d.PessoaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PessoaEndereco_PessoaId_Pessoa");
            });

            builder.Entity<PessoaFisica>(entity =>
            {
                entity.ToTable("PessoaFisica");

                entity.HasIndex(e => e.Cpf, "UC_PessoaFisicaCpf").IsUnique();

                entity.Property(e => e.Id).ValueGeneratedNever();
                entity.Property(e => e.Cpf)
                    .HasMaxLength(14)
                    .IsUnicode(false);
                entity.Property(e => e.Rg)
                    .HasMaxLength(14)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdNavigation).WithOne(p => p.PessoaFisica)
                    .HasForeignKey<PessoaFisica>(d => d.Id)
                    .HasConstraintName("FK_PessoaFisica_Id_Pessoa");
            });

            builder.Entity<PessoaJuridica>(entity =>
            {
                entity.ToTable("PessoaJuridica");

                entity.HasIndex(e => e.Cnpj, "UC_PessoaJuridicaCnpj").IsUnique();

                entity.Property(e => e.Id).ValueGeneratedNever();
                entity.Property(e => e.Cnpj)
                    .HasMaxLength(14)
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

            builder.Entity<PessoaOutro>(entity =>
            {
                entity.HasIndex(e => e.Codigo, "UC_PessoaOutrosCodigo").IsUnique();

                entity.Property(e => e.Id).ValueGeneratedNever();
                entity.Property(e => e.Codigo)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdNavigation).WithOne(p => p.PessoaOutro)
                    .HasForeignKey<PessoaOutro>(d => d.Id)
                    .HasConstraintName("FK_PessoaOutros_Id_Pessoa");
            });

            builder.Entity<Produto>(entity =>
            {
                entity.ToTable("Produto");

                entity.HasIndex(e => new { e.PessoaId, e.Codigo }, "UC_ProdutoIdPessoaCodigo").IsUnique();

                entity.Property(e => e.Id).ValueGeneratedNever();
                entity.Property(e => e.Codigo)
                    .HasMaxLength(30)
                    .IsUnicode(false);
                entity.Property(e => e.Descricao)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.HasOne(d => d.Pessoa).WithMany(p => p.Produtos)
                    .HasForeignKey(d => d.PessoaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Produto_PessoaId_Pessoa");
            });

            builder.Entity<Romaneio>(entity =>
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

            builder.Entity<RomaneioCarga>(entity =>
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

            builder.Entity<RomaneioDocumento>(entity =>
            {
                entity.ToTable("RomaneioDocumento", "tnt");

                entity.HasIndex(e => new { e.RomaneioId, e.DocumentoId }, "UC_RomaneioDocumento_IdRomaneioIdDocumento").IsUnique();

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

            builder.Entity<Tenant>(entity =>
            {
                entity.ToTable("Tenant");

                entity.Property(e => e.Id).ValueGeneratedNever();
                entity.Property(e => e.Ativo)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");
                entity.Property(e => e.DataCadastro)
                    .HasDefaultValueSql("(getdate())")
                    .HasColumnType("datetime");
                entity.Property(e => e.Nome)
                    .HasMaxLength(80)
                    .IsUnicode(false);
            });

            builder.Entity<TipoContum>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();
                entity.Property(e => e.Nome)
                    .HasMaxLength(60)
                    .IsUnicode(false);
            });

            builder.Entity<TipoDocumento>(entity =>
            {
                entity.ToTable("TipoDocumento");

                entity.Property(e => e.Id).ValueGeneratedNever();
                entity.Property(e => e.Nome)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            builder.Entity<TipoRntrc>(entity =>
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

            builder.Entity<Transportador>(entity =>
            {
                entity.ToTable("Transportador");

                entity.Property(e => e.Id).ValueGeneratedNever();
                entity.Property(e => e.DataCadastro).HasColumnType("datetime");
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

            builder.Entity<Transportador1>(entity =>
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

            builder.Entity<TransportadorLastMile>(entity =>
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

            builder.Entity<TransportadorLastMileGrupo>(entity =>
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

            builder.Entity<TransportadorLastMileGrupoItem>(entity =>
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

            builder.Entity<Veiculo>(entity =>
            {
                entity.ToTable("Veiculo");

                entity.HasIndex(e => e.Placa, "UC_VeiculoPlaca").IsUnique();

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

            builder.Entity<Veiculo1>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PK_Veiculo_1");

                entity.ToTable("Veiculo", "tnt");

                entity.Property(e => e.Id).ValueGeneratedNever();
                entity.Property(e => e.DataCadastro)
                    .HasDefaultValueSql("(getdate())")
                    .HasColumnType("datetime");

                entity.HasOne(d => d.Tenant).WithMany(p => p.Veiculo1s)
                    .HasForeignKey(d => d.TenantId)
                    .HasConstraintName("FK_Veiculo_TenantId_Tenant");

                entity.HasOne(d => d.Veiculo).WithMany(p => p.Veiculo1s)
                    .HasForeignKey(d => d.VeiculoId)
                    .HasConstraintName("FK_Veiculo_VeiculoId_Veiculo");
            });

            builder.Entity<VeiculoTipo>(entity =>
            {
                entity.ToTable("VeiculoTipo");

                entity.Property(e => e.Nome)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            //builder.ApplyConfiguration(new PaisMap());

            base.OnModelCreating(builder);
        }


        public string GetOverlapConnection()
        {
            return "Data Source=192.168.10.110;Initial Catalog=Prototipo;Persist Security Info=True;User ID=sa;Password=WERasd27;MultipleActiveResultSets=true;Encrypt=false;TrustServerCertificate=false";

        }

    }

}
