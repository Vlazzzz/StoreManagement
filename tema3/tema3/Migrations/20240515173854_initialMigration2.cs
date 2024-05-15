using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace tema3.Migrations
{
    /// <inheritdoc />
    public partial class initialMigration2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Receipts_Products_ProductId",
                table: "Receipts");

            migrationBuilder.DropIndex(
                name: "IX_Receipts_ProductId",
                table: "Receipts");

            migrationBuilder.DropColumn(
                name: "ProductId",
                table: "Receipts");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ProductId",
                table: "Receipts",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Receipts_ProductId",
                table: "Receipts",
                column: "ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_Receipts_Products_ProductId",
                table: "Receipts",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "ProductId");
        }
    }
}
