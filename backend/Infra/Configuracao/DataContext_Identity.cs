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





        //public virtual DbSet<AspNetRole> AspNetRoles { get; set; }

        //public virtual DbSet<AspNetRoleClaim> AspNetRoleClaims { get; set; }

        //public virtual DbSet<AspNetUser> AspNetUsers { get; set; }

        //public virtual DbSet<AspNetUserClaim> AspNetUserClaims { get; set; }

        //public virtual DbSet<AspNetUserLogin> AspNetUserLogins { get; set; }

        //public virtual DbSet<AspNetUserToken> AspNetUserTokens { get; set; }


        protected void OnModelCreatingIdentity(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ApplicationUser>().ToTable("AspNetUsers").HasKey(t => t.Id);

            //modelBuilder.Entity<AspNetRole>(entity =>
            //{
            //    entity.Property(e => e.Name).HasMaxLength(256);
            //    entity.Property(e => e.NormalizedName).HasMaxLength(256);
            //});

            //modelBuilder.Entity<AspNetRoleClaim>(entity =>
            //{
            //    entity.Property(e => e.RoleId).HasMaxLength(450);

            //    entity.HasOne(d => d.Role).WithMany(p => p.AspNetRoleClaims).HasForeignKey(d => d.RoleId);
            //});

            //modelBuilder.Entity<AspNetUser>(entity =>
            //{
            //    entity.Property(e => e.Email).HasMaxLength(256);
            //    entity.Property(e => e.NormalizedEmail).HasMaxLength(256);
            //    entity.Property(e => e.NormalizedUserName).HasMaxLength(256);
            //    entity.Property(e => e.UserName).HasMaxLength(256);
            //    entity.Property(e => e.UsrCpf).HasColumnName("USR_CPF");

            //    //entity.HasMany(d => d.Roles).WithMany(p => p.Users)
            //    //    .UsingEntity<Dictionary<string, object>>(
            //    //        "AspNetUserRole",
            //    //        r => r.HasOne<AspNetRole>().WithMany().HasForeignKey("RoleId"),
            //    //        l => l.HasOne<AspNetUser>().WithMany().HasForeignKey("UserId"),
            //    //        j =>
            //    //        {
            //    //            j.HasKey("UserId", "RoleId");
            //    //            j.ToTable("AspNetUserRoles");
            //    //        });
            //});

            //modelBuilder.Entity<AspNetUserClaim>(entity =>
            //{
            //    entity.Property(e => e.UserId).HasMaxLength(450);

            //    entity.HasOne(d => d.User).WithMany(p => p.AspNetUserClaims).HasForeignKey(d => d.UserId);
            //});

            modelBuilder.Entity<AspNetUserLogin>(entity =>
            {
                entity.HasKey(e => new { e.LoginProvider, e.ProviderKey });

                entity.Property(e => e.LoginProvider).HasMaxLength(128);
                entity.Property(e => e.ProviderKey).HasMaxLength(128);
                entity.Property(e => e.UserId).HasMaxLength(450);

                entity.HasOne(d => d.User).WithMany(p => p.AspNetUserLogins).HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUserToken>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.LoginProvider, e.Name });

                entity.Property(e => e.LoginProvider).HasMaxLength(128);
                entity.Property(e => e.Name).HasMaxLength(128);

                entity.HasOne(d => d.User).WithMany(p => p.AspNetUserTokens).HasForeignKey(d => d.UserId);
            });


        }
    }
}
