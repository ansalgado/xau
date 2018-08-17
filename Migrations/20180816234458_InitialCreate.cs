using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace xau.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Proveedor",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nombre = table.Column<string>(nullable: true),
                    Telefono = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Proveedor", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Recolector",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nombre = table.Column<string>(nullable: true),
                    Telefono = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Recolector", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Entrega",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Fecha = table.Column<DateTime>(nullable: false),
                    Peso = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    RecolectorID = table.Column<int>(nullable: false),
                    ProveedorID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Entrega", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Entrega_Proveedor_ProveedorID",
                        column: x => x.ProveedorID,
                        principalTable: "Proveedor",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Entrega_Recolector_RecolectorID",
                        column: x => x.RecolectorID,
                        principalTable: "Recolector",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Entrega_ProveedorID",
                table: "Entrega",
                column: "ProveedorID");

            migrationBuilder.CreateIndex(
                name: "IX_Entrega_RecolectorID",
                table: "Entrega",
                column: "RecolectorID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Entrega");

            migrationBuilder.DropTable(
                name: "Proveedor");

            migrationBuilder.DropTable(
                name: "Recolector");
        }
    }
}
