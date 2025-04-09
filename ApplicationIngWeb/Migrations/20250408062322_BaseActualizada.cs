using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApplicationIngWeb.Migrations
{
    /// <inheritdoc />
    public partial class BaseActualizada : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Nombre",
                table: "Categorias",
                newName: "Name");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Categorias",
                newName: "Nombre");
        }
    }
}
