using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace itApp.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class migtelnoadded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "EmployeTelNo",
                table: "Employees",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "RemainingLeaveDays",
                table: "Employees",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EmployeTelNo",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "RemainingLeaveDays",
                table: "Employees");
        }
    }
}
