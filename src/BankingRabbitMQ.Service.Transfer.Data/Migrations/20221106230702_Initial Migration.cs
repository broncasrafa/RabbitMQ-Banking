using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BankingRabbitMQ.Service.Transfer.Data.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "dbo");

            migrationBuilder.CreateTable(
                name: "TransferLogs",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FromAccount = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ToAccount = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TransferAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TransferLogs", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TransferLogs",
                schema: "dbo");
        }
    }
}
