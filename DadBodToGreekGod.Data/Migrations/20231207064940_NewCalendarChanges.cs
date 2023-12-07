using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DadBodToGreekGod.Data.Migrations
{
    /// <inheritdoc />
    public partial class NewCalendarChanges : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Meals_Calendars_CalendarEntityCalendarId",
                table: "Meals");

            migrationBuilder.DropForeignKey(
                name: "FK_ShoppingLists_Calendars_CalendarId",
                table: "ShoppingLists");

            migrationBuilder.DropTable(
                name: "Calendars");

            migrationBuilder.DropTable(
                name: "UserMealAssignments");

            migrationBuilder.DropIndex(
                name: "IX_ShoppingLists_CalendarId",
                table: "ShoppingLists");

            migrationBuilder.DropIndex(
                name: "IX_Meals_CalendarEntityCalendarId",
                table: "Meals");

            migrationBuilder.DropColumn(
                name: "CalendarEntityCalendarId",
                table: "Meals");

            migrationBuilder.CreateTable(
                name: "CalendarWeeks",
                columns: table => new
                {
                    CalendarId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    ShoppingDay = table.Column<int>(type: "int", nullable: false),
                    CookingDay = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CalendarWeeks", x => x.CalendarId);
                    table.ForeignKey(
                        name: "FK_CalendarWeeks_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CalendarDays",
                columns: table => new
                {
                    CalendarDayId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    MealId = table.Column<int>(type: "int", nullable: false),
                    TimeOfDay = table.Column<int>(type: "int", nullable: false),
                    DayOfTheWeek = table.Column<int>(type: "int", nullable: false),
                    CalendarWeekEntityCalendarId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CalendarDays", x => x.CalendarDayId);
                    table.ForeignKey(
                        name: "FK_CalendarDays_CalendarWeeks_CalendarWeekEntityCalendarId",
                        column: x => x.CalendarWeekEntityCalendarId,
                        principalTable: "CalendarWeeks",
                        principalColumn: "CalendarId");
                    table.ForeignKey(
                        name: "FK_CalendarDays_Meals_MealId",
                        column: x => x.MealId,
                        principalTable: "Meals",
                        principalColumn: "MealId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CalendarDays_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CalendarDays_CalendarWeekEntityCalendarId",
                table: "CalendarDays",
                column: "CalendarWeekEntityCalendarId");

            migrationBuilder.CreateIndex(
                name: "IX_CalendarDays_MealId",
                table: "CalendarDays",
                column: "MealId");

            migrationBuilder.CreateIndex(
                name: "IX_CalendarDays_UserId",
                table: "CalendarDays",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_CalendarWeeks_UserId",
                table: "CalendarWeeks",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CalendarDays");

            migrationBuilder.DropTable(
                name: "CalendarWeeks");

            migrationBuilder.AddColumn<int>(
                name: "CalendarEntityCalendarId",
                table: "Meals",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Calendars",
                columns: table => new
                {
                    CalendarId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    CookingDay = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ShoppingDay = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Calendars", x => x.CalendarId);
                    table.ForeignKey(
                        name: "FK_Calendars_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserMealAssignments",
                columns: table => new
                {
                    UserMealAssignmentId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    MealId = table.Column<int>(type: "int", nullable: false),
                    TimeOfDay = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserMealAssignments", x => new { x.UserMealAssignmentId, x.UserId, x.MealId });
                    table.ForeignKey(
                        name: "FK_UserMealAssignments_Meals_MealId",
                        column: x => x.MealId,
                        principalTable: "Meals",
                        principalColumn: "MealId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserMealAssignments_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ShoppingLists_CalendarId",
                table: "ShoppingLists",
                column: "CalendarId");

            migrationBuilder.CreateIndex(
                name: "IX_Meals_CalendarEntityCalendarId",
                table: "Meals",
                column: "CalendarEntityCalendarId");

            migrationBuilder.CreateIndex(
                name: "IX_Calendars_UserId",
                table: "Calendars",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserMealAssignments_MealId",
                table: "UserMealAssignments",
                column: "MealId");

            migrationBuilder.CreateIndex(
                name: "IX_UserMealAssignments_UserId",
                table: "UserMealAssignments",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Meals_Calendars_CalendarEntityCalendarId",
                table: "Meals",
                column: "CalendarEntityCalendarId",
                principalTable: "Calendars",
                principalColumn: "CalendarId");

            migrationBuilder.AddForeignKey(
                name: "FK_ShoppingLists_Calendars_CalendarId",
                table: "ShoppingLists",
                column: "CalendarId",
                principalTable: "Calendars",
                principalColumn: "CalendarId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
