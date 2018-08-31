using Microsoft.EntityFrameworkCore.Migrations;

namespace xau.Migrations
{
    public partial class userID_Status : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "OwnerID",
                table: "Entrega",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "status",
                table: "Entrega",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OwnerID",
                table: "Entrega");

            migrationBuilder.DropColumn(
                name: "status",
                table: "Entrega");
        }
    }
}
