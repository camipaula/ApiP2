using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace APIPROYECTO1.Migrations
{
    /// <inheritdoc />
    public partial class intentosincom : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Accesorios",
                columns: new[] { "IdAccesorio", "Cantidad", "Descripcion", "Marca", "Nombre", "Precio" },
                values: new object[,]
                {
                    { 1, 2, "Collar blanco de plata", "cartier", "Collar", 11f },
                    { 2, 3, "Aretes largos", "buccellati", "Aretes", 20f }
                });

            migrationBuilder.InsertData(
                table: "Usuarios",
                columns: new[] { "idUsuario", "contrasena", "tipo", "usuario" },
                values: new object[,]
                {
                    { 1, "1234", true, "admin1" },
                    { 2, "1234", false, "cliente1" }
                });

            migrationBuilder.InsertData(
                table: "promociones",
                columns: new[] { "IdPromocion", "Cantidad", "Descripcion", "Marca", "Nombre", "Precio" },
                values: new object[,]
                {
                    { 1, 2, "Blusa azul", "shein", "Promocion 1", 13f },
                    { 2, 3, "Aretes largos", "shein", "Promocion 2", 15f }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Accesorios",
                keyColumn: "IdAccesorio",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Accesorios",
                keyColumn: "IdAccesorio",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Usuarios",
                keyColumn: "idUsuario",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Usuarios",
                keyColumn: "idUsuario",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "promociones",
                keyColumn: "IdPromocion",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "promociones",
                keyColumn: "IdPromocion",
                keyValue: 2);
        }
    }
}
