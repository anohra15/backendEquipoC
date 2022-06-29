﻿using administrador.Persistence.Entities;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.CodeAnalysis;
using System.Threading.Tasks;

namespace administrador.Persistence.Database
{
    public class RCVDbContext : DbContext, IRCVDbContext
    {
        public RCVDbContext()
        {
        }

        public RCVDbContext(DbContextOptions<RCVDbContext> options) : base(options)
        {
        }
        public DbContext DbContext
        {
            get
            {
                return this;
            }
        }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Generar un uuid cuando creas un registro en una entidad
            modelBuilder.HasPostgresExtension("uuid-ossp");
            modelBuilder.Entity<AseguradoEntity>()
                .Property(id => id.Id)
                .HasColumnType("uuid")
                .HasDefaultValueSql("uuid_generate_v4()")    // Use 
                .IsRequired();
            modelBuilder.Entity<CarrosEntity>()
                .Property(serial => serial.Id)
                .HasColumnType("uuid")
                .HasDefaultValueSql("uuid_generate_v4()")    // Use 
                .IsRequired();
            modelBuilder.Entity<IncidentesEntity>()
                .Property(registro => registro.Id)
                .HasColumnType("uuid")
                .HasDefaultValueSql("uuid_generate_v4()")    // Use 
                .IsRequired();
            modelBuilder.Entity<PolizaEntity>()
                .Property(registro => registro.Id)
                .HasColumnType("uuid")
                .HasDefaultValueSql("uuid_generate_v4()")    // Use 
                .IsRequired();
            modelBuilder.Entity<UsuariosEntity>()
                .Property(dni => dni.Id)
                .HasColumnType("uuid")
                .HasDefaultValueSql("uuid_generate_v4()")    // Use 
                .IsRequired();
        }
        
        public Task<int> SaveChangesAsync()
        {
            return base.SaveChangesAsync();
        }
        public virtual Microsoft.EntityFrameworkCore.DbSet<AseguradoEntity> asegurado { get; set; }
        public virtual Microsoft.EntityFrameworkCore.DbSet<CarrosEntity> cars { get; set; }
        public virtual Microsoft.EntityFrameworkCore.DbSet<IncidentesEntity> incident { get; set; }
        public virtual Microsoft.EntityFrameworkCore.DbSet<PolizaEntity> poliza { get; set; }
        public virtual Microsoft.EntityFrameworkCore.DbSet<UsuariosEntity> user { get; set; }
    }
}