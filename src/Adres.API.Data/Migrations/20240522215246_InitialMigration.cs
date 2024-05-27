using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Adres.API.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Adres");

            migrationBuilder.CreateTable(
                name: "AcquisitionRequirement",
                schema: "Adres",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Number = table.Column<int>(type: "INTEGER", nullable: false),
                    BusinessUnity = table.Column<string>(type: "TEXT", nullable: true),
                    Type = table.Column<string>(type: "TEXT", nullable: true),
                    Quantity = table.Column<int>(type: "INTEGER", nullable: false),
                    UnitaryValue = table.Column<decimal>(type: "TEXT", nullable: false),
                    TotalAmount = table.Column<decimal>(type: "TEXT", nullable: false),
                    AcquisitionDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Provider = table.Column<string>(type: "TEXT", nullable: true),
                    Document = table.Column<string>(type: "TEXT", nullable: true),
                    Enable = table.Column<bool>(type: "INTEGER", nullable: false),
                    version = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AcquisitionRequirement", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AcquisitionRequirement",
                schema: "Adres");
        }
    }
}
