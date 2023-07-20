using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MealPlanner.API.Migrations
{
    /// <inheritdoc />
    public partial class UpdatedRecipeEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: new Guid("1c2909dd-7c82-4234-bad5-4390d8c27061"));

            migrationBuilder.DeleteData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: new Guid("5975f506-0ef6-4ed6-807c-5cba6463f6c2"));

            migrationBuilder.DeleteData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: new Guid("ded9a105-15bf-42de-ba11-f9c74321d2dc"));

            migrationBuilder.AddColumn<Guid>(
                name: "RecipeId",
                table: "Pantry",
                type: "uuid",
                nullable: true);

            migrationBuilder.InsertData(
                table: "Recipes",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("0742bef6-3c7d-428e-b64f-3fa1eacbb108"), "Chickpea Pasta" },
                    { new Guid("31b2e686-8b50-429e-a090-7a969b8ca07e"), "Chickpea Salad" },
                    { new Guid("5a6aff3e-65f1-4a93-9818-f78c4b321c78"), "Chicken Salad" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Pantry_RecipeId",
                table: "Pantry",
                column: "RecipeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Pantry_Recipes_RecipeId",
                table: "Pantry",
                column: "RecipeId",
                principalTable: "Recipes",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pantry_Recipes_RecipeId",
                table: "Pantry");

            migrationBuilder.DropIndex(
                name: "IX_Pantry_RecipeId",
                table: "Pantry");

            migrationBuilder.DeleteData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: new Guid("0742bef6-3c7d-428e-b64f-3fa1eacbb108"));

            migrationBuilder.DeleteData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: new Guid("31b2e686-8b50-429e-a090-7a969b8ca07e"));

            migrationBuilder.DeleteData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: new Guid("5a6aff3e-65f1-4a93-9818-f78c4b321c78"));

            migrationBuilder.DropColumn(
                name: "RecipeId",
                table: "Pantry");

            migrationBuilder.InsertData(
                table: "Recipes",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("1c2909dd-7c82-4234-bad5-4390d8c27061"), "Chickpea Pasta" },
                    { new Guid("5975f506-0ef6-4ed6-807c-5cba6463f6c2"), "Chicken Salad" },
                    { new Guid("ded9a105-15bf-42de-ba11-f9c74321d2dc"), "Chickpea Salad" }
                });
        }
    }
}
