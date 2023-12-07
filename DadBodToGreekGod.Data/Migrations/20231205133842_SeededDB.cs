using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DadBodToGreekGod.Data.Migrations
{
    /// <inheritdoc />
    public partial class SeededDB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Ingredients",
                columns: new[] { "IngredientId", "CaloriesPer100g", "CarbsPer100g", "FatPer100g", "Name", "ProteinPer100g" },
                values: new object[,]
                {
                    { 2, 250.0, 0.0, 17.0, "Ground Beef", 26.0 },
                    { 3, 206.0, 0.0, 13.0, "Salmon", 25.0 },
                    { 4, 55.0, 11.0, 0.59999999999999998, "Broccoli", 3.7000000000000002 },
                    { 5, 23.0, 3.6000000000000001, 0.40000000000000002, "Spinach", 2.8999999999999999 },
                    { 6, 86.0, 20.100000000000001, 0.10000000000000001, "Sweet Potato", 1.6000000000000001 },
                    { 7, 130.0, 28.0, 0.20000000000000001, "White Rice", 2.7000000000000002 },
                    { 100, 165.0, 0.0, 3.6000000000000001, "Chicken Breast", 31.0 },
                    { 101, 120.0, 21.0, 1.8999999999999999, "Quinoa", 4.0 },
                    { 102, 120.0, 21.0, 1.8999999999999999, "Quinoa", 4.0 },
                    { 104, 135.0, 0.0, 1.0, "Turkey Breast", 29.0 },
                    { 105, 250.0, 0.0, 17.0, "Steak", 26.0 },
                    { 106, 143.0, 0.0, 7.0, "Pork Chops", 21.0 },
                    { 107, 82.0, 0.0, 1.0, "Cod", 18.0 },
                    { 108, 116.0, 0.0, 1.0, "Tuna", 25.0 },
                    { 109, 96.0, 0.0, 1.7, "Tilapia", 21.0 },
                    { 110, 98.0, 3.3999999999999999, 4.2999999999999998, "Cottage Cheese", 11.0 },
                    { 111, 144.0, 3.8999999999999999, 8.0, "Tofu", 15.0 },
                    { 112, 109.0, 0.0, 1.0, "Canned Tuna", 24.0 },
                    { 113, 132.0, 23.699999999999999, 0.5, "Black Beans", 8.9000000000000004 },
                    { 115, 85.0, 0.0, 1.2, "Shrimp", 20.0 },
                    { 116, 61.0, 4.7999999999999998, 3.7000000000000002, "Whole Milk", 3.2000000000000002 },
                    { 118, 318.0, 1.6000000000000001, 25.0, "Mozzarella Cheese", 22.0 },
                    { 119, 403.0, 1.3, 33.0, "Cheddar Cheese", 25.0 },
                    { 120, 389.0, 2.6000000000000001, 32.0, "Colby Jack Cheese", 23.0 },
                    { 121, 576.0, 22.0, 49.0, "Almonds", 21.0 },
                    { 122, 143.0, 1.1000000000000001, 9.5, "Eggs", 13.0 },
                    { 123, 111.0, 23.5, 0.90000000000000002, "Brown Rice", 2.6000000000000001 },
                    { 124, 77.0, 17.0, 0.10000000000000001, "Potatoes", 2.0 },
                    { 125, 68.0, 12.0, 1.3999999999999999, "Oatmeal", 2.3999999999999999 },
                    { 126, 43.0, 8.3000000000000007, 0.29999999999999999, "Brussels Sprouts", 3.3999999999999999 },
                    { 127, 49.0, 8.8000000000000007, 0.90000000000000002, "Kale", 4.2999999999999998 },
                    { 128, 25.0, 5.0, 0.29999999999999999, "Cauliflower", 1.8999999999999999 },
                    { 129, 43.0, 10.0, 0.5, "Blackberries", 2.0 },
                    { 130, 31.0, 7.0, 0.20000000000000001, "Green Beans", 1.8 },
                    { 131, 89.0, 23.0, 0.29999999999999999, "Bananas", 1.1000000000000001 },
                    { 132, 32.0, 8.0, 0.29999999999999999, "Strawberries", 0.69999999999999996 },
                    { 133, 52.0, 11.0, 0.69999999999999996, "Raspberries", 1.2 },
                    { 134, 50.0, 13.0, 0.10000000000000001, "Pineapple", 0.5 },
                    { 135, 57.0, 14.0, 0.29999999999999999, "Blueberries", 0.69999999999999996 },
                    { 136, 41.0, 10.0, 0.20000000000000001, "Carrots", 0.90000000000000002 },
                    { 137, 18.0, 3.8999999999999999, 0.20000000000000001, "Tomatoes", 0.90000000000000002 },
                    { 138, 31.0, 6.0, 0.29999999999999999, "Bell Peppers", 1.0 },
                    { 139, 160.0, 8.5, 14.699999999999999, "Avocado", 2.0 },
                    { 200, 59.0, 3.6000000000000001, 0.40000000000000002, "Greek Yogurt", 10.0 },
                    { 201, 132.0, 23.699999999999999, 0.5, "Black Beans", 8.9000000000000004 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 100);

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 101);

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 102);

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 104);

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 105);

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 106);

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 107);

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 108);

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 109);

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 110);

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 111);

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 112);

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 113);

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 115);

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 116);

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 118);

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 119);

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 120);

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 121);

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 122);

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 123);

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 124);

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 125);

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 126);

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 127);

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 128);

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 129);

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 130);

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 131);

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 132);

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 133);

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 134);

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 135);

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 136);

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 137);

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 138);

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 139);

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 200);

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 201);
        }
    }
}
