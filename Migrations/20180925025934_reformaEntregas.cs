using Microsoft.EntityFrameworkCore.Migrations;

namespace xau.Migrations
{
    public partial class reformaEntregas : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "LeyRecuperable",
                table: "Entrega",
                nullable: false,
                defaultValue: 0m);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LeyRecuperable",
                table: "Entrega");
        }
    }
}
