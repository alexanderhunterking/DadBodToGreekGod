using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DadBodToGreekGod.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddedNewFeatures : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Calendars",
                columns: table => new
                {
                    CalendarId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    ShoppingDay = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CookingDay = table.Column<string>(type: "nvarchar(max)", nullable: false)
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
                name: "Ingredients",
                columns: table => new
                {
                    IngredientId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CaloriesPer100g = table.Column<double>(type: "float", nullable: false),
                    ProteinPer100g = table.Column<double>(type: "float", nullable: false),
                    CarbsPer100g = table.Column<double>(type: "float", nullable: false),
                    FatPer100g = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ingredients", x => x.IngredientId);
                });

               migrationBuilder.CreateTable(
        name: "Meals",
        columns: table => new
        {
            MealId = table.Column<int>(type: "int", nullable: false)
                .Annotation("SqlServer:Identity", "1, 1"),
            UserId = table.Column<int>(type: "int", nullable: false),
            CalendarId = table.Column<int>(type: "int", nullable: false),
            MealName = table.Column<string>(type: "nvarchar(max)", nullable: false),
            Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
        },
        constraints: table =>
        {
            table.PrimaryKey("PK_Meals", x => x.MealId);
            table.ForeignKey(
                name: "FK_Meals_Calendars_CalendarId",
                column: x => x.CalendarId,
                principalTable: "Calendars",
                principalColumn: "CalendarId",
                onDelete: ReferentialAction.NoAction);  // Change here
            table.ForeignKey(
                name: "FK_Meals_Users_UserId",
                column: x => x.UserId,
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);  // Change here
        });

               migrationBuilder.CreateTable(
        name: "ShoppingLists",
        columns: table => new
        {
            ShoppingListId = table.Column<int>(type: "int", nullable: false)
                .Annotation("SqlServer:Identity", "1, 1"),
            UserId = table.Column<int>(type: "int", nullable: false),
            CalendarId = table.Column<int>(type: "int", nullable: false),
            IngredientId = table.Column<int>(type: "int", nullable: false),
            Quantity = table.Column<double>(type: "float", nullable: false)
        },
        constraints: table =>
        {
            table.PrimaryKey("PK_ShoppingLists", x => x.ShoppingListId);
            table.ForeignKey(
                name: "FK_ShoppingLists_Calendars_CalendarId",
                column: x => x.CalendarId,
                principalTable: "Calendars",
                principalColumn: "CalendarId",
                onDelete: ReferentialAction.Cascade);
            table.ForeignKey(
                name: "FK_ShoppingLists_Ingredients_IngredientId",
                column: x => x.IngredientId,
                principalTable: "Ingredients",
                principalColumn: "IngredientId",
                onDelete: ReferentialAction.Cascade);
            table.ForeignKey(
                name: "FK_ShoppingLists_Users_UserId",
                column: x => x.UserId,
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);  // Change here
        });

            migrationBuilder.CreateTable(
                name: "MealIngredients",
                columns: table => new
                {
                    MealIngredientId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MealId = table.Column<int>(type: "int", nullable: false),
                    IngredientId = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MealIngredients", x => x.MealIngredientId);
                    table.ForeignKey(
                        name: "FK_MealIngredients_Ingredients_IngredientId",
                        column: x => x.IngredientId,
                        principalTable: "Ingredients",
                        principalColumn: "IngredientId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MealIngredients_Meals_MealId",
                        column: x => x.MealId,
                        principalTable: "Meals",
                        principalColumn: "MealId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
    name: "UserMealAssignments",
    columns: table => new
    {
        UserMealAssignmentId = table.Column<int>(type: "int", nullable: false)
            .Annotation("SqlServer:Identity", "1, 1"),  // Added identity specification
        UserId = table.Column<int>(type: "int", nullable: false),
        MealId = table.Column<int>(type: "int", nullable: false),
        TimeOfDay = table.Column<int>(type: "int", nullable: false)
    },
    constraints: table =>
    {
        table.PrimaryKey("PK_UserMealAssignments", x => x.UserMealAssignmentId);
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
                name: "IX_Calendars_UserId",
                table: "Calendars",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_MealIngredients_IngredientId",
                table: "MealIngredients",
                column: "IngredientId");

            migrationBuilder.CreateIndex(
                name: "IX_MealIngredients_MealId",
                table: "MealIngredients",
                column: "MealId");

            migrationBuilder.CreateIndex(
                name: "IX_Meals_CalendarId",
                table: "Meals",
                column: "CalendarId");

            migrationBuilder.CreateIndex(
                name: "IX_Meals_UserId",
                table: "Meals",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_ShoppingLists_CalendarId",
                table: "ShoppingLists",
                column: "CalendarId");

            migrationBuilder.CreateIndex(
                name: "IX_ShoppingLists_IngredientId",
                table: "ShoppingLists",
                column: "IngredientId");

            migrationBuilder.CreateIndex(
                name: "IX_ShoppingLists_UserId",
                table: "ShoppingLists",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserMealAssignments_MealId",
                table: "UserMealAssignments",
                column: "MealId");

            migrationBuilder.CreateIndex(
                name: "IX_UserMealAssignments_UserId",
                table: "UserMealAssignments",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MealIngredients");

            migrationBuilder.DropTable(
                name: "ShoppingLists");

            migrationBuilder.DropTable(
                name: "UserMealAssignments");

            migrationBuilder.DropTable(
                name: "Ingredients");

            migrationBuilder.DropTable(
                name: "Meals");

            migrationBuilder.DropTable(
                name: "Calendars");
        }
    }
}
