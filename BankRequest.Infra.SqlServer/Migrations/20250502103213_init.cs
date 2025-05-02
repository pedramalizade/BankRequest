using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BankRequest.Infra.SqlServer.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Accounts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ShebaNumber = table.Column<string>(type: "nvarchar(24)", maxLength: 24, nullable: false),
                    AvailableBalance = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Accounts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ShebaRequests",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Price = table.Column<long>(type: "bigint", nullable: false),
                    FromShebaNumber = table.Column<string>(type: "nvarchar(24)", maxLength: 24, nullable: false),
                    ToShebaNumber = table.Column<string>(type: "nvarchar(24)", maxLength: 24, nullable: false),
                    Note = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShebaRequests", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Transactions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RequestId = table.Column<int>(type: "int", nullable: false),
                    Amount = table.Column<long>(type: "bigint", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transactions", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Accounts",
                columns: new[] { "Id", "AvailableBalance", "ShebaNumber" },
                values: new object[,]
                {
                    { 1, 10000000L, "IR9801234567890123456780" },
                    { 2, 10000000L, "IR9809876543210123456700" },
                    { 3, 10000000L, "IR9801234567890123456790" },
                    { 4, 10000000L, "IR9809876543210123456000" }
                });

            migrationBuilder.InsertData(
                table: "ShebaRequests",
                columns: new[] { "Id", "CreatedAt", "FromShebaNumber", "Note", "Price", "Status", "ToShebaNumber" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "IR9801234567890123456780", "Test request 1", 100000L, 0, "IR9801234567890123456790" },
                    { 2, new DateTime(2024, 5, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "IR9809876543210123456700", "Test request 2", 200000L, 0, "IR9809876543210123456000" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Accounts");

            migrationBuilder.DropTable(
                name: "ShebaRequests");

            migrationBuilder.DropTable(
                name: "Transactions");
        }
    }
}
