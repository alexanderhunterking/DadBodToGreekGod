using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DadBodToGreekGod.Data.Migrations
{
    /// <inheritdoc />
    public partial class NewMealIngredientFunctionality : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "MealIngredients",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_MealIngredients_UserId",
                table: "MealIngredients",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_MealIngredients_Users_UserId",
                table: "MealIngredients",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MealIngredients_Users_UserId",
                table: "MealIngredients");

            migrationBuilder.DropIndex(
                name: "IX_MealIngredients_UserId",
                table: "MealIngredients");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "MealIngredients");
        }
    }
}
