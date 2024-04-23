using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AppPeluqueriaMVC.Migrations
{
    /// <inheritdoc />
    public partial class CostoCitaImagenCosmetico : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte[]>(
                name: "imagenProducto",
                table: "Cosmetico",
                type: "VARBINARY(MAX)",
                nullable: false,
                defaultValue: new byte[0]);

            migrationBuilder.AddColumn<double>(
                name: "CostoTotal",
                table: "Cita",
                type: "float",
                nullable: false,
                defaultValue: 0.0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "imagenProducto",
                table: "Cosmetico");

            migrationBuilder.DropColumn(
                name: "CostoTotal",
                table: "Cita");
        }
    }
}
