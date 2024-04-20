using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AppPeluqueriaMVC.Migrations
{
    /// <inheritdoc />
    public partial class InicialPeluqueria : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cliente",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DNI = table.Column<string>(type: "varchar(10)", nullable: false),
                    Nombre = table.Column<string>(type: "varchar(30)", nullable: false),
                    Apellido = table.Column<string>(type: "varchar(30)", nullable: false),
                    Telefono = table.Column<string>(type: "varchar(20)", nullable: false),
                    Calle = table.Column<string>(type: "varchar(20)", nullable: false),
                    NumInt = table.Column<string>(type: "varchar(10)", nullable: false),
                    Colonia = table.Column<string>(type: "varchar(40)", nullable: false),
                    CodigoPostal = table.Column<string>(type: "varchar(10)", nullable: false),
                    Ciudad = table.Column<string>(type: "varchar(40)", nullable: false),
                    Pais = table.Column<string>(type: "varchar(40)", nullable: false),
                    Tratamientos = table.Column<string>(type: "varchar(100)", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cliente", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Cosmetico",
                columns: table => new
                {
                    Codigo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Cantidad = table.Column<int>(type: "int", nullable: false),
                    Precio = table.Column<double>(type: "float", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cosmetico", x => x.Codigo);
                });

            migrationBuilder.CreateTable(
                name: "Empleado",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DNI = table.Column<string>(type: "varchar(10)", nullable: false),
                    Nombre = table.Column<string>(type: "varchar(30)", nullable: false),
                    Apellido = table.Column<string>(type: "varchar(30)", nullable: false),
                    Especialidad = table.Column<string>(type: "varchar(20)", nullable: false),
                    Sueldo = table.Column<decimal>(type: "decimal(7,2)", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Empleado", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Cita",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Fecha = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Id_Empleado = table.Column<int>(type: "int", nullable: false),
                    Id_Cliente = table.Column<int>(type: "int", nullable: false),
                    TipoServicio = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cita", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cita_Cliente_Id",
                        column: x => x.Id,
                        principalTable: "Cliente",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Cita_Empleado_Id",
                        column: x => x.Id,
                        principalTable: "Empleado",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CitaCosmetico",
                columns: table => new
                {
                    CitaId = table.Column<int>(type: "int", nullable: false),
                    CosmeticoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CitaCosmetico", x => new { x.CitaId, x.CosmeticoId });
                    table.ForeignKey(
                        name: "FK_CitaCosmetico_Cita_CitaId",
                        column: x => x.CitaId,
                        principalTable: "Cita",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CitaCosmetico_Cosmetico_CosmeticoId",
                        column: x => x.CosmeticoId,
                        principalTable: "Cosmetico",
                        principalColumn: "Codigo",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CitaCosmetico_CosmeticoId",
                table: "CitaCosmetico",
                column: "CosmeticoId");

            migrationBuilder.CreateIndex(
                name: "IX_Cliente_DNI",
                table: "Cliente",
                column: "DNI",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Cliente_Telefono",
                table: "Cliente",
                column: "Telefono",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Empleado_DNI",
                table: "Empleado",
                column: "DNI",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CitaCosmetico");

            migrationBuilder.DropTable(
                name: "Cita");

            migrationBuilder.DropTable(
                name: "Cosmetico");

            migrationBuilder.DropTable(
                name: "Cliente");

            migrationBuilder.DropTable(
                name: "Empleado");
        }
    }
}
