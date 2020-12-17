using Microsoft.EntityFrameworkCore.Migrations;

namespace TheBoardOfShame.Migrations
{
    public partial class choremodeldefined : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ChoreDescription",
                table: "Chore",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ChoreType",
                table: "Chore",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ChoreWeight",
                table: "Chore",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ChoreDescription",
                table: "Chore");

            migrationBuilder.DropColumn(
                name: "ChoreType",
                table: "Chore");

            migrationBuilder.DropColumn(
                name: "ChoreWeight",
                table: "Chore");
        }
    }
}
