using System;
using System.Collections.Generic;
using System.Data;
using Api.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace Api.Context;

public partial class AcmeDbContext : DbContext
{
    public AcmeDbContext()
    {
    }

    public AcmeDbContext(DbContextOptions<AcmeDbContext> options)
        : base(options)
    {
    }

	public Task<SP_MayorSaldoRetiradoPorFecha> GetSP_MayorSaldoRetiradoPorFecha(DateTime fecha)
	{
		var parametros = new[]
		{
				new SqlParameter("@fechaTransaccion", SqlDbType.DateTime) { Value = fecha }
			};

		var result = this.SP_MayorSaldoRetiradoPorFechaResults
							.FromSqlRaw("EXEC SP_MayorSaldoRetiradoPorFecha @fechaTransaccion", parametros)
							.ToList();

		return Task.FromResult(result.FirstOrDefault());
	}

	public Task<SP_SALDO_TOTAL_CLIENTE> GetSP_SALDO_TOTAL_CLIENTE(string IdentificacionPersona)
	{
		var parametros = new[]
{
				new SqlParameter("@IdentificacionPersona", SqlDbType.NVarChar) { Value = IdentificacionPersona}
			};

		var result = this.SP_SALDO_TOTAL_CLIENTEResults
							.FromSqlRaw("EXEC SP_SALDO_TOTAL_CLIENTE @IdentificacionPersona", parametros)
							.ToList();

		return Task.FromResult(result.FirstOrDefault());
	}
	public DbSet<SP_MayorSaldoRetiradoPorFecha> SP_MayorSaldoRetiradoPorFechaResults { get; set; }

	public DbSet<SP_SALDO_TOTAL_CLIENTE> SP_SALDO_TOTAL_CLIENTEResults { get; set; }
	public virtual DbSet<AccionistasTcSaldoTotalDeudum> AccionistasTcSaldoTotalDeuda { get; set; }

    public virtual DbSet<ConsultaDeudaTarjetaPorFranquicium> ConsultaDeudaTarjetaPorFranquicia { get; set; }

    public virtual DbSet<CuentaAhorrosMasCliente> CuentaAhorrosMasClientes { get; set; }

    public virtual DbSet<CuentasActivasClientesExtranjero> CuentasActivasClientesExtranjeros { get; set; }

    public virtual DbSet<MayorSaldoCanje> MayorSaldoCanjes { get; set; }

    public virtual DbSet<TCuentaAhorro> TCuentaAhorros { get; set; }

    public virtual DbSet<TDepartamento> TDepartamentos { get; set; }

    public virtual DbSet<TMovimiento> TMovimientos { get; set; }

    public virtual DbSet<TMunicipio> TMunicipios { get; set; }

    public virtual DbSet<TPersonaInfoExtra> TPersonaInfoExtras { get; set; }

    public virtual DbSet<TPersonaJuridica> TPersonaJuridicas { get; set; }

    public virtual DbSet<TPersonaNatural> TPersonaNaturals { get; set; }

    public virtual DbSet<TProducto> TProductos { get; set; }

    public virtual DbSet<TProductoPersona> TProductoPersonas { get; set; }

    public virtual DbSet<TRol> TRols { get; set; }

    public virtual DbSet<TTarjetaCredito> TTarjetaCreditos { get; set; }

    public virtual DbSet<TTipoEmpresa> TTipoEmpresas { get; set; }

    public virtual DbSet<TTipoFranquicium> TTipoFranquicia { get; set; }

    public virtual DbSet<TTipoIdentificacion> TTipoIdentificacions { get; set; }

    public virtual DbSet<TTipoMovimiento> TTipoMovimientos { get; set; }

    public virtual DbSet<TTipoPersona> TTipoPersonas { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
		modelBuilder.Entity<SP_MayorSaldoRetiradoPorFecha>().HasNoKey();

		modelBuilder.Entity<SP_SALDO_TOTAL_CLIENTE>().HasNoKey();


		modelBuilder.Entity<AccionistasTcSaldoTotalDeudum>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("ACCIONISTAS_TC_SALDO_TOTAL_DEUDA");

            entity.Property(e => e.Nombre)
                .HasMaxLength(1001)
                .IsUnicode(false);
            entity.Property(e => e.NumeroDocumento)
                .HasMaxLength(300)
                .IsUnicode(false);
            entity.Property(e => e.SaldoTotalDeuda).HasColumnType("money");
        });

        modelBuilder.Entity<ConsultaDeudaTarjetaPorFranquicium>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("CONSULTA_DEUDA_TARJETA_POR_FRANQUICIA");

            entity.Property(e => e.Deuda)
                .HasColumnType("money")
                .HasColumnName("DEUDA");
            entity.Property(e => e.TipoFranquicia)
                .HasMaxLength(400)
                .IsUnicode(false);
        });

        modelBuilder.Entity<CuentaAhorrosMasCliente>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("CUENTA_AHORROS_MAS_CLIENTES");

            entity.Property(e => e.CantidadClientes).HasColumnName("CANTIDAD_CLIENTES");
        });

        modelBuilder.Entity<CuentasActivasClientesExtranjero>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("CUENTAS_ACTIVAS_CLIENTES_EXTRANJEROS");

            entity.Property(e => e.CantidadCuentasExtranjerasActivas).HasColumnName("CANTIDAD_CUENTAS_EXTRANJERAS_ACTIVAS");
        });

        modelBuilder.Entity<MayorSaldoCanje>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("MAYOR_SALDO_CANJE");

            entity.Property(e => e.IdentificacionPersona)
                .HasMaxLength(300)
                .IsUnicode(false);
            entity.Property(e => e.NombreCliente)
                .HasMaxLength(1001)
                .IsUnicode(false);
            entity.Property(e => e.SaldoCanjeTotal).HasColumnType("money");
        });

        modelBuilder.Entity<TCuentaAhorro>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__t_Cuenta__3214EC070E05996A");

            entity.ToTable("t_CuentaAhorro");

            entity.Property(e => e.Id).HasDefaultValueSql("(newid())");
            entity.Property(e => e.SaldoCanje).HasColumnType("money");
            entity.Property(e => e.SaldoDisponible).HasColumnType("money");
            entity.Property(e => e.SaldoTotal).HasColumnType("money");
            entity.Property(e => e.TProductoId).HasColumnName("t_ProductoId");

            entity.HasOne(d => d.TProducto).WithMany(p => p.TCuentaAhorros)
                .HasForeignKey(d => d.TProductoId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_t_ProductoIdCuentaAhorro");
        });

        modelBuilder.Entity<TDepartamento>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__t_Depart__3214EC073EB7B37E");

            entity.ToTable("t_Departamento");

            entity.Property(e => e.Id).HasDefaultValueSql("(newid())");
            entity.Property(e => e.Departamento)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<TMovimiento>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__t_Movimi__3214EC0740B4C48B");

            entity.ToTable("t_Movimiento");

            entity.Property(e => e.Id).HasDefaultValueSql("(newid())");
            entity.Property(e => e.FechaMovimiento)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Movimiento).HasColumnType("money");
            entity.Property(e => e.TProductoPersonaId).HasColumnName("t_ProductoPersonaId");
            entity.Property(e => e.TTipoMovimientoId).HasColumnName("t_TipoMovimientoId");

            entity.HasOne(d => d.TProductoPersona).WithMany(p => p.TMovimientos)
                .HasForeignKey(d => d.TProductoPersonaId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_t_ProductoPersonaId");

            entity.HasOne(d => d.TTipoMovimiento).WithMany(p => p.TMovimientos)
                .HasForeignKey(d => d.TTipoMovimientoId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_tipoMovimientoProceso");
        });

        modelBuilder.Entity<TMunicipio>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__t_Munici__3214EC07A585C1A9");

            entity.ToTable("t_Municipio");

            entity.Property(e => e.Id).HasDefaultValueSql("(newid())");
            entity.Property(e => e.Municipio)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.TDepartamentoId).HasColumnName("t_DepartamentoId");

            entity.HasOne(d => d.TDepartamento).WithMany(p => p.TMunicipios)
                .HasForeignKey(d => d.TDepartamentoId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_t_DepartamentoId");
        });

        modelBuilder.Entity<TPersonaInfoExtra>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__t_Person__3214EC0716CE5794");

            entity.ToTable("t_PersonaInfoExtra");

            entity.Property(e => e.Id).HasDefaultValueSql("(newid())");
            entity.Property(e => e.IdentificacionPersona)
                .HasMaxLength(300)
                .IsUnicode(false);
            entity.Property(e => e.TRolId).HasColumnName("t_RolId");
            entity.Property(e => e.TTipoPersonaId).HasColumnName("t_TipoPersonaId");

            entity.HasOne(d => d.TRol).WithMany(p => p.TPersonaInfoExtras)
                .HasForeignKey(d => d.TRolId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_t_RolId");

            entity.HasOne(d => d.TTipoPersona).WithMany(p => p.TPersonaInfoExtras)
                .HasForeignKey(d => d.TTipoPersonaId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_t_TipoPersonaIdPersonaInfoExtra");
        });

        modelBuilder.Entity<TPersonaJuridica>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__t_Person__3214EC076A88AF19");

            entity.ToTable("t_PersonaJuridica");

            entity.HasIndex(e => e.Nit, "UQ__t_Person__C7D1D6DA3853EED6").IsUnique();

            entity.Property(e => e.Id).HasDefaultValueSql("(newid())");
            entity.Property(e => e.Nit)
                .HasMaxLength(300)
                .IsUnicode(false);
            entity.Property(e => e.RazonSocial)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.TTipoEmpresaId).HasColumnName("t_TipoEmpresaId");
            entity.Property(e => e.TTipoPersonaId).HasColumnName("t_TipoPersonaId");

            entity.HasOne(d => d.TTipoEmpresa).WithMany(p => p.TPersonaJuridicas)
                .HasForeignKey(d => d.TTipoEmpresaId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_t_TipoEmpresaId");

            entity.HasOne(d => d.TTipoPersona).WithMany(p => p.TPersonaJuridicas)
                .HasForeignKey(d => d.TTipoPersonaId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_t_TipoPersonaIdPersonaJuridica");
        });

        modelBuilder.Entity<TPersonaNatural>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__t_Person__3214EC07D20F0A45");

            entity.ToTable("t_PersonaNatural");

            entity.HasIndex(e => e.NumeroDocumento, "UQ__t_Person__A42025885CA57634").IsUnique();

            entity.Property(e => e.Id).HasDefaultValueSql("(newid())");
            entity.Property(e => e.Apellidos)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Nombres)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.NumeroDocumento)
                .HasMaxLength(300)
                .IsUnicode(false);
            entity.Property(e => e.TMunicipioId).HasColumnName("t_MunicipioId");
            entity.Property(e => e.TTipoIdentificacionId).HasColumnName("t_TipoIdentificacionId");
            entity.Property(e => e.TTipoPersonaId).HasColumnName("t_TipoPersonaId");

            entity.HasOne(d => d.TMunicipio).WithMany(p => p.TPersonaNaturals)
                .HasForeignKey(d => d.TMunicipioId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_t_MunicipioId");

            entity.HasOne(d => d.TTipoIdentificacion).WithMany(p => p.TPersonaNaturals)
                .HasForeignKey(d => d.TTipoIdentificacionId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_t_TipoIdentificacionPersonaNatural");

            entity.HasOne(d => d.TTipoPersona).WithMany(p => p.TPersonaNaturals)
                .HasForeignKey(d => d.TTipoPersonaId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_t_TipoPersonaIdPersonaNatural");
        });

        modelBuilder.Entity<TProducto>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__t_Produc__3214EC070F255152");

            entity.ToTable("t_Producto");

            entity.Property(e => e.Id).HasDefaultValueSql("(newid())");
            entity.Property(e => e.FechaActualizacion).HasColumnType("datetime");
            entity.Property(e => e.FechaCreacion).HasColumnType("datetime");
        });

        modelBuilder.Entity<TProductoPersona>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__t_Produc__3214EC070E74FA87");

            entity.ToTable("t_ProductoPersona");

            entity.Property(e => e.Id).HasDefaultValueSql("(newid())");
            entity.Property(e => e.TPersonaInfoExtraId).HasColumnName("t_PersonaInfoExtraId");
            entity.Property(e => e.TProductoId).HasColumnName("t_ProductoId");

            entity.HasOne(d => d.TPersonaInfoExtra).WithMany(p => p.TProductoPersonas)
                .HasForeignKey(d => d.TPersonaInfoExtraId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_t_PersonaInfoExtraId");

            entity.HasOne(d => d.TProducto).WithMany(p => p.TProductoPersonas)
                .HasForeignKey(d => d.TProductoId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_t_ProductoIdProductoPersona");
        });

        modelBuilder.Entity<TRol>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__t_Rol__3214EC07A0BE3878");

            entity.ToTable("t_Rol");

            entity.Property(e => e.Id).HasDefaultValueSql("(newid())");
            entity.Property(e => e.Rol)
                .HasMaxLength(150)
                .IsUnicode(false);
        });

        modelBuilder.Entity<TTarjetaCredito>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__t_Tarjet__3214EC077D9AE8ED");

            entity.ToTable("t_TarjetaCredito");

            entity.Property(e => e.Id).HasDefaultValueSql("(newid())");
            entity.Property(e => e.CupoAprobado).HasColumnType("money");
            entity.Property(e => e.CupoDisponible).HasColumnType("money");
            entity.Property(e => e.TProductoId).HasColumnName("t_ProductoId");
            entity.Property(e => e.TTipoFranquicia).HasColumnName("t_TipoFranquicia");

            entity.HasOne(d => d.TProducto).WithMany(p => p.TTarjetaCreditos)
                .HasForeignKey(d => d.TProductoId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_t_ProductoIdTarjetaCredito");

            entity.HasOne(d => d.TTipoFranquiciaNavigation).WithMany(p => p.TTarjetaCreditos)
                .HasForeignKey(d => d.TTipoFranquicia)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_t_TipoFranquiciaIdTarjetaCredito");
        });

        modelBuilder.Entity<TTipoEmpresa>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__t_TipoEm__3214EC0777298C3E");

            entity.ToTable("t_TipoEmpresa");

            entity.Property(e => e.Id).HasDefaultValueSql("(newid())");
            entity.Property(e => e.TipoEmpresa)
                .HasMaxLength(200)
                .IsUnicode(false);
        });

        modelBuilder.Entity<TTipoFranquicium>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__t_TipoFr__3214EC076A227334");

            entity.ToTable("t_TipoFranquicia");

            entity.Property(e => e.Id).HasDefaultValueSql("(newid())");
            entity.Property(e => e.TipoFranquicia)
                .HasMaxLength(400)
                .IsUnicode(false);
        });

        modelBuilder.Entity<TTipoIdentificacion>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__t_TipoId__3214EC0747482BD0");

            entity.ToTable("t_TipoIdentificacion");

            entity.Property(e => e.Id).HasDefaultValueSql("(newid())");
            entity.Property(e => e.TipoIdentificacion)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<TTipoMovimiento>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__t_TipoMo__3214EC0705EE4A26");

            entity.ToTable("t_TipoMovimiento");

            entity.Property(e => e.Id).HasDefaultValueSql("(newid())");
            entity.Property(e => e.TipoMovimiento)
                .HasMaxLength(400)
                .IsUnicode(false);
        });

        modelBuilder.Entity<TTipoPersona>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__t_TipoPe__3214EC07ED95EB70");

            entity.ToTable("t_TipoPersona");

            entity.Property(e => e.Id).HasDefaultValueSql("(newid())");
            entity.Property(e => e.TipoPersona)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
