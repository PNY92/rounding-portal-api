using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RoundingPortal_API.Migrations
{
    /// <inheritdoc />
    public partial class ChangedRounderclasstoUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Issues_Rounders_ReporterId",
                table: "Issues");

            migrationBuilder.DropForeignKey(
                name: "FK_WorkstationRecords_Rounders_RounderId",
                table: "WorkstationRecords");

            migrationBuilder.DropTable(
                name: "Rounders");

            migrationBuilder.AddColumn<int>(
                name: "Shift",
                table: "WorkstationRecords",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Issues_Users_ReporterId",
                table: "Issues",
                column: "ReporterId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_WorkstationRecords_Users_RounderId",
                table: "WorkstationRecords",
                column: "RounderId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Issues_Users_ReporterId",
                table: "Issues");

            migrationBuilder.DropForeignKey(
                name: "FK_WorkstationRecords_Users_RounderId",
                table: "WorkstationRecords");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropColumn(
                name: "Shift",
                table: "WorkstationRecords");

            migrationBuilder.CreateTable(
                name: "Rounders",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Shift = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rounders", x => x.Id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Issues_Rounders_ReporterId",
                table: "Issues",
                column: "ReporterId",
                principalTable: "Rounders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_WorkstationRecords_Rounders_RounderId",
                table: "WorkstationRecords",
                column: "RounderId",
                principalTable: "Rounders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
