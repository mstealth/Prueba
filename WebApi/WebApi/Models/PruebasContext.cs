using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Configuration;

#nullable disable

namespace WebApi.Models
{
    public partial class PruebasContext : DbContext
    {
        public PruebasContext()
        {
        }

        public PruebasContext(DbContextOptions<PruebasContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Factura> Facturas { get; set; }
        public virtual DbSet<Producto> Productos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                IConfigurationRoot configuration = new ConfigurationBuilder()
                    .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                    .AddJsonFile("appsettings.json")
                    .Build();

                optionsBuilder.UseSqlServer(configuration.GetConnectionString("PruebaConnectionString"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Factura>(entity =>
            {
                entity.ToTable("Factura");

                entity.Property(e => e.Descuento).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.DocumentoCliente).IsRequired();

                entity.Property(e => e.Iva).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.NombreCliente).IsRequired();

                entity.Property(e => e.SubTotal).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.Total).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.TotalDescuento).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.TotalImpuesto).HasColumnType("decimal(18, 2)");
            });

            modelBuilder.Entity<Producto>(entity =>
            {
                entity.ToTable("Producto");

                entity.Property(e => e.NombreProducto).IsRequired();
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
