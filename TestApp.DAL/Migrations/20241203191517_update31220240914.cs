using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TestApp.DAL.Migrations
{
    /// <inheritdoc />
    public partial class update31220240914 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "id",
                table: "PaymentProcesses",
                newName: "ID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ID",
                table: "PaymentProcesses",
                newName: "id");
        }
    }
}
