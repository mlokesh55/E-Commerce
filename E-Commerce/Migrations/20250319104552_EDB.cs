using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace E_Commerce.Migrations
{
    /// <inheritdoc />
    public partial class EDB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_ShoppingCartTable_UserId",
                table: "ShoppingCartTable");

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "ShoppingCartTable",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "CartItems",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_ShoppingCartTable_UserId",
                table: "ShoppingCartTable",
                column: "UserId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_ShoppingCartTable_UserId",
                table: "ShoppingCartTable");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "ShoppingCartTable");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "CartItems");

            migrationBuilder.CreateIndex(
                name: "IX_ShoppingCartTable_UserId",
                table: "ShoppingCartTable",
                column: "UserId");
        }
    }
}
