using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CentroEventos.Repositorios.Migrations
{
    /// <inheritdoc />
    public partial class esAdmin : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "esAdmin",
                table: "Usuarios",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "esAdmin",
                table: "Usuarios");
        }
    }
}
