using Microsoft.EntityFrameworkCore.Migrations;

namespace GitHub.Data.Migrations
{
    public partial class ChangeNameOfRepositoryDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OwnedId",
                table: "Repositories");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "OwnedId",
                table: "Repositories",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
