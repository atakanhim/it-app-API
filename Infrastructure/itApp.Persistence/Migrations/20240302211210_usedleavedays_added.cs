using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace itApp.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class usedleavedays_added : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "RemainingLeaveDays",
                table: "Employees",
                newName: "UsedLeaveDays");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UsedLeaveDays",
                table: "Employees",
                newName: "RemainingLeaveDays");
        }
    }
}
