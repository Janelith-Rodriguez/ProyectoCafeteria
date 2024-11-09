using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProyectoCafeteria.BD.Migrations
{
    /// <inheritdoc />
    public partial class BaseV1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Carritos_Usuarios_UsuarioId",
                table: "Carritos");

            migrationBuilder.AddColumn<bool>(
                name: "Activo",
                table: "Usuarios",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Activo",
                table: "Carritos",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateTable(
                name: "Domicilios",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UsuarioId = table.Column<int>(type: "int", nullable: false),
                    Telefono = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Calle = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Ciudad = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CP = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Activo = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Domicilios", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Domicilios_Usuarios_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MetodosPagos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Activo = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MetodosPagos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Productos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Precio = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Fecha = table.Column<DateTime>(type: "datetime2", maxLength: 50, nullable: false),
                    CarritoId = table.Column<int>(type: "int", nullable: true),
                    Activo = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Productos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Productos_Carritos_CarritoId",
                        column: x => x.CarritoId,
                        principalTable: "Carritos",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Ordenes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UsuarioId = table.Column<int>(type: "int", nullable: false),
                    MetodoPagoId = table.Column<int>(type: "int", nullable: false),
                    Total = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    DomicilioId = table.Column<int>(type: "int", nullable: false),
                    ProductoId = table.Column<int>(type: "int", nullable: true),
                    Activo = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ordenes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Ordenes_Domicilios_DomicilioId",
                        column: x => x.DomicilioId,
                        principalTable: "Domicilios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Ordenes_MetodosPagos_MetodoPagoId",
                        column: x => x.MetodoPagoId,
                        principalTable: "MetodosPagos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Ordenes_Productos_ProductoId",
                        column: x => x.ProductoId,
                        principalTable: "Productos",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Ordenes_Usuarios_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DetallesOrdenes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrdenId = table.Column<int>(type: "int", nullable: false),
                    ProductoId = table.Column<int>(type: "int", nullable: false),
                    Cantidad = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: false),
                    Precio = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Activo = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DetallesOrdenes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DetallesOrdenes_Ordenes_OrdenId",
                        column: x => x.OrdenId,
                        principalTable: "Ordenes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DetallesOrdenes_Productos_ProductoId",
                        column: x => x.ProductoId,
                        principalTable: "Productos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "DetalleOrden_UQ",
                table: "DetallesOrdenes",
                column: "Cantidad",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_DetallesOrdenes_OrdenId",
                table: "DetallesOrdenes",
                column: "OrdenId");

            migrationBuilder.CreateIndex(
                name: "IX_DetallesOrdenes_ProductoId",
                table: "DetallesOrdenes",
                column: "ProductoId");

            migrationBuilder.CreateIndex(
                name: "Domicilio_UQ",
                table: "Domicilios",
                column: "Telefono",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Domicilios_UsuarioId",
                table: "Domicilios",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "MetodoPago_UQ",
                table: "MetodosPagos",
                column: "Nombre",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Ordenes_DomicilioId",
                table: "Ordenes",
                column: "DomicilioId");

            migrationBuilder.CreateIndex(
                name: "IX_Ordenes_MetodoPagoId",
                table: "Ordenes",
                column: "MetodoPagoId");

            migrationBuilder.CreateIndex(
                name: "IX_Ordenes_ProductoId",
                table: "Ordenes",
                column: "ProductoId");

            migrationBuilder.CreateIndex(
                name: "IX_Ordenes_UsuarioId",
                table: "Ordenes",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "Orden_UQ",
                table: "Ordenes",
                column: "Total",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Productos_CarritoId",
                table: "Productos",
                column: "CarritoId");

            migrationBuilder.CreateIndex(
                name: "Producto_UQ",
                table: "Productos",
                column: "Nombre",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Carritos_Usuarios_UsuarioId",
                table: "Carritos",
                column: "UsuarioId",
                principalTable: "Usuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Carritos_Usuarios_UsuarioId",
                table: "Carritos");

            migrationBuilder.DropTable(
                name: "DetallesOrdenes");

            migrationBuilder.DropTable(
                name: "Ordenes");

            migrationBuilder.DropTable(
                name: "Domicilios");

            migrationBuilder.DropTable(
                name: "MetodosPagos");

            migrationBuilder.DropTable(
                name: "Productos");

            migrationBuilder.DropColumn(
                name: "Activo",
                table: "Usuarios");

            migrationBuilder.DropColumn(
                name: "Activo",
                table: "Carritos");

            migrationBuilder.AddForeignKey(
                name: "FK_Carritos_Usuarios_UsuarioId",
                table: "Carritos",
                column: "UsuarioId",
                principalTable: "Usuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
