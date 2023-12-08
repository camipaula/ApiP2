using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace APIPROYECTO1.Migrations
{
    /// <inheritdoc />
    public partial class Carrito : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Carrito",
                columns: table => new
                {
                    IdCarrito = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UsuarioidUsuario = table.Column<int>(type: "int", nullable: false),
                    Fecha = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Carrito", x => x.IdCarrito);
                    table.ForeignKey(
                        name: "FK_Carrito_Usuarios_UsuarioidUsuario",
                        column: x => x.UsuarioidUsuario,
                        principalTable: "Usuarios",
                        principalColumn: "idUsuario",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Compra",
                columns: table => new
                {
                    IdCompra = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UsuarioidUsuario = table.Column<int>(type: "int", nullable: false),
                    Fecha = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Compra", x => x.IdCompra);
                    table.ForeignKey(
                        name: "FK_Compra_Usuarios_UsuarioidUsuario",
                        column: x => x.UsuarioidUsuario,
                        principalTable: "Usuarios",
                        principalColumn: "idUsuario",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DetalleCarrito",
                columns: table => new
                {
                    IdDetalleCarrito = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Status = table.Column<bool>(type: "bit", nullable: false),
                    Cantidad = table.Column<int>(type: "int", nullable: false),
                    PrecioTotal = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PrendaIdPrenda = table.Column<int>(type: "int", nullable: false),
                    AccesorioIdAccesorio = table.Column<int>(type: "int", nullable: false),
                    AccesoriosIdAccesorio = table.Column<int>(type: "int", nullable: false),
                    PromocionIdPromocion = table.Column<int>(type: "int", nullable: false),
                    CarritoIdCarrito = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DetalleCarrito", x => x.IdDetalleCarrito);
                    table.ForeignKey(
                        name: "FK_DetalleCarrito_Accesorios_AccesoriosIdAccesorio",
                        column: x => x.AccesoriosIdAccesorio,
                        principalTable: "Accesorios",
                        principalColumn: "IdAccesorio",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DetalleCarrito_Carrito_CarritoIdCarrito",
                        column: x => x.CarritoIdCarrito,
                        principalTable: "Carrito",
                        principalColumn: "IdCarrito",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DetalleCarrito_Prendas_PrendaIdPrenda",
                        column: x => x.PrendaIdPrenda,
                        principalTable: "Prendas",
                        principalColumn: "IdPrenda",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DetalleCarrito_promociones_PromocionIdPromocion",
                        column: x => x.PromocionIdPromocion,
                        principalTable: "promociones",
                        principalColumn: "IdPromocion",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DetalleCompra",
                columns: table => new
                {
                    IdDetalleCompra = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Status = table.Column<bool>(type: "bit", nullable: false),
                    Cantidad = table.Column<int>(type: "int", nullable: false),
                    PrecioTotal = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PrendaIdPrenda = table.Column<int>(type: "int", nullable: false),
                    AccesorioIdAccesorio = table.Column<int>(type: "int", nullable: false),
                    AccesoriosIdAccesorio = table.Column<int>(type: "int", nullable: false),
                    PromocionIdPromocion = table.Column<int>(type: "int", nullable: false),
                    CarritoIdCarrito = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DetalleCompra", x => x.IdDetalleCompra);
                    table.ForeignKey(
                        name: "FK_DetalleCompra_Accesorios_AccesoriosIdAccesorio",
                        column: x => x.AccesoriosIdAccesorio,
                        principalTable: "Accesorios",
                        principalColumn: "IdAccesorio",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DetalleCompra_Carrito_CarritoIdCarrito",
                        column: x => x.CarritoIdCarrito,
                        principalTable: "Carrito",
                        principalColumn: "IdCarrito",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DetalleCompra_Prendas_PrendaIdPrenda",
                        column: x => x.PrendaIdPrenda,
                        principalTable: "Prendas",
                        principalColumn: "IdPrenda",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DetalleCompra_promociones_PromocionIdPromocion",
                        column: x => x.PromocionIdPromocion,
                        principalTable: "promociones",
                        principalColumn: "IdPromocion",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Carrito_UsuarioidUsuario",
                table: "Carrito",
                column: "UsuarioidUsuario");

            migrationBuilder.CreateIndex(
                name: "IX_Compra_UsuarioidUsuario",
                table: "Compra",
                column: "UsuarioidUsuario");

            migrationBuilder.CreateIndex(
                name: "IX_DetalleCarrito_AccesoriosIdAccesorio",
                table: "DetalleCarrito",
                column: "AccesoriosIdAccesorio");

            migrationBuilder.CreateIndex(
                name: "IX_DetalleCarrito_CarritoIdCarrito",
                table: "DetalleCarrito",
                column: "CarritoIdCarrito");

            migrationBuilder.CreateIndex(
                name: "IX_DetalleCarrito_PrendaIdPrenda",
                table: "DetalleCarrito",
                column: "PrendaIdPrenda");

            migrationBuilder.CreateIndex(
                name: "IX_DetalleCarrito_PromocionIdPromocion",
                table: "DetalleCarrito",
                column: "PromocionIdPromocion");

            migrationBuilder.CreateIndex(
                name: "IX_DetalleCompra_AccesoriosIdAccesorio",
                table: "DetalleCompra",
                column: "AccesoriosIdAccesorio");

            migrationBuilder.CreateIndex(
                name: "IX_DetalleCompra_CarritoIdCarrito",
                table: "DetalleCompra",
                column: "CarritoIdCarrito");

            migrationBuilder.CreateIndex(
                name: "IX_DetalleCompra_PrendaIdPrenda",
                table: "DetalleCompra",
                column: "PrendaIdPrenda");

            migrationBuilder.CreateIndex(
                name: "IX_DetalleCompra_PromocionIdPromocion",
                table: "DetalleCompra",
                column: "PromocionIdPromocion");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Compra");

            migrationBuilder.DropTable(
                name: "DetalleCarrito");

            migrationBuilder.DropTable(
                name: "DetalleCompra");

            migrationBuilder.DropTable(
                name: "Carrito");
        }
    }
}
