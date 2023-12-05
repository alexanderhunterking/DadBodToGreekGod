using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DadBodToGreekGod.Data.Migrations
{
    /// <inheritdoc />
    public partial class MealChanges : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Meals_Calendars_CalendarId",
                table: "Meals");

            migrationBuilder.DropIndex(
                name: "IX_Meals_CalendarId",
                table: "Meals");

            migrationBuilder.AddColumn<int>(
                name: "CalendarEntityCalendarId",
                table: "Meals",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Meals_CalendarEntityCalendarId",
                table: "Meals",
                column: "CalendarEntityCalendarId");

            migrationBuilder.AddForeignKey(
                name: "FK_Meals_Calendars_CalendarEntityCalendarId",
                table: "Meals",
                column: "CalendarEntityCalendarId",
                principalTable: "Calendars",
                principalColumn: "CalendarId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Meals_Calendars_CalendarEntityCalendarId",
                table: "Meals");

            migrationBuilder.DropIndex(
                name: "IX_Meals_CalendarEntityCalendarId",
                table: "Meals");

            migrationBuilder.DropColumn(
                name: "CalendarEntityCalendarId",
                table: "Meals");

            migrationBuilder.CreateIndex(
                name: "IX_Meals_CalendarId",
                table: "Meals",
                column: "CalendarId");

            migrationBuilder.AddForeignKey(
                name: "FK_Meals_Calendars_CalendarId",
                table: "Meals",
                column: "CalendarId",
                principalTable: "Calendars",
                principalColumn: "CalendarId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
