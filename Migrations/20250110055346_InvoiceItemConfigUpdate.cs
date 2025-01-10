using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InvoiceAPI.Migrations
{
    /// <inheritdoc />
    public partial class InvoiceItemConfigUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ProductId1",
                table: "InvoiceItems",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_InvoiceItems_ProductId1",
                table: "InvoiceItems",
                column: "ProductId1");

            migrationBuilder.AddForeignKey(
                name: "FK_InvoiceItems_Products_ProductId1",
                table: "InvoiceItems",
                column: "ProductId1",
                principalTable: "Products",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_InvoiceItems_Products_ProductId1",
                table: "InvoiceItems");

            migrationBuilder.DropIndex(
                name: "IX_InvoiceItems_ProductId1",
                table: "InvoiceItems");

            migrationBuilder.DropColumn(
                name: "ProductId1",
                table: "InvoiceItems");
        }
    }
}
