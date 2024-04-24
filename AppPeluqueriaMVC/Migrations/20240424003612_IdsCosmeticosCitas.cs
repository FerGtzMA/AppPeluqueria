using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AppPeluqueriaMVC.Migrations
{
    /// <inheritdoc />
    public partial class IdsCosmeticosCitas : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CitaCosmetico_Cosmetico_CosmeticoId",
                table: "CitaCosmetico");

            migrationBuilder.DropForeignKey(
                name: "FK_CitaServicio_Cosmetico_ServicioId",
                table: "CitaServicio");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Cosmetico",
                table: "Cosmetico");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Cosmetico");

            migrationBuilder.DropColumn(
                name: "Descripcion",
                table: "Cosmetico");

            migrationBuilder.AlterColumn<double>(
                name: "Precio",
                table: "Cosmetico",
                type: "float",
                nullable: false,
                defaultValue: 0.0,
                oldClrType: typeof(double),
                oldType: "float",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SelectedCosmeticoIds",
                table: "Cita",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "[]");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Cosmetico",
                table: "Cosmetico",
                column: "Codigo");

            migrationBuilder.CreateTable(
                name: "Servicio",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Precio = table.Column<double>(type: "float", nullable: true),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Servicio", x => x.Id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_CitaCosmetico_Cosmetico_CosmeticoId",
                table: "CitaCosmetico",
                column: "CosmeticoId",
                principalTable: "Cosmetico",
                principalColumn: "Codigo",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CitaServicio_Servicio_ServicioId",
                table: "CitaServicio",
                column: "ServicioId",
                principalTable: "Servicio",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CitaCosmetico_Cosmetico_CosmeticoId",
                table: "CitaCosmetico");

            migrationBuilder.DropForeignKey(
                name: "FK_CitaServicio_Servicio_ServicioId",
                table: "CitaServicio");

            migrationBuilder.DropTable(
                name: "Servicio");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Cosmetico",
                table: "Cosmetico");

            migrationBuilder.DropColumn(
                name: "SelectedCosmeticoIds",
                table: "Cita");

            migrationBuilder.AlterColumn<double>(
                name: "Precio",
                table: "Cosmetico",
                type: "float",
                nullable: true,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "Cosmetico",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<string>(
                name: "Descripcion",
                table: "Cosmetico",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Cosmetico",
                table: "Cosmetico",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CitaCosmetico_Cosmetico_CosmeticoId",
                table: "CitaCosmetico",
                column: "CosmeticoId",
                principalTable: "Cosmetico",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CitaServicio_Cosmetico_ServicioId",
                table: "CitaServicio",
                column: "ServicioId",
                principalTable: "Cosmetico",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
