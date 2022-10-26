using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Cars.Data.Migrations
{
    public partial class CarTypeAddedd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Type",
                table: "Cars",
                type: "int",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Type",
                table: "Cars");
        }
    }
}
