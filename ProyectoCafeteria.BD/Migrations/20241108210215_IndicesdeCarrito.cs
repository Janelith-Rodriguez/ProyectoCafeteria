using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProyectoCafeteria.BD.Migrations
{
    /// <inheritdoc />
    public partial class IndicesdeCarrito : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Carritos_UsuarioId",
                table: "Carritos");

            migrationBuilder.AlterColumn<string>(
                name: "Cantidad",
                table: "Carritos",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateIndex(
                name: "Carrito_UQ",
                table: "Carritos",
                columns: new[] { "UsuarioId", "Cantidad" },
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "Carrito_UQ",
                table: "Carritos");

            migrationBuilder.AlterColumn<string>(
                name: "Cantidad",
                table: "Carritos",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.CreateIndex(
                name: "IX_Carritos_UsuarioId",
                table: "Carritos",
                column: "UsuarioId");
        }
    }
}
