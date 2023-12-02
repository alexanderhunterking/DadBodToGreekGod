using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DadBodToGreekGod.Data.Migrations
{
    /// <inheritdoc />
    public partial class newMacroFuncitonality : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Macros_Users_OwnerId",
                table: "Macros");

            migrationBuilder.DropIndex(
                name: "IX_Macros_OwnerId",
                table: "Macros");

            migrationBuilder.RenameColumn(
                name: "OwnerId",
                table: "Macros",
                newName: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Macros_UserId",
                table: "Macros",
                column: "UserId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Macros_UserId",
                table: "Macros");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Macros",
                newName: "OwnerId");

            migrationBuilder.CreateIndex(
                name: "IX_Macros_OwnerId",
                table: "Macros",
                column: "OwnerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Macros_Users_OwnerId",
                table: "Macros",
                column: "OwnerId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
