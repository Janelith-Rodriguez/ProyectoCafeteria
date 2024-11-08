using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProyectoCafeteria.BD.Migrations
{
    /// <inheritdoc />
    public partial class ActualizoCarrito : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Cantidad",
                table: "Carritos",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Cantidad",
                table: "Carritos");
        }
    }
}
