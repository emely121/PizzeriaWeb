using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using PizzeriaWeb.Models;

namespace PizzeriaWeb.Data;

public partial class PizzeriaContext : DbContext
{
    public PizzeriaContext(DbContextOptions<PizzeriaContext> options)
        : base(options)
    {
    }

    public virtual DbSet<ArticulosCarrito> ArticulosCarritos { get; set; }

    public virtual DbSet<ArticulosPedido> ArticulosPedidos { get; set; }

    public virtual DbSet<Caja> Cajas { get; set; }

    public virtual DbSet<Carrito> Carritos { get; set; }

    public virtual DbSet<Categoria> Categorias { get; set; }

    public virtual DbSet<Cliente> Clientes { get; set; }

    public virtual DbSet<Compra> Compras { get; set; }

    public virtual DbSet<Desperdicio> Desperdicios { get; set; }

    public virtual DbSet<DetalleCompra> DetalleCompras { get; set; }

    public virtual DbSet<Empleado> Empleados { get; set; }

    public virtual DbSet<Factura> Facturas { get; set; }

    public virtual DbSet<FlujoCaja> FlujoCajas { get; set; }

    public virtual DbSet<Gasto> Gastos { get; set; }

    public virtual DbSet<Ingrediente> Ingredientes { get; set; }

    public virtual DbSet<Inventario> Inventarios { get; set; }

    public virtual DbSet<LogAuditorium> LogAuditoria { get; set; }

    public virtual DbSet<Mesa> Mesas { get; set; }

    public virtual DbSet<Modulo> Modulos { get; set; }

    public virtual DbSet<MovimientosInventario> MovimientosInventarios { get; set; }

    public virtual DbSet<Opinione> Opiniones { get; set; }

    public virtual DbSet<Pago> Pagos { get; set; }

    public virtual DbSet<Pedido> Pedidos { get; set; }

    public virtual DbSet<PermisosRol> PermisosRols { get; set; }

    public virtual DbSet<Producto> Productos { get; set; }

    public virtual DbSet<Proveedore> Proveedores { get; set; }

    public virtual DbSet<Receta> Recetas { get; set; }

    public virtual DbSet<Reserva> Reservas { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<Submenu> Submenus { get; set; }

    public virtual DbSet<Sucursale> Sucursales { get; set; }

    public virtual DbSet<TokensRecuperacion> TokensRecuperacions { get; set; }

    public virtual DbSet<Turno> Turnos { get; set; }

    public virtual DbSet<Usuario> Usuarios { get; set; }

    public virtual DbSet<VwEmpleadosTurno> VwEmpleadosTurnos { get; set; }

    public virtual DbSet<VwInventarioPorSucursal> VwInventarioPorSucursals { get; set; }

    public virtual DbSet<VwMasVendido> VwMasVendidos { get; set; }

    public virtual DbSet<VwMenuUsuario> VwMenuUsuarios { get; set; }

    public virtual DbSet<VwPagosPorPedido> VwPagosPorPedidos { get; set; }

    public virtual DbSet<VwPedidosDetalle> VwPedidosDetalles { get; set; }

    public virtual DbSet<VwProductosCatalogo> VwProductosCatalogos { get; set; }

    public virtual DbSet<VwRecetasProducto> VwRecetasProductos { get; set; }

    public virtual DbSet<VwUsuariosRole> VwUsuariosRoles { get; set; }

    public virtual DbSet<VwVentasDiaria> VwVentasDiarias { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .HasPostgresEnum("auth", "aal_level", new[] { "aal1", "aal2", "aal3" })
            .HasPostgresEnum("auth", "code_challenge_method", new[] { "s256", "plain" })
            .HasPostgresEnum("auth", "factor_status", new[] { "unverified", "verified" })
            .HasPostgresEnum("auth", "factor_type", new[] { "totp", "webauthn", "phone", "recovery_code" })
            .HasPostgresEnum("auth", "oauth_authorization_status", new[] { "pending", "approved", "denied", "expired" })
            .HasPostgresEnum("auth", "oauth_client_type", new[] { "public", "confidential" })
            .HasPostgresEnum("auth", "oauth_registration_type", new[] { "dynamic", "manual" })
            .HasPostgresEnum("auth", "oauth_response_type", new[] { "code" })
            .HasPostgresEnum("auth", "one_time_token_type", new[] { "confirmation_token", "reauthentication_token", "recovery_token", "email_change_token_new", "email_change_token_current", "phone_change_token" })
            .HasPostgresEnum("realtime", "action", new[] { "INSERT", "UPDATE", "DELETE", "TRUNCATE", "ERROR" })
            .HasPostgresEnum("realtime", "equality_op", new[] { "eq", "neq", "lt", "lte", "gt", "gte", "in", "like", "ilike", "is", "match", "imatch", "isdistinct" })
            .HasPostgresEnum("storage", "buckettype", new[] { "STANDARD", "ANALYTICS", "VECTOR" })
            .HasPostgresExtension("extensions", "pg_stat_statements")
            .HasPostgresExtension("extensions", "pgcrypto")
            .HasPostgresExtension("extensions", "uuid-ossp")
            .HasPostgresExtension("vault", "supabase_vault");

        modelBuilder.Entity<ArticulosCarrito>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("articulos_carrito_pkey");

            entity.ToTable("articulos_carrito");

            entity.HasIndex(e => new { e.CarritoId, e.ProductoId }, "articulos_carrito_carrito_id_producto_id_key").IsUnique();

            entity.Property(e => e.Id)
                .UseIdentityAlwaysColumn()
                .HasColumnName("id");
            entity.Property(e => e.Cantidad).HasColumnName("cantidad");
            entity.Property(e => e.CarritoId).HasColumnName("carrito_id");
            entity.Property(e => e.PrecioUnitario)
                .HasPrecision(10, 2)
                .HasColumnName("precio_unitario");
            entity.Property(e => e.ProductoId).HasColumnName("producto_id");

            entity.HasOne(d => d.Carrito).WithMany(p => p.ArticulosCarritos)
                .HasForeignKey(d => d.CarritoId)
                .HasConstraintName("articulos_carrito_carrito_id_fkey");

            entity.HasOne(d => d.Producto).WithMany(p => p.ArticulosCarritos)
                .HasForeignKey(d => d.ProductoId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("articulos_carrito_producto_id_fkey");
        });

        modelBuilder.Entity<ArticulosPedido>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("articulos_pedido_pkey");

            entity.ToTable("articulos_pedido");

            entity.HasIndex(e => new { e.PedidoId, e.ProductoId }, "articulos_pedido_pedido_id_producto_id_key").IsUnique();

            entity.HasIndex(e => e.ProductoId, "ix_articulos_pedido_producto");

            entity.Property(e => e.Id)
                .UseIdentityAlwaysColumn()
                .HasColumnName("id");
            entity.Property(e => e.Cantidad).HasColumnName("cantidad");
            entity.Property(e => e.PedidoId).HasColumnName("pedido_id");
            entity.Property(e => e.PrecioUnitario)
                .HasPrecision(10, 2)
                .HasColumnName("precio_unitario");
            entity.Property(e => e.ProductoId).HasColumnName("producto_id");

            entity.HasOne(d => d.Pedido).WithMany(p => p.ArticulosPedidos)
                .HasForeignKey(d => d.PedidoId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("articulos_pedido_pedido_id_fkey");

            entity.HasOne(d => d.Producto).WithMany(p => p.ArticulosPedidos)
                .HasForeignKey(d => d.ProductoId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("articulos_pedido_producto_id_fkey");
        });

        modelBuilder.Entity<Caja>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("cajas_pkey");

            entity.ToTable("cajas");

            entity.HasIndex(e => e.SucursalId, "ux_cajas_abierta_sucursal")
                .IsUnique()
                .HasFilter("((estado)::text = 'Abierta'::text)");

            entity.Property(e => e.Id)
                .UseIdentityAlwaysColumn()
                .HasColumnName("id");
            entity.Property(e => e.Diferencia)
                .HasPrecision(12, 2)
                .HasComputedColumnSql("(monto_cierre - monto_esperado)", true)
                .HasColumnName("diferencia");
            entity.Property(e => e.Estado)
                .HasMaxLength(15)
                .HasDefaultValueSql("'Abierta'::character varying")
                .HasColumnName("estado");
            entity.Property(e => e.FechaApertura)
                .HasDefaultValueSql("now()")
                .HasColumnName("fecha_apertura");
            entity.Property(e => e.FechaCierre).HasColumnName("fecha_cierre");
            entity.Property(e => e.MontoCierre)
                .HasPrecision(12, 2)
                .HasColumnName("monto_cierre");
            entity.Property(e => e.MontoEsperado)
                .HasPrecision(12, 2)
                .HasColumnName("monto_esperado");
            entity.Property(e => e.MontoInicial)
                .HasPrecision(12, 2)
                .HasColumnName("monto_inicial");
            entity.Property(e => e.SucursalId).HasColumnName("sucursal_id");
            entity.Property(e => e.UsuarioAperturaId).HasColumnName("usuario_apertura_id");
            entity.Property(e => e.UsuarioCierreId).HasColumnName("usuario_cierre_id");

            entity.HasOne(d => d.Sucursal).WithOne(p => p.Caja)
                .HasForeignKey<Caja>(d => d.SucursalId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("cajas_sucursal_id_fkey");

            entity.HasOne(d => d.UsuarioApertura).WithMany(p => p.CajaUsuarioAperturas)
                .HasForeignKey(d => d.UsuarioAperturaId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("cajas_usuario_apertura_id_fkey");

            entity.HasOne(d => d.UsuarioCierre).WithMany(p => p.CajaUsuarioCierres)
                .HasForeignKey(d => d.UsuarioCierreId)
                .HasConstraintName("cajas_usuario_cierre_id_fkey");
        });

        modelBuilder.Entity<Carrito>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("carritos_pkey");

            entity.ToTable("carritos");

            entity.HasIndex(e => e.ClienteId, "ux_carritos_cliente_activo")
                .IsUnique()
                .HasFilter("((estado)::text = 'Activo'::text)");

            entity.Property(e => e.Id)
                .UseIdentityAlwaysColumn()
                .HasColumnName("id");
            entity.Property(e => e.ClienteId).HasColumnName("cliente_id");
            entity.Property(e => e.Estado)
                .HasMaxLength(20)
                .HasDefaultValueSql("'Activo'::character varying")
                .HasColumnName("estado");
            entity.Property(e => e.FechaCreacion)
                .HasDefaultValueSql("now()")
                .HasColumnName("fecha_creacion");

            entity.HasOne(d => d.Cliente).WithOne(p => p.Carrito)
                .HasForeignKey<Carrito>(d => d.ClienteId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("carritos_cliente_id_fkey");
        });

        modelBuilder.Entity<Categoria>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("categorias_pkey");

            entity.ToTable("categorias");

            entity.HasIndex(e => e.Nombre, "categorias_nombre_key").IsUnique();

            entity.Property(e => e.Id)
                .UseIdentityAlwaysColumn()
                .HasColumnName("id");
            entity.Property(e => e.Activa)
                .HasDefaultValue(true)
                .HasColumnName("activa");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(200)
                .HasColumnName("descripcion");
            entity.Property(e => e.Nombre)
                .HasMaxLength(60)
                .HasColumnName("nombre");
        });

        modelBuilder.Entity<Cliente>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("clientes_pkey");

            entity.ToTable("clientes");

            entity.HasIndex(e => e.UsuarioId, "clientes_usuario_id_key").IsUnique();

            entity.Property(e => e.Id)
                .UseIdentityAlwaysColumn()
                .HasColumnName("id");
            entity.Property(e => e.Activo)
                .HasDefaultValue(true)
                .HasColumnName("activo");
            entity.Property(e => e.Apellidos)
                .HasMaxLength(80)
                .HasColumnName("apellidos");
            entity.Property(e => e.Correo)
                .HasMaxLength(120)
                .HasColumnName("correo");
            entity.Property(e => e.Direccion)
                .HasMaxLength(250)
                .HasColumnName("direccion");
            entity.Property(e => e.FechaRegistro)
                .HasDefaultValueSql("now()")
                .HasColumnName("fecha_registro");
            entity.Property(e => e.Nombres)
                .HasMaxLength(80)
                .HasColumnName("nombres");
            entity.Property(e => e.Telefono)
                .HasMaxLength(25)
                .HasColumnName("telefono");
            entity.Property(e => e.UsuarioId).HasColumnName("usuario_id");

            entity.HasOne(d => d.Usuario).WithOne(p => p.Cliente)
                .HasForeignKey<Cliente>(d => d.UsuarioId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("clientes_usuario_id_fkey");
        });

        modelBuilder.Entity<Compra>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("compras_pkey");

            entity.ToTable("compras");

            entity.HasIndex(e => e.ProveedorId, "ix_compras_proveedor");

            entity.Property(e => e.Id)
                .UseIdentityAlwaysColumn()
                .HasColumnName("id");
            entity.Property(e => e.Estado)
                .HasMaxLength(20)
                .HasDefaultValueSql("'Recibida'::character varying")
                .HasColumnName("estado");
            entity.Property(e => e.FechaCompra)
                .HasDefaultValueSql("now()")
                .HasColumnName("fecha_compra");
            entity.Property(e => e.NumeroDocumento)
                .HasMaxLength(50)
                .HasColumnName("numero_documento");
            entity.Property(e => e.ProveedorId).HasColumnName("proveedor_id");
            entity.Property(e => e.SucursalId).HasColumnName("sucursal_id");
            entity.Property(e => e.Total)
                .HasPrecision(12, 2)
                .HasColumnName("total");
            entity.Property(e => e.UsuarioId).HasColumnName("usuario_id");

            entity.HasOne(d => d.Proveedor).WithMany(p => p.Compras)
                .HasForeignKey(d => d.ProveedorId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("compras_proveedor_id_fkey");

            entity.HasOne(d => d.Sucursal).WithMany(p => p.Compras)
                .HasForeignKey(d => d.SucursalId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("compras_sucursal_id_fkey");

            entity.HasOne(d => d.Usuario).WithMany(p => p.Compras)
                .HasForeignKey(d => d.UsuarioId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("compras_usuario_id_fkey");
        });

        modelBuilder.Entity<Desperdicio>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("desperdicios_pkey");

            entity.ToTable("desperdicios");

            entity.HasIndex(e => new { e.SucursalId, e.Fecha }, "ix_desperdicios_sucursal_fecha");

            entity.Property(e => e.Id)
                .UseIdentityAlwaysColumn()
                .HasColumnName("id");
            entity.Property(e => e.Cantidad)
                .HasPrecision(12, 3)
                .HasColumnName("cantidad");
            entity.Property(e => e.Fecha)
                .HasDefaultValueSql("now()")
                .HasColumnName("fecha");
            entity.Property(e => e.IngredienteId).HasColumnName("ingrediente_id");
            entity.Property(e => e.Motivo)
                .HasMaxLength(200)
                .HasColumnName("motivo");
            entity.Property(e => e.SucursalId).HasColumnName("sucursal_id");
            entity.Property(e => e.UsuarioId).HasColumnName("usuario_id");

            entity.HasOne(d => d.Ingrediente).WithMany(p => p.Desperdicios)
                .HasForeignKey(d => d.IngredienteId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("desperdicios_ingrediente_id_fkey");

            entity.HasOne(d => d.Sucursal).WithMany(p => p.Desperdicios)
                .HasForeignKey(d => d.SucursalId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("desperdicios_sucursal_id_fkey");

            entity.HasOne(d => d.Usuario).WithMany(p => p.Desperdicios)
                .HasForeignKey(d => d.UsuarioId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("desperdicios_usuario_id_fkey");
        });

        modelBuilder.Entity<DetalleCompra>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("detalle_compra_pkey");

            entity.ToTable("detalle_compra");

            entity.HasIndex(e => e.CompraId, "ix_detalle_compra_compra");

            entity.Property(e => e.Id)
                .UseIdentityAlwaysColumn()
                .HasColumnName("id");
            entity.Property(e => e.Cantidad)
                .HasPrecision(12, 3)
                .HasColumnName("cantidad");
            entity.Property(e => e.CompraId).HasColumnName("compra_id");
            entity.Property(e => e.CostoUnitario)
                .HasPrecision(12, 2)
                .HasColumnName("costo_unitario");
            entity.Property(e => e.IngredienteId).HasColumnName("ingrediente_id");

            entity.HasOne(d => d.Compra).WithMany(p => p.DetalleCompras)
                .HasForeignKey(d => d.CompraId)
                .HasConstraintName("detalle_compra_compra_id_fkey");

            entity.HasOne(d => d.Ingrediente).WithMany(p => p.DetalleCompras)
                .HasForeignKey(d => d.IngredienteId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("detalle_compra_ingrediente_id_fkey");
        });

        modelBuilder.Entity<Empleado>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("empleados_pkey");

            entity.ToTable("empleados");

            entity.HasIndex(e => e.UsuarioId, "empleados_usuario_id_key").IsUnique();

            entity.HasIndex(e => e.SucursalId, "ix_empleados_sucursal");

            entity.Property(e => e.Id)
                .UseIdentityAlwaysColumn()
                .HasColumnName("id");
            entity.Property(e => e.Activo)
                .HasDefaultValue(true)
                .HasColumnName("activo");
            entity.Property(e => e.Apellidos)
                .HasMaxLength(80)
                .HasColumnName("apellidos");
            entity.Property(e => e.FechaContratacion)
                .HasDefaultValueSql("CURRENT_DATE")
                .HasColumnName("fecha_contratacion");
            entity.Property(e => e.Nombres)
                .HasMaxLength(80)
                .HasColumnName("nombres");
            entity.Property(e => e.Puesto)
                .HasMaxLength(50)
                .HasColumnName("puesto");
            entity.Property(e => e.SucursalId).HasColumnName("sucursal_id");
            entity.Property(e => e.Telefono)
                .HasMaxLength(25)
                .HasColumnName("telefono");
            entity.Property(e => e.UsuarioId).HasColumnName("usuario_id");

            entity.HasOne(d => d.Sucursal).WithMany(p => p.Empleados)
                .HasForeignKey(d => d.SucursalId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("empleados_sucursal_id_fkey");

            entity.HasOne(d => d.Usuario).WithOne(p => p.Empleado)
                .HasForeignKey<Empleado>(d => d.UsuarioId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("empleados_usuario_id_fkey");
        });

        modelBuilder.Entity<Factura>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("facturas_pkey");

            entity.ToTable("facturas");

            entity.HasIndex(e => e.Numero, "facturas_numero_key").IsUnique();

            entity.HasIndex(e => e.PedidoId, "facturas_pedido_id_key").IsUnique();

            entity.Property(e => e.Id)
                .UseIdentityAlwaysColumn()
                .HasColumnName("id");
            entity.Property(e => e.Descuento)
                .HasPrecision(12, 2)
                .HasColumnName("descuento");
            entity.Property(e => e.Estado)
                .HasMaxLength(20)
                .HasDefaultValueSql("'Emitida'::character varying")
                .HasColumnName("estado");
            entity.Property(e => e.FechaEmision)
                .HasDefaultValueSql("now()")
                .HasColumnName("fecha_emision");
            entity.Property(e => e.Numero)
                .HasMaxLength(30)
                .HasColumnName("numero");
            entity.Property(e => e.PedidoId).HasColumnName("pedido_id");
            entity.Property(e => e.Subtotal)
                .HasPrecision(12, 2)
                .HasColumnName("subtotal");
            entity.Property(e => e.Total)
                .HasPrecision(12, 2)
                .HasColumnName("total");

            entity.HasOne(d => d.Pedido).WithOne(p => p.Factura)
                .HasForeignKey<Factura>(d => d.PedidoId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("facturas_pedido_id_fkey");
        });

        modelBuilder.Entity<FlujoCaja>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("flujo_caja_pkey");

            entity.ToTable("flujo_caja");

            entity.HasIndex(e => e.CajaId, "ix_flujo_caja_caja");

            entity.Property(e => e.Id)
                .UseIdentityAlwaysColumn()
                .HasColumnName("id");
            entity.Property(e => e.CajaId).HasColumnName("caja_id");
            entity.Property(e => e.Concepto)
                .HasMaxLength(150)
                .HasColumnName("concepto");
            entity.Property(e => e.Fecha)
                .HasDefaultValueSql("now()")
                .HasColumnName("fecha");
            entity.Property(e => e.MetodoPago)
                .HasMaxLength(20)
                .HasDefaultValueSql("'Efectivo'::character varying")
                .HasColumnName("metodo_pago");
            entity.Property(e => e.Monto)
                .HasPrecision(12, 2)
                .HasColumnName("monto");
            entity.Property(e => e.PedidoId).HasColumnName("pedido_id");
            entity.Property(e => e.SucursalId).HasColumnName("sucursal_id");
            entity.Property(e => e.TipoMovimiento)
                .HasMaxLength(15)
                .HasColumnName("tipo_movimiento");
            entity.Property(e => e.UsuarioId).HasColumnName("usuario_id");

            entity.HasOne(d => d.Caja).WithMany(p => p.FlujoCajas)
                .HasForeignKey(d => d.CajaId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("flujo_caja_caja_id_fkey");

            entity.HasOne(d => d.Pedido).WithMany(p => p.FlujoCajas)
                .HasForeignKey(d => d.PedidoId)
                .HasConstraintName("flujo_caja_pedido_id_fkey");

            entity.HasOne(d => d.Sucursal).WithMany(p => p.FlujoCajas)
                .HasForeignKey(d => d.SucursalId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("flujo_caja_sucursal_id_fkey");

            entity.HasOne(d => d.Usuario).WithMany(p => p.FlujoCajas)
                .HasForeignKey(d => d.UsuarioId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("flujo_caja_usuario_id_fkey");
        });

        modelBuilder.Entity<Gasto>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("gastos_pkey");

            entity.ToTable("gastos");

            entity.HasIndex(e => new { e.SucursalId, e.FechaGasto }, "ix_gastos_sucursal_fecha");

            entity.Property(e => e.Id)
                .UseIdentityAlwaysColumn()
                .HasColumnName("id");
            entity.Property(e => e.CajaId).HasColumnName("caja_id");
            entity.Property(e => e.Categoria)
                .HasMaxLength(50)
                .HasColumnName("categoria");
            entity.Property(e => e.Concepto)
                .HasMaxLength(150)
                .HasColumnName("concepto");
            entity.Property(e => e.FechaGasto)
                .HasDefaultValueSql("CURRENT_DATE")
                .HasColumnName("fecha_gasto");
            entity.Property(e => e.Monto)
                .HasPrecision(12, 2)
                .HasColumnName("monto");
            entity.Property(e => e.Observaciones)
                .HasMaxLength(250)
                .HasColumnName("observaciones");
            entity.Property(e => e.SucursalId).HasColumnName("sucursal_id");
            entity.Property(e => e.UsuarioId).HasColumnName("usuario_id");

            entity.HasOne(d => d.Caja).WithMany(p => p.Gastos)
                .HasForeignKey(d => d.CajaId)
                .HasConstraintName("gastos_caja_id_fkey");

            entity.HasOne(d => d.Sucursal).WithMany(p => p.Gastos)
                .HasForeignKey(d => d.SucursalId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("gastos_sucursal_id_fkey");

            entity.HasOne(d => d.Usuario).WithMany(p => p.Gastos)
                .HasForeignKey(d => d.UsuarioId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("gastos_usuario_id_fkey");
        });

        modelBuilder.Entity<Ingrediente>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("ingredientes_pkey");

            entity.ToTable("ingredientes");

            entity.HasIndex(e => e.Nombre, "ingredientes_nombre_key").IsUnique();

            entity.Property(e => e.Id)
                .UseIdentityAlwaysColumn()
                .HasColumnName("id");
            entity.Property(e => e.Activo)
                .HasDefaultValue(true)
                .HasColumnName("activo");
            entity.Property(e => e.Nombre)
                .HasMaxLength(100)
                .HasColumnName("nombre");
            entity.Property(e => e.StockMinimo)
                .HasPrecision(12, 3)
                .HasColumnName("stock_minimo");
            entity.Property(e => e.UnidadMedida)
                .HasMaxLength(20)
                .HasColumnName("unidad_medida");
        });

        modelBuilder.Entity<Inventario>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("inventario_pkey");

            entity.ToTable("inventario");

            entity.HasIndex(e => new { e.SucursalId, e.IngredienteId }, "inventario_sucursal_id_ingrediente_id_key").IsUnique();

            entity.HasIndex(e => e.IngredienteId, "ix_inventario_ingrediente");

            entity.Property(e => e.Id)
                .UseIdentityAlwaysColumn()
                .HasColumnName("id");
            entity.Property(e => e.Existencia)
                .HasPrecision(12, 3)
                .HasColumnName("existencia");
            entity.Property(e => e.FechaActualizacion)
                .HasDefaultValueSql("now()")
                .HasColumnName("fecha_actualizacion");
            entity.Property(e => e.IngredienteId).HasColumnName("ingrediente_id");
            entity.Property(e => e.SucursalId).HasColumnName("sucursal_id");

            entity.HasOne(d => d.Ingrediente).WithMany(p => p.Inventarios)
                .HasForeignKey(d => d.IngredienteId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("inventario_ingrediente_id_fkey");

            entity.HasOne(d => d.Sucursal).WithMany(p => p.Inventarios)
                .HasForeignKey(d => d.SucursalId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("inventario_sucursal_id_fkey");
        });

        modelBuilder.Entity<LogAuditorium>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("log_auditoria_pkey");

            entity.ToTable("log_auditoria");

            entity.HasIndex(e => e.FechaHora, "ix_log_auditoria_fecha");

            entity.Property(e => e.Id)
                .UseIdentityAlwaysColumn()
                .HasColumnName("id");
            entity.Property(e => e.Accion)
                .HasMaxLength(30)
                .HasColumnName("accion");
            entity.Property(e => e.Detalle)
                .HasMaxLength(1000)
                .HasColumnName("detalle");
            entity.Property(e => e.DireccionIp)
                .HasMaxLength(45)
                .HasColumnName("direccion_ip");
            entity.Property(e => e.FechaHora)
                .HasDefaultValueSql("now()")
                .HasColumnName("fecha_hora");
            entity.Property(e => e.RegistroId)
                .HasMaxLength(80)
                .HasColumnName("registro_id");
            entity.Property(e => e.TablaAfectada)
                .HasMaxLength(63)
                .HasColumnName("tabla_afectada");
            entity.Property(e => e.UsuarioId).HasColumnName("usuario_id");

            entity.HasOne(d => d.Usuario).WithMany(p => p.LogAuditoria)
                .HasForeignKey(d => d.UsuarioId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("log_auditoria_usuario_id_fkey");
        });

        modelBuilder.Entity<Mesa>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("mesas_pkey");

            entity.ToTable("mesas");

            entity.HasIndex(e => new { e.SucursalId, e.Numero }, "mesas_sucursal_id_numero_key").IsUnique();

            entity.Property(e => e.Id)
                .UseIdentityAlwaysColumn()
                .HasColumnName("id");
            entity.Property(e => e.Capacidad)
                .HasDefaultValue((short)4)
                .HasColumnName("capacidad");
            entity.Property(e => e.Estado)
                .HasMaxLength(20)
                .HasDefaultValueSql("'Disponible'::character varying")
                .HasColumnName("estado");
            entity.Property(e => e.Numero).HasColumnName("numero");
            entity.Property(e => e.SucursalId).HasColumnName("sucursal_id");

            entity.HasOne(d => d.Sucursal).WithMany(p => p.Mesas)
                .HasForeignKey(d => d.SucursalId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("mesas_sucursal_id_fkey");
        });

        modelBuilder.Entity<Modulo>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("modulos_pkey");

            entity.ToTable("modulos");

            entity.HasIndex(e => e.Nombre, "modulos_nombre_key").IsUnique();

            entity.Property(e => e.Id)
                .UseIdentityAlwaysColumn()
                .HasColumnName("id");
            entity.Property(e => e.Activo)
                .HasDefaultValue(true)
                .HasColumnName("activo");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(200)
                .HasColumnName("descripcion");
            entity.Property(e => e.Icono)
                .HasMaxLength(50)
                .HasColumnName("icono");
            entity.Property(e => e.Nombre)
                .HasMaxLength(60)
                .HasColumnName("nombre");
            entity.Property(e => e.Orden).HasColumnName("orden");
        });

        modelBuilder.Entity<MovimientosInventario>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("movimientos_inventario_pkey");

            entity.ToTable("movimientos_inventario");

            entity.HasIndex(e => new { e.SucursalId, e.IngredienteId, e.Fecha }, "ix_mov_inv_sucursal_ing_fecha");

            entity.Property(e => e.Id)
                .UseIdentityAlwaysColumn()
                .HasColumnName("id");
            entity.Property(e => e.Cantidad)
                .HasPrecision(12, 3)
                .HasColumnName("cantidad");
            entity.Property(e => e.Fecha)
                .HasDefaultValueSql("now()")
                .HasColumnName("fecha");
            entity.Property(e => e.IngredienteId).HasColumnName("ingrediente_id");
            entity.Property(e => e.Referencia)
                .HasMaxLength(100)
                .HasColumnName("referencia");
            entity.Property(e => e.SucursalId).HasColumnName("sucursal_id");
            entity.Property(e => e.TipoMovimiento)
                .HasMaxLength(20)
                .HasColumnName("tipo_movimiento");
            entity.Property(e => e.UsuarioId).HasColumnName("usuario_id");

            entity.HasOne(d => d.Ingrediente).WithMany(p => p.MovimientosInventarios)
                .HasForeignKey(d => d.IngredienteId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("movimientos_inventario_ingrediente_id_fkey");

            entity.HasOne(d => d.Sucursal).WithMany(p => p.MovimientosInventarios)
                .HasForeignKey(d => d.SucursalId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("movimientos_inventario_sucursal_id_fkey");

            entity.HasOne(d => d.Usuario).WithMany(p => p.MovimientosInventarios)
                .HasForeignKey(d => d.UsuarioId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("movimientos_inventario_usuario_id_fkey");
        });

        modelBuilder.Entity<Opinione>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("opiniones_pkey");

            entity.ToTable("opiniones");

            entity.HasIndex(e => e.PedidoId, "opiniones_pedido_id_key").IsUnique();

            entity.Property(e => e.Id)
                .UseIdentityAlwaysColumn()
                .HasColumnName("id");
            entity.Property(e => e.Calificacion).HasColumnName("calificacion");
            entity.Property(e => e.ClienteId).HasColumnName("cliente_id");
            entity.Property(e => e.Comentario)
                .HasMaxLength(500)
                .HasColumnName("comentario");
            entity.Property(e => e.Fecha)
                .HasDefaultValueSql("now()")
                .HasColumnName("fecha");
            entity.Property(e => e.PedidoId).HasColumnName("pedido_id");

            entity.HasOne(d => d.Cliente).WithMany(p => p.Opiniones)
                .HasForeignKey(d => d.ClienteId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("opiniones_cliente_id_fkey");

            entity.HasOne(d => d.Pedido).WithOne(p => p.Opinione)
                .HasForeignKey<Opinione>(d => d.PedidoId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("opiniones_pedido_id_fkey");
        });

        modelBuilder.Entity<Pago>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("pagos_pkey");

            entity.ToTable("pagos");

            entity.HasIndex(e => new { e.PedidoId, e.Estado }, "ix_pagos_pedido");

            entity.Property(e => e.Id)
                .UseIdentityAlwaysColumn()
                .HasColumnName("id");
            entity.Property(e => e.Estado)
                .HasMaxLength(20)
                .HasDefaultValueSql("'Confirmado'::character varying")
                .HasColumnName("estado");
            entity.Property(e => e.FechaPago)
                .HasDefaultValueSql("now()")
                .HasColumnName("fecha_pago");
            entity.Property(e => e.MetodoPago)
                .HasMaxLength(20)
                .HasColumnName("metodo_pago");
            entity.Property(e => e.Monto)
                .HasPrecision(12, 2)
                .HasColumnName("monto");
            entity.Property(e => e.PedidoId).HasColumnName("pedido_id");
            entity.Property(e => e.Referencia)
                .HasMaxLength(80)
                .HasColumnName("referencia");

            entity.HasOne(d => d.Pedido).WithMany(p => p.Pagos)
                .HasForeignKey(d => d.PedidoId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("pagos_pedido_id_fkey");
        });

        modelBuilder.Entity<Pedido>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("pedidos_pkey");

            entity.ToTable("pedidos");

            entity.HasIndex(e => e.ClienteId, "ix_pedidos_cliente");

            entity.HasIndex(e => new { e.FechaPedido, e.Estado }, "ix_pedidos_fecha_estado");

            entity.HasIndex(e => new { e.SucursalId, e.FechaPedido }, "ix_pedidos_sucursal_fecha");

            entity.Property(e => e.Id)
                .UseIdentityAlwaysColumn()
                .HasColumnName("id");
            entity.Property(e => e.ClienteId).HasColumnName("cliente_id");
            entity.Property(e => e.Descuento)
                .HasPrecision(12, 2)
                .HasColumnName("descuento");
            entity.Property(e => e.DireccionEntrega)
                .HasMaxLength(250)
                .HasColumnName("direccion_entrega");
            entity.Property(e => e.Estado)
                .HasMaxLength(20)
                .HasDefaultValueSql("'Recibido'::character varying")
                .HasColumnName("estado");
            entity.Property(e => e.FechaPedido)
                .HasDefaultValueSql("now()")
                .HasColumnName("fecha_pedido");
            entity.Property(e => e.MesaId).HasColumnName("mesa_id");
            entity.Property(e => e.Observaciones)
                .HasMaxLength(250)
                .HasColumnName("observaciones");
            entity.Property(e => e.RepartidorId).HasColumnName("repartidor_id");
            entity.Property(e => e.Subtotal)
                .HasPrecision(12, 2)
                .HasColumnName("subtotal");
            entity.Property(e => e.SucursalId).HasColumnName("sucursal_id");
            entity.Property(e => e.TipoServicio)
                .HasMaxLength(20)
                .HasColumnName("tipo_servicio");
            entity.Property(e => e.Total)
                .HasPrecision(12, 2)
                .HasComputedColumnSql("(subtotal - descuento)", true)
                .HasColumnName("total");
            entity.Property(e => e.UsuarioRegistroId).HasColumnName("usuario_registro_id");

            entity.HasOne(d => d.Cliente).WithMany(p => p.Pedidos)
                .HasForeignKey(d => d.ClienteId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("pedidos_cliente_id_fkey");

            entity.HasOne(d => d.Mesa).WithMany(p => p.Pedidos)
                .HasForeignKey(d => d.MesaId)
                .HasConstraintName("pedidos_mesa_id_fkey");

            entity.HasOne(d => d.Repartidor).WithMany(p => p.Pedidos)
                .HasForeignKey(d => d.RepartidorId)
                .HasConstraintName("pedidos_repartidor_id_fkey");

            entity.HasOne(d => d.Sucursal).WithMany(p => p.Pedidos)
                .HasForeignKey(d => d.SucursalId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("pedidos_sucursal_id_fkey");

            entity.HasOne(d => d.UsuarioRegistro).WithMany(p => p.Pedidos)
                .HasForeignKey(d => d.UsuarioRegistroId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("pedidos_usuario_registro_id_fkey");
        });

        modelBuilder.Entity<PermisosRol>(entity =>
        {
            entity.HasKey(e => new { e.RolId, e.SubmenuId }).HasName("permisos_rol_pkey");

            entity.ToTable("permisos_rol");

            entity.Property(e => e.RolId).HasColumnName("rol_id");
            entity.Property(e => e.SubmenuId).HasColumnName("submenu_id");
            entity.Property(e => e.PuedeConsultar).HasColumnName("puede_consultar");
            entity.Property(e => e.PuedeEditar).HasColumnName("puede_editar");
            entity.Property(e => e.PuedeEliminar).HasColumnName("puede_eliminar");
            entity.Property(e => e.PuedeInsertar).HasColumnName("puede_insertar");

            entity.HasOne(d => d.Rol).WithMany(p => p.PermisosRols)
                .HasForeignKey(d => d.RolId)
                .HasConstraintName("permisos_rol_rol_id_fkey");

            entity.HasOne(d => d.Submenu).WithMany(p => p.PermisosRols)
                .HasForeignKey(d => d.SubmenuId)
                .HasConstraintName("permisos_rol_submenu_id_fkey");
        });

        modelBuilder.Entity<Producto>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("productos_pkey");

            entity.ToTable("productos");

            entity.HasIndex(e => e.CategoriaId, "ix_productos_categoria");

            entity.HasIndex(e => e.Nombre, "productos_nombre_key").IsUnique();

            entity.Property(e => e.Id)
                .UseIdentityAlwaysColumn()
                .HasColumnName("id");
            entity.Property(e => e.CategoriaId).HasColumnName("categoria_id");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(250)
                .HasColumnName("descripcion");
            entity.Property(e => e.Disponible)
                .HasDefaultValue(true)
                .HasColumnName("disponible");
            entity.Property(e => e.ImagenUrl)
                .HasMaxLength(300)
                .HasColumnName("imagen_url");
            entity.Property(e => e.Nombre)
                .HasMaxLength(100)
                .HasColumnName("nombre");
            entity.Property(e => e.Precio)
                .HasPrecision(10, 2)
                .HasColumnName("precio");
            entity.Property(e => e.Tipo)
                .HasMaxLength(20)
                .HasDefaultValueSql("'Normal'::character varying")
                .HasColumnName("tipo");

            entity.HasOne(d => d.Categoria).WithMany(p => p.Productos)
                .HasForeignKey(d => d.CategoriaId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("productos_categoria_id_fkey");
        });

        modelBuilder.Entity<Proveedore>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("proveedores_pkey");

            entity.ToTable("proveedores");

            entity.Property(e => e.Id)
                .UseIdentityAlwaysColumn()
                .HasColumnName("id");
            entity.Property(e => e.Activo)
                .HasDefaultValue(true)
                .HasColumnName("activo");
            entity.Property(e => e.Contacto)
                .HasMaxLength(100)
                .HasColumnName("contacto");
            entity.Property(e => e.Correo)
                .HasMaxLength(120)
                .HasColumnName("correo");
            entity.Property(e => e.Direccion)
                .HasMaxLength(200)
                .HasColumnName("direccion");
            entity.Property(e => e.Nombre)
                .HasMaxLength(120)
                .HasColumnName("nombre");
            entity.Property(e => e.Telefono)
                .HasMaxLength(25)
                .HasColumnName("telefono");
        });

        modelBuilder.Entity<Receta>(entity =>
        {
            entity.HasKey(e => new { e.ProductoId, e.IngredienteId }).HasName("recetas_pkey");

            entity.ToTable("recetas");

            entity.HasIndex(e => e.IngredienteId, "ix_recetas_ingrediente");

            entity.Property(e => e.ProductoId).HasColumnName("producto_id");
            entity.Property(e => e.IngredienteId).HasColumnName("ingrediente_id");
            entity.Property(e => e.Cantidad)
                .HasPrecision(12, 3)
                .HasColumnName("cantidad");

            entity.HasOne(d => d.Ingrediente).WithMany(p => p.Receta)
                .HasForeignKey(d => d.IngredienteId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("recetas_ingrediente_id_fkey");

            entity.HasOne(d => d.Producto).WithMany(p => p.Receta)
                .HasForeignKey(d => d.ProductoId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("recetas_producto_id_fkey");
        });

        modelBuilder.Entity<Reserva>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("reservas_pkey");

            entity.ToTable("reservas");

            entity.HasIndex(e => e.ClienteId, "ix_reservas_cliente");

            entity.HasIndex(e => new { e.MesaId, e.FechaHora }, "ux_reservas_mesa_hora")
                .IsUnique()
                .HasFilter("((estado)::text = ANY ((ARRAY['Pendiente'::character varying, 'Confirmada'::character varying])::text[]))");

            entity.Property(e => e.Id)
                .UseIdentityAlwaysColumn()
                .HasColumnName("id");
            entity.Property(e => e.CantidadPersonas).HasColumnName("cantidad_personas");
            entity.Property(e => e.ClienteId).HasColumnName("cliente_id");
            entity.Property(e => e.Estado)
                .HasMaxLength(20)
                .HasDefaultValueSql("'Pendiente'::character varying")
                .HasColumnName("estado");
            entity.Property(e => e.FechaHora).HasColumnName("fecha_hora");
            entity.Property(e => e.MesaId).HasColumnName("mesa_id");
            entity.Property(e => e.Observaciones)
                .HasMaxLength(250)
                .HasColumnName("observaciones");

            entity.HasOne(d => d.Cliente).WithMany(p => p.Reservas)
                .HasForeignKey(d => d.ClienteId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("reservas_cliente_id_fkey");

            entity.HasOne(d => d.Mesa).WithMany(p => p.Reservas)
                .HasForeignKey(d => d.MesaId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("reservas_mesa_id_fkey");
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("roles_pkey");

            entity.ToTable("roles");

            entity.HasIndex(e => e.Nombre, "roles_nombre_key").IsUnique();

            entity.Property(e => e.Id)
                .UseIdentityAlwaysColumn()
                .HasColumnName("id");
            entity.Property(e => e.Activo)
                .HasDefaultValue(true)
                .HasColumnName("activo");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(200)
                .HasColumnName("descripcion");
            entity.Property(e => e.Nombre)
                .HasMaxLength(40)
                .HasColumnName("nombre");
        });

        modelBuilder.Entity<Submenu>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("submenus_pkey");

            entity.ToTable("submenus");

            entity.HasIndex(e => new { e.ModuloId, e.Nombre }, "submenus_modulo_id_nombre_key").IsUnique();

            entity.Property(e => e.Id)
                .UseIdentityAlwaysColumn()
                .HasColumnName("id");
            entity.Property(e => e.Activo)
                .HasDefaultValue(true)
                .HasColumnName("activo");
            entity.Property(e => e.ModuloId).HasColumnName("modulo_id");
            entity.Property(e => e.Nombre)
                .HasMaxLength(60)
                .HasColumnName("nombre");
            entity.Property(e => e.Orden).HasColumnName("orden");
            entity.Property(e => e.Ruta)
                .HasMaxLength(150)
                .HasColumnName("ruta");

            entity.HasOne(d => d.Modulo).WithMany(p => p.Submenus)
                .HasForeignKey(d => d.ModuloId)
                .HasConstraintName("submenus_modulo_id_fkey");
        });

        modelBuilder.Entity<Sucursale>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("sucursales_pkey");

            entity.ToTable("sucursales");

            entity.HasIndex(e => e.Nombre, "sucursales_nombre_key").IsUnique();

            entity.Property(e => e.Id)
                .UseIdentityAlwaysColumn()
                .HasColumnName("id");
            entity.Property(e => e.Activa)
                .HasDefaultValue(true)
                .HasColumnName("activa");
            entity.Property(e => e.Direccion)
                .HasMaxLength(200)
                .HasColumnName("direccion");
            entity.Property(e => e.Nombre)
                .HasMaxLength(100)
                .HasColumnName("nombre");
            entity.Property(e => e.Telefono)
                .HasMaxLength(25)
                .HasColumnName("telefono");
        });

        modelBuilder.Entity<TokensRecuperacion>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("tokens_recuperacion_pkey");

            entity.ToTable("tokens_recuperacion");

            entity.Property(e => e.Id)
                .UseIdentityAlwaysColumn()
                .HasColumnName("id");
            entity.Property(e => e.FechaExpiracion).HasColumnName("fecha_expiracion");
            entity.Property(e => e.TokenHash)
                .HasMaxLength(255)
                .HasColumnName("token_hash");
            entity.Property(e => e.Usado).HasColumnName("usado");
            entity.Property(e => e.UsuarioId).HasColumnName("usuario_id");

            entity.HasOne(d => d.Usuario).WithMany(p => p.TokensRecuperacions)
                .HasForeignKey(d => d.UsuarioId)
                .HasConstraintName("tokens_recuperacion_usuario_id_fkey");
        });

        modelBuilder.Entity<Turno>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("turnos_pkey");

            entity.ToTable("turnos");

            entity.HasIndex(e => new { e.EmpleadoId, e.Fecha }, "ix_turnos_empleado_fecha");

            entity.Property(e => e.Id)
                .UseIdentityAlwaysColumn()
                .HasColumnName("id");
            entity.Property(e => e.EmpleadoId).HasColumnName("empleado_id");
            entity.Property(e => e.Estado)
                .HasMaxLength(20)
                .HasDefaultValueSql("'Programado'::character varying")
                .HasColumnName("estado");
            entity.Property(e => e.Fecha).HasColumnName("fecha");
            entity.Property(e => e.HoraEntrada)
                .HasPrecision(0)
                .HasColumnName("hora_entrada");
            entity.Property(e => e.HoraSalida)
                .HasPrecision(0)
                .HasColumnName("hora_salida");
            entity.Property(e => e.SucursalId).HasColumnName("sucursal_id");

            entity.HasOne(d => d.Empleado).WithMany(p => p.Turnos)
                .HasForeignKey(d => d.EmpleadoId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("turnos_empleado_id_fkey");

            entity.HasOne(d => d.Sucursal).WithMany(p => p.Turnos)
                .HasForeignKey(d => d.SucursalId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("turnos_sucursal_id_fkey");
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("usuarios_pkey");

            entity.ToTable("usuarios");

            entity.HasIndex(e => e.RolId, "ix_usuarios_rol");

            entity.Property(e => e.Id)
                .UseIdentityAlwaysColumn()
                .HasColumnName("id");
            entity.Property(e => e.Activo)
                .HasDefaultValue(true)
                .HasColumnName("activo");
            entity.Property(e => e.BloqueadoHasta).HasColumnName("bloqueado_hasta");
            entity.Property(e => e.Correo)
                .HasMaxLength(120)
                .HasColumnName("correo");
            entity.Property(e => e.FechaCreacion)
                .HasDefaultValueSql("now()")
                .HasColumnName("fecha_creacion");
            entity.Property(e => e.IntentosFallidos).HasColumnName("intentos_fallidos");
            entity.Property(e => e.NombreCompleto)
                .HasMaxLength(120)
                .HasColumnName("nombre_completo");
            entity.Property(e => e.NombreUsuario)
                .HasMaxLength(50)
                .HasColumnName("nombre_usuario");
            entity.Property(e => e.PasswordHash)
                .HasMaxLength(255)
                .HasColumnName("password_hash");
            entity.Property(e => e.RolId).HasColumnName("rol_id");
            entity.Property(e => e.UltimoAcceso).HasColumnName("ultimo_acceso");

            entity.HasOne(d => d.Rol).WithMany(p => p.Usuarios)
                .HasForeignKey(d => d.RolId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("usuarios_rol_id_fkey");
        });

        modelBuilder.Entity<VwEmpleadosTurno>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vw_empleados_turnos")
                .HasAnnotation("Npgsql:StorageParameter:security_invoker", "true");

            entity.Property(e => e.Empleado).HasColumnName("empleado");
            entity.Property(e => e.EmpleadoId).HasColumnName("empleado_id");
            entity.Property(e => e.EstadoTurno)
                .HasMaxLength(20)
                .HasColumnName("estado_turno");
            entity.Property(e => e.Fecha).HasColumnName("fecha");
            entity.Property(e => e.HoraEntrada)
                .HasPrecision(0)
                .HasColumnName("hora_entrada");
            entity.Property(e => e.HoraSalida)
                .HasPrecision(0)
                .HasColumnName("hora_salida");
            entity.Property(e => e.Puesto)
                .HasMaxLength(50)
                .HasColumnName("puesto");
            entity.Property(e => e.Sucursal)
                .HasMaxLength(100)
                .HasColumnName("sucursal");
        });

        modelBuilder.Entity<VwInventarioPorSucursal>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vw_inventario_por_sucursal")
                .HasAnnotation("Npgsql:StorageParameter:security_invoker", "true");

            entity.Property(e => e.EstadoStock).HasColumnName("estado_stock");
            entity.Property(e => e.Existencia)
                .HasPrecision(12, 3)
                .HasColumnName("existencia");
            entity.Property(e => e.Ingrediente)
                .HasMaxLength(100)
                .HasColumnName("ingrediente");
            entity.Property(e => e.StockMinimo)
                .HasPrecision(12, 3)
                .HasColumnName("stock_minimo");
            entity.Property(e => e.Sucursal)
                .HasMaxLength(100)
                .HasColumnName("sucursal");
            entity.Property(e => e.UnidadMedida)
                .HasMaxLength(20)
                .HasColumnName("unidad_medida");
        });

        modelBuilder.Entity<VwMasVendido>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vw_mas_vendidos")
                .HasAnnotation("Npgsql:StorageParameter:security_invoker", "true");

            entity.Property(e => e.Categoria)
                .HasMaxLength(60)
                .HasColumnName("categoria");
            entity.Property(e => e.Ingresos)
                .HasPrecision(14, 2)
                .HasColumnName("ingresos");
            entity.Property(e => e.Producto)
                .HasMaxLength(100)
                .HasColumnName("producto");
            entity.Property(e => e.ProductoId).HasColumnName("producto_id");
            entity.Property(e => e.UnidadesVendidas).HasColumnName("unidades_vendidas");
        });

        modelBuilder.Entity<VwMenuUsuario>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vw_menu_usuario")
                .HasAnnotation("Npgsql:StorageParameter:security_invoker", "true");

            entity.Property(e => e.Icono)
                .HasMaxLength(50)
                .HasColumnName("icono");
            entity.Property(e => e.Modulo)
                .HasMaxLength(60)
                .HasColumnName("modulo");
            entity.Property(e => e.ModuloId).HasColumnName("modulo_id");
            entity.Property(e => e.ModuloOrden).HasColumnName("modulo_orden");
            entity.Property(e => e.PuedeConsultar).HasColumnName("puede_consultar");
            entity.Property(e => e.PuedeEditar).HasColumnName("puede_editar");
            entity.Property(e => e.PuedeEliminar).HasColumnName("puede_eliminar");
            entity.Property(e => e.PuedeInsertar).HasColumnName("puede_insertar");
            entity.Property(e => e.Ruta)
                .HasMaxLength(150)
                .HasColumnName("ruta");
            entity.Property(e => e.Submenu)
                .HasMaxLength(60)
                .HasColumnName("submenu");
            entity.Property(e => e.SubmenuId).HasColumnName("submenu_id");
            entity.Property(e => e.SubmenuOrden).HasColumnName("submenu_orden");
            entity.Property(e => e.UsuarioId).HasColumnName("usuario_id");
        });

        modelBuilder.Entity<VwPagosPorPedido>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vw_pagos_por_pedido")
                .HasAnnotation("Npgsql:StorageParameter:security_invoker", "true");

            entity.Property(e => e.Cliente).HasColumnName("cliente");
            entity.Property(e => e.PedidoId).HasColumnName("pedido_id");
            entity.Property(e => e.SaldoPendiente).HasColumnName("saldo_pendiente");
            entity.Property(e => e.Total)
                .HasPrecision(12, 2)
                .HasColumnName("total");
            entity.Property(e => e.TotalPagado).HasColumnName("total_pagado");
        });

        modelBuilder.Entity<VwPedidosDetalle>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vw_pedidos_detalle")
                .HasAnnotation("Npgsql:StorageParameter:security_invoker", "true");

            entity.Property(e => e.Cantidad).HasColumnName("cantidad");
            entity.Property(e => e.Cliente).HasColumnName("cliente");
            entity.Property(e => e.Estado)
                .HasMaxLength(20)
                .HasColumnName("estado");
            entity.Property(e => e.FechaPedido).HasColumnName("fecha_pedido");
            entity.Property(e => e.Importe)
                .HasPrecision(12, 2)
                .HasColumnName("importe");
            entity.Property(e => e.PedidoId).HasColumnName("pedido_id");
            entity.Property(e => e.PrecioUnitario)
                .HasPrecision(10, 2)
                .HasColumnName("precio_unitario");
            entity.Property(e => e.Producto)
                .HasMaxLength(100)
                .HasColumnName("producto");
            entity.Property(e => e.Sucursal)
                .HasMaxLength(100)
                .HasColumnName("sucursal");
            entity.Property(e => e.TipoServicio)
                .HasMaxLength(20)
                .HasColumnName("tipo_servicio");
            entity.Property(e => e.Total)
                .HasPrecision(12, 2)
                .HasColumnName("total");
        });

        modelBuilder.Entity<VwProductosCatalogo>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vw_productos_catalogo")
                .HasAnnotation("Npgsql:StorageParameter:security_invoker", "true");

            entity.Property(e => e.Categoria)
                .HasMaxLength(60)
                .HasColumnName("categoria");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(250)
                .HasColumnName("descripcion");
            entity.Property(e => e.Disponible).HasColumnName("disponible");
            entity.Property(e => e.ImagenUrl)
                .HasMaxLength(300)
                .HasColumnName("imagen_url");
            entity.Property(e => e.Precio)
                .HasPrecision(10, 2)
                .HasColumnName("precio");
            entity.Property(e => e.Producto)
                .HasMaxLength(100)
                .HasColumnName("producto");
            entity.Property(e => e.ProductoId).HasColumnName("producto_id");
            entity.Property(e => e.Tipo)
                .HasMaxLength(20)
                .HasColumnName("tipo");
        });

        modelBuilder.Entity<VwRecetasProducto>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vw_recetas_productos")
                .HasAnnotation("Npgsql:StorageParameter:security_invoker", "true");

            entity.Property(e => e.Cantidad)
                .HasPrecision(12, 3)
                .HasColumnName("cantidad");
            entity.Property(e => e.Ingrediente)
                .HasMaxLength(100)
                .HasColumnName("ingrediente");
            entity.Property(e => e.Producto)
                .HasMaxLength(100)
                .HasColumnName("producto");
            entity.Property(e => e.UnidadMedida)
                .HasMaxLength(20)
                .HasColumnName("unidad_medida");
        });

        modelBuilder.Entity<VwUsuariosRole>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vw_usuarios_roles")
                .HasAnnotation("Npgsql:StorageParameter:security_invoker", "true");

            entity.Property(e => e.Activo).HasColumnName("activo");
            entity.Property(e => e.Correo)
                .HasMaxLength(120)
                .HasColumnName("correo");
            entity.Property(e => e.FechaCreacion).HasColumnName("fecha_creacion");
            entity.Property(e => e.NombreCompleto)
                .HasMaxLength(120)
                .HasColumnName("nombre_completo");
            entity.Property(e => e.NombreUsuario)
                .HasMaxLength(50)
                .HasColumnName("nombre_usuario");
            entity.Property(e => e.Rol)
                .HasMaxLength(40)
                .HasColumnName("rol");
            entity.Property(e => e.UsuarioId).HasColumnName("usuario_id");
        });

        modelBuilder.Entity<VwVentasDiaria>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vw_ventas_diarias")
                .HasAnnotation("Npgsql:StorageParameter:security_invoker", "true");

            entity.Property(e => e.CantidadPedidos).HasColumnName("cantidad_pedidos");
            entity.Property(e => e.Fecha).HasColumnName("fecha");
            entity.Property(e => e.Sucursal)
                .HasMaxLength(100)
                .HasColumnName("sucursal");
            entity.Property(e => e.TotalVendido).HasColumnName("total_vendido");
        });
        modelBuilder.HasSequence("seq_factura_numero");

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
