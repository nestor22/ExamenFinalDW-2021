using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace Examen_Final.Models
{
    public partial class ExamenFinalContext : DbContext
    {
        public ExamenFinalContext()
        {
        }

        public ExamenFinalContext(DbContextOptions<ExamenFinalContext> options)
            : base(options)
        {
        }

        public virtual DbSet<TblAlumno> TblAlumnos { get; set; }
        public virtual DbSet<TblCurso> TblCursos { get; set; }
        public virtual DbSet<TblNota> TblNotas { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {

                optionsBuilder.UseSqlServer("Data Source=DESKTOP-C9QBNC2;Initial Catalog=ExamenFinal;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<TblAlumno>(entity =>
            {
                entity.HasKey(e => e.Carnet)
                    .HasName("PK__tbl_alum__4CDEAA6F59EC70A6");

                entity.ToTable("tbl_alumnos");

                entity.Property(e => e.Carnet)
                    .ValueGeneratedNever()
                    .HasColumnName("carnet");

                entity.Property(e => e.Estado).HasColumnName("estado");

                entity.Property(e => e.FechaFin)
                    .HasColumnType("date")
                    .HasColumnName("fechaFin");

                entity.Property(e => e.FechaIngreso)
                    .HasColumnType("date")
                    .HasColumnName("fechaIngreso");

                entity.Property(e => e.Habilitado).HasColumnName("habilitado");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("nombre");
            });

            modelBuilder.Entity<TblCurso>(entity =>
            {
                entity.HasKey(e => e.CodigoCurso)
                    .HasName("PK__tbl_curs__967F7C6AE51EADFA");

                entity.ToTable("tbl_curso");

                entity.Property(e => e.CodigoCurso)
                    .ValueGeneratedNever()
                    .HasColumnName("codigo_curso");

                entity.Property(e => e.Habilitado).HasColumnName("habilitado");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("nombre");
            });

            modelBuilder.Entity<TblNota>(entity =>
            {
                entity.HasKey(e => new { e.CodigoCurso, e.Carnet })
                    .HasName("PK__tbl_nota__72B296CCD1B79C76");

                entity.ToTable("tbl_notas");

                entity.Property(e => e.CodigoCurso).HasColumnName("codigo_curso");

                entity.Property(e => e.Carnet).HasColumnName("carnet");

                entity.Property(e => e.FechaIngreso)
                    .HasColumnType("date")
                    .HasColumnName("fechaIngreso");

                entity.Property(e => e.Nota).HasColumnName("nota");

                entity.HasOne(d => d.CarnetNavigation)
                    .WithMany(p => p.TblNota)
                    .HasForeignKey(d => d.Carnet)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__tbl_notas__carne__276EDEB3");

                entity.HasOne(d => d.CodigoCursoNavigation)
                    .WithMany(p => p.TblNota)
                    .HasForeignKey(d => d.CodigoCurso)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__tbl_notas__codig__286302EC");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
