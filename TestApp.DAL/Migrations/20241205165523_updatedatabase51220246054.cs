using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TestApp.DAL.Migrations
{
    /// <inheritdoc />
    public partial class updatedatabase51220246054 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PaymentProcesses_Products_ProductId",
                table: "PaymentProcesses");

            migrationBuilder.DropIndex(
                name: "IX_PaymentProcesses_ProductId",
                table: "PaymentProcesses");

            migrationBuilder.DropColumn(
                name: "ProductId",
                table: "PaymentProcesses");

            migrationBuilder.AddColumn<string>(
                name: "productName",
                table: "PaymentProcesses",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "productName",
                table: "PaymentProcesses");

            migrationBuilder.AddColumn<int>(
                name: "ProductId",
                table: "PaymentProcesses",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_PaymentProcesses_ProductId",
                table: "PaymentProcesses",
                column: "ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_PaymentProcesses_Products_ProductId",
                table: "PaymentProcesses",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
