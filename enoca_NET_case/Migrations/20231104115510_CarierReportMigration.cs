using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace enoca_NET_case.Migrations
{
    /// <inheritdoc />
    public partial class CarierReportMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "carrier_reports",
                columns: table => new
                {
                    CarrierReportId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CarrierId = table.Column<int>(type: "int", nullable: false),
                    CarrierCost = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CarrierReportDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_carrier_reports", x => x.CarrierReportId);
                    table.ForeignKey(
                        name: "FK_carrier_reports_carriers_CarrierId",
                        column: x => x.CarrierId,
                        principalTable: "carriers",
                        principalColumn: "CarrierId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_carrier_reports_CarrierId",
                table: "carrier_reports",
                column: "CarrierId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "carrier_reports");
        }
    }
}
