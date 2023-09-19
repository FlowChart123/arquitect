using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infra.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "tnt");

            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    USR_CPF = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Categoria",
                columns: table => new
                {
                    IdSistema = table.Column<int>(type: "int", nullable: false),
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categoria", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CodigoBarra",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CodigoBarras = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false),
                    Altura = table.Column<decimal>(type: "numeric(10,3)", nullable: true),
                    Largura = table.Column<decimal>(type: "numeric(10,3)", nullable: true),
                    Comprimento = table.Column<decimal>(type: "numeric(10,0)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CodigoBarra", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Despesa",
                columns: table => new
                {
                    IdCategoria = table.Column<int>(type: "int", nullable: false),
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Valor = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Mes = table.Column<int>(type: "int", nullable: false),
                    Ano = table.Column<int>(type: "int", nullable: false),
                    TipoDespesa = table.Column<int>(type: "int", nullable: false),
                    DataCadastro = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataAlteracao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataPagamento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataVencimento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Pago = table.Column<bool>(type: "bit", nullable: false),
                    DespesaAntrasada = table.Column<bool>(type: "bit", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Despesa", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Endereco",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TipoEndereco = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false),
                    Tipo = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false),
                    Logradouro = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    Numero = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true),
                    Complemento = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true),
                    Cep = table.Column<string>(type: "varchar(8)", unicode: false, maxLength: 8, nullable: true),
                    Uf = table.Column<string>(type: "varchar(2)", unicode: false, maxLength: 2, nullable: true),
                    MunicipioId = table.Column<int>(type: "int", nullable: true),
                    CodigoIBGE = table.Column<string>(type: "varchar(8)", unicode: false, maxLength: 8, nullable: true),
                    NomeMunicipio = table.Column<string>(type: "varchar(60)", unicode: false, maxLength: 60, nullable: true),
                    BairroId = table.Column<int>(type: "int", nullable: true),
                    NomeBairro = table.Column<string>(type: "varchar(60)", unicode: false, maxLength: 60, nullable: true),
                    Latitude = table.Column<double>(type: "float", nullable: true),
                    Longitude = table.Column<double>(type: "float", nullable: true),
                    DataCadastro = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Endereco", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FilialLastMileGrupo",
                schema: "tnt",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nome = table.Column<string>(type: "varchar(60)", unicode: false, maxLength: 60, nullable: false),
                    Codigo = table.Column<string>(type: "varchar(60)", unicode: false, maxLength: 60, nullable: true),
                    Ordem = table.Column<int>(type: "int", nullable: true),
                    Ativo = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FilialLastMileGrupo", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Municipio",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Nome = table.Column<string>(type: "varchar(60)", unicode: false, maxLength: 60, nullable: false),
                    CodigoIBGE = table.Column<int>(type: "int", nullable: true),
                    Cep = table.Column<string>(type: "varchar(8)", unicode: false, maxLength: 8, nullable: true),
                    Uf = table.Column<string>(type: "varchar(2)", unicode: false, maxLength: 2, nullable: true),
                    MunicipioPaiId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Municipio", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Municipio_MunicipioPaiId_Municipio",
                        column: x => x.MunicipioPaiId,
                        principalTable: "Municipio",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Pais",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Nome = table.Column<string>(type: "varchar(60)", unicode: false, maxLength: 60, nullable: false),
                    Sigla = table.Column<string>(type: "varchar(3)", unicode: false, maxLength: 3, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pais", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Pessoa",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nome = table.Column<string>(type: "varchar(80)", unicode: false, maxLength: 80, nullable: false),
                    Fantasia = table.Column<string>(type: "varchar(80)", unicode: false, maxLength: 80, nullable: false),
                    DataCadastro = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pessoa", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SistemaFinanceiro",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Mes = table.Column<int>(type: "int", nullable: false),
                    Ano = table.Column<int>(type: "int", nullable: false),
                    DiaFechamento = table.Column<int>(type: "int", nullable: false),
                    GerarCopiaDespesa = table.Column<bool>(type: "bit", nullable: false),
                    MesCopia = table.Column<int>(type: "int", nullable: false),
                    AnoCopia = table.Column<int>(type: "int", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SistemaFinanceiro", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tenant",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nome = table.Column<string>(type: "varchar(80)", unicode: false, maxLength: 80, nullable: false),
                    DataCadastro = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
                    Ativo = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "((1))")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tenant", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TipoConta",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Nome = table.Column<string>(type: "varchar(60)", unicode: false, maxLength: 60, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoConta", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TipoDocumento",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Nome = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoDocumento", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TipoRntrc",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Codigo = table.Column<string>(type: "varchar(5)", unicode: false, maxLength: 5, nullable: false),
                    Descricao = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoRntrc", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TransportadorLastMileGrupo",
                schema: "tnt",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nome = table.Column<string>(type: "varchar(60)", unicode: false, maxLength: 60, nullable: false),
                    Codigo = table.Column<string>(type: "varchar(60)", unicode: false, maxLength: 60, nullable: true),
                    Ordem = table.Column<int>(type: "int", nullable: true),
                    Ativo = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TransportadorLastMileGrupo", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "VeiculoTipo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VeiculoTipo", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Bairro",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Nome = table.Column<string>(type: "varchar(60)", unicode: false, maxLength: 60, nullable: false),
                    MunicipioId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bairro", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Bairro_MunicipioId_Municipio",
                        column: x => x.MunicipioId,
                        principalTable: "Municipio",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Estado",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    IdPais = table.Column<int>(type: "int", nullable: false),
                    Nome = table.Column<string>(type: "varchar(60)", unicode: false, maxLength: 60, nullable: false),
                    Uf = table.Column<string>(type: "varchar(2)", unicode: false, maxLength: 2, nullable: true),
                    CepInicial = table.Column<string>(type: "varchar(8)", unicode: false, maxLength: 8, nullable: true),
                    CepFinal = table.Column<string>(type: "varchar(8)", unicode: false, maxLength: 8, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Estado", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Estado_IdPais_Pais",
                        column: x => x.IdPais,
                        principalTable: "Pais",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "PessoaEndereco",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PessoaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EnderecoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PessoaEndereco", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PessoaEndereco_EnderecoId_Endereco",
                        column: x => x.EnderecoId,
                        principalTable: "Endereco",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PessoaEndereco_PessoaId_Pessoa",
                        column: x => x.PessoaId,
                        principalTable: "Pessoa",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "PessoaFisica",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Cpf = table.Column<string>(type: "varchar(14)", unicode: false, maxLength: 14, nullable: false),
                    Rg = table.Column<string>(type: "varchar(14)", unicode: false, maxLength: 14, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PessoaFisica", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PessoaFisica_Id_Pessoa",
                        column: x => x.Id,
                        principalTable: "Pessoa",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PessoaJuridica",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Cnpj = table.Column<string>(type: "varchar(14)", unicode: false, maxLength: 14, nullable: false),
                    InscricaoEstadual = table.Column<string>(type: "varchar(14)", unicode: false, maxLength: 14, nullable: false),
                    InscricaoMunicipal = table.Column<string>(type: "varchar(14)", unicode: false, maxLength: 14, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PessoaJuridica", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PessoaJuridica_Id_Pessoa",
                        column: x => x.Id,
                        principalTable: "Pessoa",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PessoaOutros",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Codigo = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PessoaOutros", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PessoaOutros_Id_Pessoa",
                        column: x => x.Id,
                        principalTable: "Pessoa",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Produto",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PessoaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Codigo = table.Column<string>(type: "varchar(30)", unicode: false, maxLength: 30, nullable: false),
                    Descricao = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Produto", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Produto_PessoaId_Pessoa",
                        column: x => x.PessoaId,
                        principalTable: "Pessoa",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "UsuarioSistemaFinanceiro",
                columns: table => new
                {
                    IdSistema = table.Column<int>(type: "int", nullable: false),
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmailUsuario = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Administrador = table.Column<bool>(type: "bit", nullable: false),
                    SistemaAtual = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsuarioSistemaFinanceiro", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UsuarioSistemaFinanceiro_SistemaFinanceiro_IdSistema",
                        column: x => x.IdSistema,
                        principalTable: "SistemaFinanceiro",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Empresa",
                schema: "tnt",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenantId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nome = table.Column<string>(type: "varchar(80)", unicode: false, maxLength: 80, nullable: false),
                    Ativo = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Empresa", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Empresa_TenantId_Tenant",
                        column: x => x.TenantId,
                        principalTable: "Tenant",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Romaneio",
                schema: "tnt",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TenantId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DataEmissao = table.Column<DateTime>(type: "datetime", nullable: false),
                    DataCadastro = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Romaneio", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Romaneio_TenantId_Tenant",
                        column: x => x.TenantId,
                        principalTable: "Tenant",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Documento",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TipoDocumentoId = table.Column<int>(type: "int", nullable: false),
                    Chave = table.Column<string>(type: "varchar(44)", unicode: false, maxLength: 44, nullable: false),
                    EmitenteId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RemetenteId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DestinatarioId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Numero = table.Column<int>(type: "int", nullable: false),
                    Serie = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: false),
                    NumeroCliente = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false),
                    xPed = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    DataEmissao = table.Column<DateTime>(type: "datetime", nullable: true),
                    DataCadastro = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Documento", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Documento_DestinatarioId_Pessoa",
                        column: x => x.DestinatarioId,
                        principalTable: "Pessoa",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Documento_EmitenteId_Pessoa",
                        column: x => x.EmitenteId,
                        principalTable: "Pessoa",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Documento_IdTipoDocumento_TipoDocumento",
                        column: x => x.TipoDocumentoId,
                        principalTable: "TipoDocumento",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Documento_RemetenteId_Pessoa",
                        column: x => x.RemetenteId,
                        principalTable: "Pessoa",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Transportador",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TipoRntrcId = table.Column<int>(type: "int", nullable: false),
                    Rntrc = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: true),
                    RntrcValidade = table.Column<DateTime>(type: "date", nullable: true),
                    DataCadastro = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transportador", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Transportador_Id_Pessoa",
                        column: x => x.Id,
                        principalTable: "Pessoa",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Transportador_TipoRntrcId_TipoRntrc",
                        column: x => x.TipoRntrcId,
                        principalTable: "TipoRntrc",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Veiculo",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Placa = table.Column<string>(type: "varchar(8)", unicode: false, maxLength: 8, nullable: false),
                    ProprietarioId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    VieculoTipoId = table.Column<int>(type: "int", nullable: true),
                    Renavan = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Ano = table.Column<int>(type: "int", nullable: true),
                    Cor = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    NumeroCrv = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Chassi = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Combustivel = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    MarcaModelo = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    CapacidadePeso = table.Column<decimal>(type: "numeric(10,0)", nullable: true),
                    CapacidadeM3 = table.Column<decimal>(type: "numeric(10,0)", nullable: true),
                    Eixos = table.Column<int>(type: "int", nullable: true),
                    DataCadastro = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Veiculo", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Veiculo_ProprietarioId_Pessoa",
                        column: x => x.ProprietarioId,
                        principalTable: "Pessoa",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Veiculo_VeiculoTipoId_VeiculoTipo",
                        column: x => x.VieculoTipoId,
                        principalTable: "VeiculoTipo",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "TransportadorLastMile",
                schema: "tnt",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TransportadorId = table.Column<int>(type: "int", nullable: false),
                    CepInicial = table.Column<string>(type: "varchar(8)", unicode: false, maxLength: 8, nullable: true),
                    CepFinal = table.Column<string>(type: "varchar(8)", unicode: false, maxLength: 8, nullable: true),
                    BairroId = table.Column<int>(type: "int", nullable: true),
                    MunicipioId = table.Column<int>(type: "int", nullable: true),
                    EstadoId = table.Column<int>(type: "int", nullable: true),
                    DataCadastro = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TransportadorLastMile", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TransportadorLastMile_EstadoId_Estado",
                        column: x => x.EstadoId,
                        principalTable: "Estado",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Filial",
                schema: "tnt",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    EmpresaId = table.Column<int>(type: "int", nullable: false),
                    PessoaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FilialPaiId = table.Column<int>(type: "int", nullable: true),
                    DataCadastro = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
                    Ativo = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "((1))")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Filial", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Filial_EmpresaId_Empresa",
                        column: x => x.EmpresaId,
                        principalSchema: "tnt",
                        principalTable: "Empresa",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Filial_FilialPaiId_Filial",
                        column: x => x.FilialPaiId,
                        principalSchema: "tnt",
                        principalTable: "Filial",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Documento",
                schema: "tnt",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DocumentoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TenantId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DataEntrada = table.Column<DateTime>(type: "datetime", nullable: false),
                    Ativo = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "((1))")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Documento_Id", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Documento_DocumentoId_Documento",
                        column: x => x.DocumentoId,
                        principalTable: "Documento",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Documento_TenantId_Tenant",
                        column: x => x.TenantId,
                        principalTable: "Tenant",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "DocumentoImposto",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Icms = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    Orig = table.Column<string>(type: "varchar(1)", unicode: false, maxLength: 1, nullable: true),
                    IcmsCst = table.Column<string>(type: "varchar(2)", unicode: false, maxLength: 2, nullable: true),
                    ModBc = table.Column<int>(type: "int", nullable: true),
                    vBC = table.Column<decimal>(type: "numeric(18,2)", nullable: true),
                    pIcms = table.Column<decimal>(type: "numeric(18,2)", nullable: true),
                    vIcms = table.Column<decimal>(type: "numeric(18,2)", nullable: true),
                    cEnq = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: true),
                    IpiCst = table.Column<string>(type: "varchar(2)", unicode: false, maxLength: 2, nullable: true),
                    PisCst = table.Column<string>(type: "varchar(2)", unicode: false, maxLength: 2, nullable: true),
                    PisvBc = table.Column<decimal>(type: "numeric(18,2)", nullable: true),
                    PispPIS = table.Column<decimal>(type: "numeric(18,2)", nullable: true),
                    PisvPis = table.Column<decimal>(type: "numeric(18,2)", nullable: true),
                    CofinsCst = table.Column<string>(type: "varchar(2)", unicode: false, maxLength: 2, nullable: true),
                    CofinsvBC = table.Column<decimal>(type: "numeric(18,2)", nullable: true),
                    CofinspCOFINS = table.Column<decimal>(type: "numeric(18,2)", nullable: true),
                    CofinsvCofins = table.Column<decimal>(type: "numeric(18,2)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DocumentoPadraoImposto", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DocumentoImposto_Id_Documento",
                        column: x => x.Id,
                        principalTable: "Documento",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DocumentoItem",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DocumentoPadraoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProdutoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Quantidade = table.Column<decimal>(type: "numeric(18,3)", nullable: true),
                    nItem = table.Column<int>(type: "int", nullable: true),
                    cProd = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true),
                    cEan = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true),
                    uCom = table.Column<int>(type: "int", nullable: true),
                    qCom = table.Column<int>(type: "int", nullable: true),
                    vUnCom = table.Column<decimal>(type: "numeric(18,5)", nullable: true),
                    vProd = table.Column<decimal>(type: "numeric(18,2)", nullable: true),
                    vUnTrib = table.Column<decimal>(type: "numeric(18,5)", nullable: true),
                    xPed = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true),
                    Cfop = table.Column<string>(type: "varchar(4)", unicode: false, maxLength: 4, nullable: true),
                    cEANTrib = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true),
                    Ncm = table.Column<string>(type: "varchar(8)", unicode: false, maxLength: 8, nullable: true),
                    uTrib = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true),
                    qTrib = table.Column<decimal>(type: "numeric(18,2)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DocumentoPadraoItem", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DocumentoItem_DocumentoPadraoId_Documento",
                        column: x => x.DocumentoPadraoId,
                        principalTable: "Documento",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_DocumentoPadraoItem_ProdutoId_Produto",
                        column: x => x.ProdutoId,
                        principalTable: "Produto",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "DocumentoTotal",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ValorDaNota = table.Column<decimal>(type: "numeric(18,2)", nullable: true),
                    PesoLiquido = table.Column<decimal>(type: "numeric(10,3)", nullable: true),
                    PesoBruto = table.Column<decimal>(type: "numeric(10,3)", nullable: true),
                    PesoCubado = table.Column<decimal>(type: "numeric(10,3)", nullable: true),
                    Volumes = table.Column<decimal>(type: "numeric(10,0)", nullable: true),
                    MetragemCubica = table.Column<decimal>(type: "numeric(10,3)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DocumentoPadraoTotal", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DocumentoTotal_Id_Documento",
                        column: x => x.Id,
                        principalTable: "Documento",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DocumentoTransportador",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Cnpj = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true),
                    Nome = table.Column<string>(type: "varchar(60)", unicode: false, maxLength: 60, nullable: true),
                    InscricaoEstadual = table.Column<string>(type: "varchar(14)", unicode: false, maxLength: 14, nullable: true),
                    Municipio = table.Column<string>(type: "varchar(60)", unicode: false, maxLength: 60, nullable: true),
                    Uf = table.Column<string>(type: "varchar(2)", unicode: false, maxLength: 2, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DocumentoPadraoTransportador", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DocumentoPadraoTransportador_Id_Documento",
                        column: x => x.Id,
                        principalTable: "Documento",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Transportador",
                schema: "tnt",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TransportadorId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TenantId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TitularId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TipoContaId = table.Column<int>(type: "int", nullable: true),
                    ChavePix = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    Banco = table.Column<string>(type: "varchar(3)", unicode: false, maxLength: 3, nullable: true),
                    Agencia = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: true),
                    AgencidaDigito = table.Column<string>(type: "varchar(2)", unicode: false, maxLength: 2, nullable: true),
                    Conta = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: true),
                    ContaDigito = table.Column<string>(type: "varchar(2)", unicode: false, maxLength: 2, nullable: true),
                    CnpjCpfFavorecido = table.Column<string>(type: "varchar(18)", unicode: false, maxLength: 18, nullable: true),
                    NomeFavorecido = table.Column<string>(type: "varchar(60)", unicode: false, maxLength: 60, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transportador_1", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Transportador_TenantId_Tenant",
                        column: x => x.TenantId,
                        principalTable: "Tenant",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Transportador_TipoContaId_TipoConta",
                        column: x => x.TipoContaId,
                        principalTable: "TipoConta",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Transportador_TitularId_Pessoa",
                        column: x => x.Id,
                        principalTable: "Pessoa",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Transportador_TransportadorId_Transportador",
                        column: x => x.TransportadorId,
                        principalTable: "Transportador",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Veiculo",
                schema: "tnt",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TenantId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    VeiculoId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DataCadastro = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Veiculo_1", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Veiculo_TenantId_Tenant",
                        column: x => x.TenantId,
                        principalTable: "Tenant",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Veiculo_VeiculoId_Veiculo",
                        column: x => x.VeiculoId,
                        principalTable: "Veiculo",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "TransportadorLastMileGrupoItem",
                schema: "tnt",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TransportadorLastMileGrupoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TransportadorLastMileId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TransportadorLastMileGrupoItem", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TransportadorLastMileGrupoItem_TransportadorLastMileGrupoItem_TransportadorLastMileGrupo",
                        column: x => x.TransportadorLastMileGrupoId,
                        principalSchema: "tnt",
                        principalTable: "TransportadorLastMileGrupo",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_TransportadorLastMileGrupoItem_TransportadorLastMileId_TransportadorLastMile",
                        column: x => x.TransportadorLastMileId,
                        principalSchema: "tnt",
                        principalTable: "TransportadorLastMile",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "FilialLastMile",
                schema: "tnt",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FilialId = table.Column<int>(type: "int", nullable: false),
                    CepInicial = table.Column<string>(type: "varchar(8)", unicode: false, maxLength: 8, nullable: true),
                    CepFinal = table.Column<string>(type: "varchar(8)", unicode: false, maxLength: 8, nullable: true),
                    BairroId = table.Column<int>(type: "int", nullable: true),
                    MunicipioId = table.Column<int>(type: "int", nullable: true),
                    EstadoId = table.Column<int>(type: "int", nullable: true),
                    DataCadastro = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FilialLastMile", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FilialLastMile_EstadoId_Estado",
                        column: x => x.EstadoId,
                        principalTable: "Estado",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_FilialLastMile_FilialId_Filial",
                        column: x => x.FilialId,
                        principalSchema: "tnt",
                        principalTable: "Filial",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_FilialLastMile_MunicipioId_Municipio",
                        column: x => x.MunicipioId,
                        principalTable: "Municipio",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_FilialRegiao_BairroId_Bairro",
                        column: x => x.BairroId,
                        principalTable: "Bairro",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "DocumentoFilialGrupo",
                schema: "tnt",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EnderecoServicoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FilialId = table.Column<int>(type: "int", nullable: false),
                    FilialAtualId = table.Column<int>(type: "int", nullable: true),
                    FilialDestinoId = table.Column<int>(type: "int", nullable: true),
                    FilialLastMileGrupoItemId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    TransportadorLastMileGrupoItemId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DocumentoFilialGrupo", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DocumentoRegiao_IdEnderecoServicoId_Endereco",
                        column: x => x.EnderecoServicoId,
                        principalTable: "Endereco",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_DocumentoRegiao_Id_Documento",
                        column: x => x.Id,
                        principalSchema: "tnt",
                        principalTable: "Documento",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RomaneioDocumento",
                schema: "tnt",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RomaneioId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DocumentoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RomaneioDocumento", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RomaneioDocumento_Id_Documento",
                        column: x => x.Id,
                        principalSchema: "tnt",
                        principalTable: "Documento",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_RomaneioDocumento_Id_Romaneio",
                        column: x => x.RomaneioId,
                        principalSchema: "tnt",
                        principalTable: "Romaneio",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "RomaneioCarga",
                schema: "tnt",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    VeiculoId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    VeiculoTipoId = table.Column<int>(type: "int", nullable: true),
                    PesoBruto = table.Column<decimal>(type: "numeric(18,3)", nullable: true),
                    MetragemCubica = table.Column<decimal>(type: "numeric(18,3)", nullable: true),
                    Paradas = table.Column<int>(type: "int", nullable: true),
                    DitanciaKm = table.Column<decimal>(type: "numeric(18,3)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RomaneioCarga", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RomaneioCarga_Id_Romaneio",
                        column: x => x.Id,
                        principalSchema: "tnt",
                        principalTable: "Romaneio",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RomaneioCarga_VeiculoId_Veiculo",
                        column: x => x.VeiculoId,
                        principalSchema: "tnt",
                        principalTable: "Veiculo",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_RomaneioCarga_VeiculoTipoId_VeiculoTipo",
                        column: x => x.VeiculoTipoId,
                        principalTable: "VeiculoTipo",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "FilialLastMileGrupoItem",
                schema: "tnt",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FilialLastMileGrupoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FilialLastMileId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FilialLastMileGrupoItem", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FilialLastMileGrupoItem_FilialLastMileGrupoItem_FilialLastMileGrupo",
                        column: x => x.FilialLastMileGrupoId,
                        principalSchema: "tnt",
                        principalTable: "FilialLastMileGrupo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FilialLastMileGrupoItem_FilialLastMileId_FilialLastMile",
                        column: x => x.FilialLastMileId,
                        principalSchema: "tnt",
                        principalTable: "FilialLastMile",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Bairro_MunicipioId",
                table: "Bairro",
                column: "MunicipioId");

            migrationBuilder.CreateIndex(
                name: "UC_CodigoBarra",
                table: "CodigoBarra",
                column: "CodigoBarras",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Documento_DestinatarioId",
                table: "Documento",
                column: "DestinatarioId");

            migrationBuilder.CreateIndex(
                name: "IX_Documento_RemetenteId",
                table: "Documento",
                column: "RemetenteId");

            migrationBuilder.CreateIndex(
                name: "IX_Documento_TipoDocumentoId",
                table: "Documento",
                column: "TipoDocumentoId");

            migrationBuilder.CreateIndex(
                name: "UC_Documento_IdEmitente_IdTipoDocumento_Numero_Serie_NumeroCliente",
                table: "Documento",
                columns: new[] { "EmitenteId", "TipoDocumentoId", "Numero", "Serie", "NumeroCliente" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "UC_DocumentoChave",
                table: "Documento",
                column: "Chave",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Documento_DocumentoId",
                schema: "tnt",
                table: "Documento",
                column: "DocumentoId");

            migrationBuilder.CreateIndex(
                name: "IX_Documento_TenantId",
                schema: "tnt",
                table: "Documento",
                column: "TenantId");

            migrationBuilder.CreateIndex(
                name: "IX_DocumentoFilialGrupo_EnderecoServicoId",
                schema: "tnt",
                table: "DocumentoFilialGrupo",
                column: "EnderecoServicoId");

            migrationBuilder.CreateIndex(
                name: "IX_DocumentoItem_DocumentoPadraoId",
                table: "DocumentoItem",
                column: "DocumentoPadraoId");

            migrationBuilder.CreateIndex(
                name: "IX_DocumentoItem_ProdutoId",
                table: "DocumentoItem",
                column: "ProdutoId");

            migrationBuilder.CreateIndex(
                name: "IX_Empresa_TenantId",
                schema: "tnt",
                table: "Empresa",
                column: "TenantId");

            migrationBuilder.CreateIndex(
                name: "IX_Estado_IdPais",
                table: "Estado",
                column: "IdPais");

            migrationBuilder.CreateIndex(
                name: "IX_Filial_EmpresaId",
                schema: "tnt",
                table: "Filial",
                column: "EmpresaId");

            migrationBuilder.CreateIndex(
                name: "IX_Filial_FilialPaiId",
                schema: "tnt",
                table: "Filial",
                column: "FilialPaiId");

            migrationBuilder.CreateIndex(
                name: "IX_FilialLastMile_BairroId",
                schema: "tnt",
                table: "FilialLastMile",
                column: "BairroId");

            migrationBuilder.CreateIndex(
                name: "IX_FilialLastMile_EstadoId",
                schema: "tnt",
                table: "FilialLastMile",
                column: "EstadoId");

            migrationBuilder.CreateIndex(
                name: "IX_FilialLastMile_FilialId",
                schema: "tnt",
                table: "FilialLastMile",
                column: "FilialId");

            migrationBuilder.CreateIndex(
                name: "IX_FilialLastMile_MunicipioId",
                schema: "tnt",
                table: "FilialLastMile",
                column: "MunicipioId");

            migrationBuilder.CreateIndex(
                name: "IX_FilialLastMileGrupoItem_FilialLastMileGrupoId",
                schema: "tnt",
                table: "FilialLastMileGrupoItem",
                column: "FilialLastMileGrupoId");

            migrationBuilder.CreateIndex(
                name: "IX_FilialLastMileGrupoItem_FilialLastMileId",
                schema: "tnt",
                table: "FilialLastMileGrupoItem",
                column: "FilialLastMileId");

            migrationBuilder.CreateIndex(
                name: "IX_Municipio_MunicipioPaiId",
                table: "Municipio",
                column: "MunicipioPaiId");

            migrationBuilder.CreateIndex(
                name: "IX_PessoaEndereco_EnderecoId",
                table: "PessoaEndereco",
                column: "EnderecoId");

            migrationBuilder.CreateIndex(
                name: "IX_PessoaEndereco_PessoaId",
                table: "PessoaEndereco",
                column: "PessoaId");

            migrationBuilder.CreateIndex(
                name: "UC_PessoaFisicaCpf",
                table: "PessoaFisica",
                column: "Cpf",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "UC_PessoaJuridicaCnpj",
                table: "PessoaJuridica",
                column: "Cnpj",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "UC_PessoaOutrosCodigo",
                table: "PessoaOutros",
                column: "Codigo",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "UC_ProdutoIdPessoaCodigo",
                table: "Produto",
                columns: new[] { "PessoaId", "Codigo" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Romaneio_TenantId",
                schema: "tnt",
                table: "Romaneio",
                column: "TenantId");

            migrationBuilder.CreateIndex(
                name: "IX_RomaneioCarga_VeiculoId",
                schema: "tnt",
                table: "RomaneioCarga",
                column: "VeiculoId");

            migrationBuilder.CreateIndex(
                name: "IX_RomaneioCarga_VeiculoTipoId",
                schema: "tnt",
                table: "RomaneioCarga",
                column: "VeiculoTipoId");

            migrationBuilder.CreateIndex(
                name: "UC_RomaneioDocumento_IdRomaneioIdDocumento",
                schema: "tnt",
                table: "RomaneioDocumento",
                columns: new[] { "RomaneioId", "DocumentoId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Transportador_TipoRntrcId",
                table: "Transportador",
                column: "TipoRntrcId");

            migrationBuilder.CreateIndex(
                name: "IX_Transportador_TenantId",
                schema: "tnt",
                table: "Transportador",
                column: "TenantId");

            migrationBuilder.CreateIndex(
                name: "IX_Transportador_TipoContaId",
                schema: "tnt",
                table: "Transportador",
                column: "TipoContaId");

            migrationBuilder.CreateIndex(
                name: "IX_Transportador_TransportadorId",
                schema: "tnt",
                table: "Transportador",
                column: "TransportadorId");

            migrationBuilder.CreateIndex(
                name: "IX_TransportadorLastMile_EstadoId",
                schema: "tnt",
                table: "TransportadorLastMile",
                column: "EstadoId");

            migrationBuilder.CreateIndex(
                name: "IX_TransportadorLastMileGrupoItem_TransportadorLastMileGrupoId",
                schema: "tnt",
                table: "TransportadorLastMileGrupoItem",
                column: "TransportadorLastMileGrupoId");

            migrationBuilder.CreateIndex(
                name: "IX_TransportadorLastMileGrupoItem_TransportadorLastMileId",
                schema: "tnt",
                table: "TransportadorLastMileGrupoItem",
                column: "TransportadorLastMileId");

            migrationBuilder.CreateIndex(
                name: "IX_UsuarioSistemaFinanceiro_IdSistema",
                table: "UsuarioSistemaFinanceiro",
                column: "IdSistema");

            migrationBuilder.CreateIndex(
                name: "IX_Veiculo_ProprietarioId",
                table: "Veiculo",
                column: "ProprietarioId");

            migrationBuilder.CreateIndex(
                name: "IX_Veiculo_VieculoTipoId",
                table: "Veiculo",
                column: "VieculoTipoId");

            migrationBuilder.CreateIndex(
                name: "UC_VeiculoPlaca",
                table: "Veiculo",
                column: "Placa",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Veiculo_TenantId",
                schema: "tnt",
                table: "Veiculo",
                column: "TenantId");

            migrationBuilder.CreateIndex(
                name: "IX_Veiculo_VeiculoId",
                schema: "tnt",
                table: "Veiculo",
                column: "VeiculoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "Categoria");

            migrationBuilder.DropTable(
                name: "CodigoBarra");

            migrationBuilder.DropTable(
                name: "Despesa");

            migrationBuilder.DropTable(
                name: "DocumentoFilialGrupo",
                schema: "tnt");

            migrationBuilder.DropTable(
                name: "DocumentoImposto");

            migrationBuilder.DropTable(
                name: "DocumentoItem");

            migrationBuilder.DropTable(
                name: "DocumentoTotal");

            migrationBuilder.DropTable(
                name: "DocumentoTransportador");

            migrationBuilder.DropTable(
                name: "FilialLastMileGrupoItem",
                schema: "tnt");

            migrationBuilder.DropTable(
                name: "PessoaEndereco");

            migrationBuilder.DropTable(
                name: "PessoaFisica");

            migrationBuilder.DropTable(
                name: "PessoaJuridica");

            migrationBuilder.DropTable(
                name: "PessoaOutros");

            migrationBuilder.DropTable(
                name: "RomaneioCarga",
                schema: "tnt");

            migrationBuilder.DropTable(
                name: "RomaneioDocumento",
                schema: "tnt");

            migrationBuilder.DropTable(
                name: "Transportador",
                schema: "tnt");

            migrationBuilder.DropTable(
                name: "TransportadorLastMileGrupoItem",
                schema: "tnt");

            migrationBuilder.DropTable(
                name: "UsuarioSistemaFinanceiro");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Produto");

            migrationBuilder.DropTable(
                name: "FilialLastMileGrupo",
                schema: "tnt");

            migrationBuilder.DropTable(
                name: "FilialLastMile",
                schema: "tnt");

            migrationBuilder.DropTable(
                name: "Endereco");

            migrationBuilder.DropTable(
                name: "Veiculo",
                schema: "tnt");

            migrationBuilder.DropTable(
                name: "Documento",
                schema: "tnt");

            migrationBuilder.DropTable(
                name: "Romaneio",
                schema: "tnt");

            migrationBuilder.DropTable(
                name: "TipoConta");

            migrationBuilder.DropTable(
                name: "Transportador");

            migrationBuilder.DropTable(
                name: "TransportadorLastMileGrupo",
                schema: "tnt");

            migrationBuilder.DropTable(
                name: "TransportadorLastMile",
                schema: "tnt");

            migrationBuilder.DropTable(
                name: "SistemaFinanceiro");

            migrationBuilder.DropTable(
                name: "Filial",
                schema: "tnt");

            migrationBuilder.DropTable(
                name: "Bairro");

            migrationBuilder.DropTable(
                name: "Veiculo");

            migrationBuilder.DropTable(
                name: "Documento");

            migrationBuilder.DropTable(
                name: "TipoRntrc");

            migrationBuilder.DropTable(
                name: "Estado");

            migrationBuilder.DropTable(
                name: "Empresa",
                schema: "tnt");

            migrationBuilder.DropTable(
                name: "Municipio");

            migrationBuilder.DropTable(
                name: "VeiculoTipo");

            migrationBuilder.DropTable(
                name: "Pessoa");

            migrationBuilder.DropTable(
                name: "TipoDocumento");

            migrationBuilder.DropTable(
                name: "Pais");

            migrationBuilder.DropTable(
                name: "Tenant");
        }
    }
}
