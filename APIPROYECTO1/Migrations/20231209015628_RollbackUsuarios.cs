using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace APIPROYECTO1.Migrations
{
    /// <inheritdoc />
    public partial class RollbackUsuarios : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Usuarios",
                keyColumn: "idUsuario",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Usuarios",
                keyColumn: "idUsuario",
                keyValue: 4);

            migrationBuilder.InsertData(
                table: "Usuarios",
                columns: new[] { "idUsuario", "contrasena", "tipo", "usuario" },
                values: new object[,]
                {
                    { 1, "1234", true, "admin1" },
                    { 2, "1234", false, "cliente1" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Usuarios",
                keyColumn: "idUsuario",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Usuarios",
                keyColumn: "idUsuario",
                keyValue: 2);

            migrationBuilder.InsertData(
                table: "Usuarios",
                columns: new[] { "idUsuario", "contrasena", "tipo", "usuario" },
                values: new object[,]
                {
                    { 3, "1234", true, "admin2" },
                    { 4, "1234", false, "cliente2" }
                });
        }
    }
}
