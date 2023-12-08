using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace APIPROYECTO1.Migrations
{
    /// <inheritdoc />
    public partial class tipodedato : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DetalleCompra_Carrito_CarritoIdCarrito",
                table: "DetalleCompra");

            migrationBuilder.RenameColumn(
                name: "CarritoIdCarrito",
                table: "DetalleCompra",
                newName: "CompraIdCompra");

            migrationBuilder.RenameIndex(
                name: "IX_DetalleCompra_CarritoIdCarrito",
                table: "DetalleCompra",
                newName: "IX_DetalleCompra_CompraIdCompra");

            migrationBuilder.AlterColumn<int>(
                name: "PrecioTotal",
                table: "DetalleCompra",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<float>(
                name: "PrecioTotal",
                table: "DetalleCarrito",
                type: "real",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddForeignKey(
                name: "FK_DetalleCompra_Compra_CompraIdCompra",
                table: "DetalleCompra",
                column: "CompraIdCompra",
                principalTable: "Compra",
                principalColumn: "IdCompra",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DetalleCompra_Compra_CompraIdCompra",
                table: "DetalleCompra");

            migrationBuilder.RenameColumn(
                name: "CompraIdCompra",
                table: "DetalleCompra",
                newName: "CarritoIdCarrito");

            migrationBuilder.RenameIndex(
                name: "IX_DetalleCompra_CompraIdCompra",
                table: "DetalleCompra",
                newName: "IX_DetalleCompra_CarritoIdCarrito");

            migrationBuilder.AlterColumn<string>(
                name: "PrecioTotal",
                table: "DetalleCompra",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "PrecioTotal",
                table: "DetalleCarrito",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(float),
                oldType: "real");

            migrationBuilder.AddForeignKey(
                name: "FK_DetalleCompra_Carrito_CarritoIdCarrito",
                table: "DetalleCompra",
                column: "CarritoIdCarrito",
                principalTable: "Carrito",
                principalColumn: "IdCarrito",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
