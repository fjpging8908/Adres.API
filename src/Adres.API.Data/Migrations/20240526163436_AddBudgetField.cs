using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Adres.API.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddBudgetField : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "Budget",
                schema: "Adres",
                table: "AcquisitionRequirement",
                type: "TEXT",
                nullable: false,
                defaultValue: 0m);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Budget",
                schema: "Adres",
                table: "AcquisitionRequirement");
        }
    }
}
