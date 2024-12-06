using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TestApp.DAL.Migrations
{
    /// <inheritdoc />
    public partial class update31220240957 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Status",
                table: "PaymentProcesses",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Status",
                table: "PaymentProcesses");
        }
    }
}
