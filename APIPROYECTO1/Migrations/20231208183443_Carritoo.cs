using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace APIPROYECTO1.Migrations
{
    /// <inheritdoc />
    public partial class Carritoo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DetalleCarrito_Accesorios_AccesoriosIdAccesorio",
                table: "DetalleCarrito");

            migrationBuilder.DropForeignKey(
                name: "FK_DetalleCompra_Accesorios_AccesoriosIdAccesorio",
                table: "DetalleCompra");

            migrationBuilder.DropIndex(
                name: "IX_DetalleCompra_AccesoriosIdAccesorio",
                table: "DetalleCompra");

            migrationBuilder.DropIndex(
                name: "IX_DetalleCarrito_AccesoriosIdAccesorio",
                table: "DetalleCarrito");

            migrationBuilder.DropColumn(
                name: "AccesoriosIdAccesorio",
                table: "DetalleCompra");

            migrationBuilder.DropColumn(
                name: "AccesoriosIdAccesorio",
                table: "DetalleCarrito");

            migrationBuilder.CreateIndex(
                name: "IX_DetalleCompra_AccesorioIdAccesorio",
                table: "DetalleCompra",
                column: "AccesorioIdAccesorio");

            migrationBuilder.CreateIndex(
                name: "IX_DetalleCarrito_AccesorioIdAccesorio",
                table: "DetalleCarrito",
                column: "AccesorioIdAccesorio");

            migrationBuilder.AddForeignKey(
                name: "FK_DetalleCarrito_Accesorios_AccesorioIdAccesorio",
                table: "DetalleCarrito",
                column: "AccesorioIdAccesorio",
                principalTable: "Accesorios",
                principalColumn: "IdAccesorio",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DetalleCompra_Accesorios_AccesorioIdAccesorio",
                table: "DetalleCompra",
                column: "AccesorioIdAccesorio",
                principalTable: "Accesorios",
                principalColumn: "IdAccesorio",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DetalleCarrito_Accesorios_AccesorioIdAccesorio",
                table: "DetalleCarrito");

            migrationBuilder.DropForeignKey(
                name: "FK_DetalleCompra_Accesorios_AccesorioIdAccesorio",
                table: "DetalleCompra");

            migrationBuilder.DropIndex(
                name: "IX_DetalleCompra_AccesorioIdAccesorio",
                table: "DetalleCompra");

            migrationBuilder.DropIndex(
                name: "IX_DetalleCarrito_AccesorioIdAccesorio",
                table: "DetalleCarrito");

            migrationBuilder.AddColumn<int>(
                name: "AccesoriosIdAccesorio",
                table: "DetalleCompra",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "AccesoriosIdAccesorio",
                table: "DetalleCarrito",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_DetalleCompra_AccesoriosIdAccesorio",
                table: "DetalleCompra",
                column: "AccesoriosIdAccesorio");

            migrationBuilder.CreateIndex(
                name: "IX_DetalleCarrito_AccesoriosIdAccesorio",
                table: "DetalleCarrito",
                column: "AccesoriosIdAccesorio");

            migrationBuilder.AddForeignKey(
                name: "FK_DetalleCarrito_Accesorios_AccesoriosIdAccesorio",
                table: "DetalleCarrito",
                column: "AccesoriosIdAccesorio",
                principalTable: "Accesorios",
                principalColumn: "IdAccesorio",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DetalleCompra_Accesorios_AccesoriosIdAccesorio",
                table: "DetalleCompra",
                column: "AccesoriosIdAccesorio",
                principalTable: "Accesorios",
                principalColumn: "IdAccesorio",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
