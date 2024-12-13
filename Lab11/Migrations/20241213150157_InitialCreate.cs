using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Lab11.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Flights",
                columns: table => new
                {
                    FlightId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FlightNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Destination = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Flights", x => x.FlightId);
                });

            migrationBuilder.CreateTable(
                name: "FlightRoutes",
                columns: table => new
                {
                    RouteId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FlightId = table.Column<int>(type: "int", nullable: false),
                    RouteDetails = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FlightRoutes", x => x.RouteId);
                    table.ForeignKey(
                        name: "FK_FlightRoutes_Flights_FlightId",
                        column: x => x.FlightId,
                        principalTable: "Flights",
                        principalColumn: "FlightId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FlightSchedules",
                columns: table => new
                {
                    ScheduleId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FlightId = table.Column<int>(type: "int", nullable: false),
                    DepartureDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FlightSchedules", x => x.ScheduleId);
                    table.ForeignKey(
                        name: "FK_FlightSchedules_Flights_FlightId",
                        column: x => x.FlightId,
                        principalTable: "Flights",
                        principalColumn: "FlightId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Flights",
                columns: new[] { "FlightId", "Destination", "FlightNumber" },
                values: new object[,]
                {
                    { 1, "New York", "AA123" },
                    { 2, "London", "BA456" },
                    { 3, "Tokyo", "CA789" }
                });

            migrationBuilder.InsertData(
                table: "FlightRoutes",
                columns: new[] { "RouteId", "FlightId", "RouteDetails" },
                values: new object[,]
                {
                    { 1, 1, "NYC to JFK" },
                    { 2, 2, "LHR to Heathrow" },
                    { 3, 3, "HND to Narita" }
                });

            migrationBuilder.InsertData(
                table: "FlightSchedules",
                columns: new[] { "ScheduleId", "DepartureDate", "FlightId" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 12, 13, 0, 0, 0, 0, DateTimeKind.Local), 1 },
                    { 2, new DateTime(2024, 12, 14, 0, 0, 0, 0, DateTimeKind.Local), 2 },
                    { 3, new DateTime(2024, 12, 13, 0, 0, 0, 0, DateTimeKind.Local), 3 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_FlightRoutes_FlightId",
                table: "FlightRoutes",
                column: "FlightId");

            migrationBuilder.CreateIndex(
                name: "IX_FlightSchedules_FlightId",
                table: "FlightSchedules",
                column: "FlightId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FlightRoutes");

            migrationBuilder.DropTable(
                name: "FlightSchedules");

            migrationBuilder.DropTable(
                name: "Flights");
        }
    }
}
