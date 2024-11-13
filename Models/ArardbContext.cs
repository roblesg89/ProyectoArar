using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace ProyectoArar.Models;

public partial class ArardbContext : DbContext
{
    public ArardbContext()
    {
    }

    public ArardbContext(DbContextOptions<ArardbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Alumno> Alumnos { get; set; }

    public virtual DbSet<Asignacione> Asignaciones { get; set; }

    public virtual DbSet<Juego> Juegos { get; set; }

    public virtual DbSet<Progreso> Progresos { get; set; }

    public virtual DbSet<Usuario> Usuarios { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=181014NT1082\\SQLSERVER; Database=ARARDB; Trusted_Connection=True; TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Alumno>(entity =>
        {
            entity.HasKey(e => e.IdAlumno).HasName("PK__Alumnos__6D77A7F1F1D87A0B");

            entity.Property(e => e.IdAlumno)
                .ValueGeneratedNever()
                .HasColumnName("id_alumno");
            entity.Property(e => e.Edad).HasColumnName("edad");
            entity.Property(e => e.IdDocente).HasColumnName("id_docente");
            entity.Property(e => e.InformacionAdicional)
                .HasMaxLength(255)
                .HasColumnName("informacion_adicional");

            entity.HasOne(d => d.IdAlumnoNavigation).WithOne(p => p.AlumnoIdAlumnoNavigation)
                .HasForeignKey<Alumno>(d => d.IdAlumno)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Alumnos_Usuarios");

            entity.HasOne(d => d.IdDocenteNavigation).WithMany(p => p.AlumnoIdDocenteNavigations)
                .HasForeignKey(d => d.IdDocente)
                .HasConstraintName("FK__Alumnos__id_doce__3B75D760");
        });

        modelBuilder.Entity<Asignacione>(entity =>
        {
            entity.HasKey(e => e.IdAsignacion).HasName("PK__Asignaci__C3F7F966E50E07FE");

            entity.Property(e => e.IdAsignacion).HasColumnName("id_asignacion");
            entity.Property(e => e.FechaAsignacion)
                .HasColumnType("datetime")
                .HasColumnName("fecha_asignacion");
            entity.Property(e => e.FechaVencimiento)
                .HasColumnType("datetime")
                .HasColumnName("fecha_vencimiento");
            entity.Property(e => e.IdAlumno).HasColumnName("id_alumno");
            entity.Property(e => e.IdJuego).HasColumnName("id_juego");

            entity.HasOne(d => d.IdAlumnoNavigation).WithMany(p => p.Asignaciones)
                .HasForeignKey(d => d.IdAlumno)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Asignaciones_Alumnos");

            entity.HasOne(d => d.IdJuegoNavigation).WithMany(p => p.Asignaciones)
                .HasForeignKey(d => d.IdJuego)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Asignaciones_Juegos");
        });

        modelBuilder.Entity<Juego>(entity =>
        {
            entity.HasKey(e => e.IdJuego).HasName("PK__Juegos__368EED5005648F8C");

            entity.Property(e => e.IdJuego).HasColumnName("id_juego");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(255)
                .HasColumnName("descripcion");
            entity.Property(e => e.NivelDificultad)
                .HasMaxLength(20)
                .HasColumnName("nivel_dificultad");
            entity.Property(e => e.Nombre)
                .HasMaxLength(100)
                .HasColumnName("nombre");
            entity.Property(e => e.Tipo)
                .HasMaxLength(50)
                .HasColumnName("tipo");
        });

        modelBuilder.Entity<Progreso>(entity =>
        {
            entity.HasKey(e => e.IdProgreso).HasName("PK__Progreso__D5CCDD4BF7AE2472");

            entity.ToTable("Progreso");

            entity.Property(e => e.IdProgreso).HasColumnName("id_progreso");
            entity.Property(e => e.FechaJuego)
                .HasColumnType("datetime")
                .HasColumnName("fecha_juego");
            entity.Property(e => e.IdAsignacion).HasColumnName("id_asignacion");
            entity.Property(e => e.NivelAlcanzado)
                .HasMaxLength(20)
                .HasColumnName("nivel_alcanzado");
            entity.Property(e => e.Puntaje).HasColumnName("puntaje");
            entity.Property(e => e.TiempoJuego).HasColumnName("tiempo_juego");

            entity.HasOne(d => d.IdAsignacionNavigation).WithMany(p => p.Progresos)
                .HasForeignKey(d => d.IdAsignacion)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Progreso_Asignaciones");
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.IdUsuario).HasName("PK__Usuarios__4E3E04ADC7DA5C1C");

            entity.HasIndex(e => e.Email, "UQ__Usuarios__AB6E6164FA3C6454").IsUnique();

            entity.Property(e => e.IdUsuario).HasColumnName("id_usuario");
            entity.Property(e => e.Apellido)
                .HasMaxLength(50)
                .HasColumnName("apellido");
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .HasColumnName("email");
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .HasColumnName("nombre");
            entity.Property(e => e.Password)
                .HasMaxLength(255)
                .HasColumnName("password");
            entity.Property(e => e.Rol)
                .HasMaxLength(20)
                .HasColumnName("rol");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
