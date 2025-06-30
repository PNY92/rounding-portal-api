using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RoundingPortal_API.Migrations
{
    /// <inheritdoc />
    public partial class AddedWorkstationRecordsandRounders : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Timestamp",
                table: "Workstations");

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

            migrationBuilder.CreateTable(
                name: "WorkstationRecords",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    WorkstationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RounderId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Display = table.Column<int>(type: "int", nullable: false),
                    Mouse_Keyboard = table.Column<int>(type: "int", nullable: false),
                    Kensington_Lock = table.Column<int>(type: "int", nullable: false),
                    Conduiting = table.Column<int>(type: "int", nullable: false),
                    Tidiness = table.Column<int>(type: "int", nullable: false),
                    Boot_To_Windows = table.Column<int>(type: "int", nullable: false),
                    Domain = table.Column<int>(type: "int", nullable: false),
                    Microsoft_Office = table.Column<int>(type: "int", nullable: false),
                    Microsoft_Teams = table.Column<int>(type: "int", nullable: false),
                    Browser = table.Column<int>(type: "int", nullable: false),
                    DeepFreeze_Frozen = table.Column<int>(type: "int", nullable: false),
                    DeepFreeze_Policy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Timestamp = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkstationRecords", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WorkstationRecords_Rounders_RounderId",
                        column: x => x.RounderId,
                        principalTable: "Rounders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_WorkstationRecords_Workstations_WorkstationId",
                        column: x => x.WorkstationId,
                        principalTable: "Workstations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_WorkstationRecords_RounderId",
                table: "WorkstationRecords",
                column: "RounderId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkstationRecords_WorkstationId",
                table: "WorkstationRecords",
                column: "WorkstationId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "WorkstationRecords");

            migrationBuilder.DropTable(
                name: "Rounders");

            migrationBuilder.AddColumn<DateTime>(
                name: "Timestamp",
                table: "Workstations",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
