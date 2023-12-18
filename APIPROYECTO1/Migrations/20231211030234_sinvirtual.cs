using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace APIPROYECTO1.Migrations
{
    /// <inheritdoc />
    public partial class sinvirtual : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DetalleCarrito_Accesorios_AccesoriosIdAccesorio",
                table: "DetalleCarrito");

            migrationBuilder.DropForeignKey(
                name: "FK_DetalleCarrito_promociones_PromocionIdPromocion",
                table: "DetalleCarrito");

            migrationBuilder.DropIndex(
                name: "IX_DetalleCarrito_AccesoriosIdAccesorio",
                table: "DetalleCarrito");

            migrationBuilder.DropIndex(
                name: "IX_DetalleCarrito_PromocionIdPromocion",
                table: "DetalleCarrito");

            migrationBuilder.DropColumn(
                name: "AccesoriosIdAccesorio",
                table: "DetalleCarrito");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AccesoriosIdAccesorio",
                table: "DetalleCarrito",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_DetalleCarrito_AccesoriosIdAccesorio",
                table: "DetalleCarrito",
                column: "AccesoriosIdAccesorio");

            migrationBuilder.CreateIndex(
                name: "IX_DetalleCarrito_PromocionIdPromocion",
                table: "DetalleCarrito",
                column: "PromocionIdPromocion");

            migrationBuilder.AddForeignKey(
                name: "FK_DetalleCarrito_Accesorios_AccesoriosIdAccesorio",
                table: "DetalleCarrito",
                column: "AccesoriosIdAccesorio",
                principalTable: "Accesorios",
                principalColumn: "IdAccesorio",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DetalleCarrito_promociones_PromocionIdPromocion",
                table: "DetalleCarrito",
                column: "PromocionIdPromocion",
                principalTable: "promociones",
                principalColumn: "IdPromocion",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
