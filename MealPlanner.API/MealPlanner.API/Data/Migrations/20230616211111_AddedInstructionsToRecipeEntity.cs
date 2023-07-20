using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MealPlanner.API.Migrations
{
    /// <inheritdoc />
    public partial class AddedInstructionsToRecipeEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RecipeInstructions_Recipes_RecipeId",
                table: "RecipeInstructions");

            migrationBuilder.DropIndex(
                name: "IX_RecipeInstructions_RecipeId",
                table: "RecipeInstructions");

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

            migrationBuilder.AddColumn<List<string>>(
                name: "Instructions",
                table: "Recipes",
                type: "text[]",
                nullable: false);

            migrationBuilder.InsertData(
                table: "Recipes",
                columns: new[] { "Id", "Instructions", "Name" },
                values: new object[,]
                {
                    { new Guid("6242ca38-53c5-4bff-afd1-9fd185393982"), new List<string>(), "Chickpea Pasta" },
                    { new Guid("6565cb5a-23bb-499f-ad9a-072c8fa18aad"), new List<string>(), "Chicken Salad" },
                    { new Guid("896ee634-d9a3-4da3-b921-7e6464f460e2"), new List<string>(), "Chickpea Salad" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: new Guid("6242ca38-53c5-4bff-afd1-9fd185393982"));

            migrationBuilder.DeleteData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: new Guid("6565cb5a-23bb-499f-ad9a-072c8fa18aad"));

            migrationBuilder.DeleteData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: new Guid("896ee634-d9a3-4da3-b921-7e6464f460e2"));

            migrationBuilder.DropColumn(
                name: "Instructions",
                table: "Recipes");

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
                name: "IX_RecipeInstructions_RecipeId",
                table: "RecipeInstructions",
                column: "RecipeId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_RecipeInstructions_Recipes_RecipeId",
                table: "RecipeInstructions",
                column: "RecipeId",
                principalTable: "Recipes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
