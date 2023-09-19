using Entities.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata;
using System.Reflection.Emit;
using Entities.IdentityModels;
//using Entities.IdentityModels;


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
    public partial class DataContext : IdentityDbContext<ApplicationUser> 
    {
        public DataContext(DbContextOptions options) : base(options)
        {
            ChangeTracker.AutoDetectChangesEnabled = false;
            ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        }




        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            //optionsBuilder.LogTo(Console.WriteLine);

            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(GetOverlapConnection());
                base.OnConfiguring(optionsBuilder);
            }
        }

        

        public string GetOverlapConnection()
        {
            return "Data Source=192.168.10.110;Initial Catalog=Facility;Persist Security Info=True;User ID=sa;Password=WERasd27;MultipleActiveResultSets=true;Encrypt=false;TrustServerCertificate=false";

        }

    }

}
