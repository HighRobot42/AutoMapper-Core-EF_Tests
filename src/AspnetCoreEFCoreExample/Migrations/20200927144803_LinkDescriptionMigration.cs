using Microsoft.EntityFrameworkCore.Migrations;

namespace AspnetCoreEFCoreExample.Migrations
{
    public partial class LinkDescriptionMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "LinkDescription",
                table: "ElementMember",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LinkDescription",
                table: "ElementMember");
        }
    }
}
