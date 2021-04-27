using Infrastructure.DAL.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.DAL
{
    public class StarWarsPlusContext : DbContext
    {
        public DbSet<User> User { get; set; }
        public DbSet<Homeworld> Homeworld { get; set; }
        public DbSet<Specie> Specie { get; set; }

        public StarWarsPlusContext()
        { }

        public StarWarsPlusContext(DbContextOptions<StarWarsPlusContext> options) : base(options)
        { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer();
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Homeworld>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id).IsRequired();
                entity.Property(e => e.Name).IsRequired().HasMaxLength(255).IsUnicode(false);
            });

            modelBuilder.Entity<Specie>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id).IsRequired();
                entity.Property(e => e.Name).IsRequired().HasMaxLength(255).IsUnicode(false);
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id).IsRequired();
                entity.Property(e => e.Name).IsRequired().HasMaxLength(255).IsUnicode(false);
                entity.Property(e => e.Height).IsRequired();
                entity.Property(e => e.Gender).IsRequired();
                entity.Property(e => e.Created).IsRequired();
                entity.Property(e => e.Edited).IsRequired();

                entity.HasOne(d => d.Homeworld)
                .WithMany(p => p.Users)
                .HasForeignKey(d => d.HomeworldId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);

                entity.HasOne(d => d.Specie)
                .WithMany(p => p.Users)
                .HasForeignKey(d => d.SpecieId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);
            });
        }
    }
}
