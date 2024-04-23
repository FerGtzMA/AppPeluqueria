using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AppPeluqueriaMVC.Migrations
{
    /// <inheritdoc />
    public partial class ImageModifiCosmetic : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "imagenProducto",
                table: "Cosmetico");

            migrationBuilder.AddColumn<string>(
                name: "ImagenUrl",
                table: "Cosmetico",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImagenUrl",
                table: "Cosmetico");

            migrationBuilder.AddColumn<byte[]>(
                name: "imagenProducto",
                table: "Cosmetico",
                type: "VARBINARY(MAX)",
                nullable: false,
                defaultValue: new byte[0]);
        }
    }
}
