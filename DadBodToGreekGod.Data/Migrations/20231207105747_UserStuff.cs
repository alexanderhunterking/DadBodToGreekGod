using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DadBodToGreekGod.Data.Migrations
{
    /// <inheritdoc />
    public partial class UserStuff : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "HasMadeCalendar",
                table: "Users",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "HasMadeCalendar",
                table: "Users");
        }
    }
}
