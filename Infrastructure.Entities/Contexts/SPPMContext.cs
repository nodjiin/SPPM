﻿using System;
using System.Configuration;
using Domain.Model;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Infrastructure.Entities.Contexts
{
    public class SPPMContext : DbContext
    {
        public SPPMContext()
        {
        }

        public SPPMContext(DbContextOptions<SPPMContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Account> Accounts { get; set; }
        public virtual DbSet<Profile> Profiles { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
                optionsBuilder.UseSqlServer(ConfigurationManager.ConnectionStrings["SPPMContext"].ConnectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Account>(entity =>
            {
                entity.HasKey(e => e.Id)
                    .HasName("Accounts_pk")
                    .IsClustered(false);

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(60)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Target)
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Username)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.HasOne(d => d.Profile)
                    .WithMany(p => p.Accounts)
                    .HasForeignKey(d => d.ProfileId)
                    .HasConstraintName("Accounts_Profiles_Id_fk");
            });

            modelBuilder.Entity<Profile>(entity =>
            {
                entity.HasKey(e => e.Id)
                    .HasName("Profiles_pk")
                    .IsClustered(false);

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.EmailAddress)
                    .IsRequired()
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(60)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Username)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .IsFixedLength();
            });

            OnModelCreatingPartial(modelBuilder);
        }

        private void OnModelCreatingPartial(ModelBuilder modelBuilder)
        {
            throw new NotImplementedException();
        }
    }
}