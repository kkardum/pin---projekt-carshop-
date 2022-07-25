using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApplication1.Data.Migrations
{
    public partial class auto : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_auti",
                table: "auti");

            migrationBuilder.RenameTable(
                name: "auti",
                newName: "auto");

            migrationBuilder.AddPrimaryKey(
                name: "PK_auto",
                table: "auto",
                column: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_auto",
                table: "auto");

            migrationBuilder.RenameTable(
                name: "auto",
                newName: "auti");

            migrationBuilder.AddPrimaryKey(
                name: "PK_auti",
                table: "auti",
                column: "Id");
        }
    }
}
