using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RoundingPortal_API.Migrations
{
    /// <inheritdoc />
    public partial class Newmigrationv2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Workstation",
                table: "Issues");

            migrationBuilder.AddColumn<Guid>(
                name: "WorkstationId",
                table: "Issues",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Issues_WorkstationId",
                table: "Issues",
                column: "WorkstationId");

            migrationBuilder.AddForeignKey(
                name: "FK_Issues_Workstations_WorkstationId",
                table: "Issues",
                column: "WorkstationId",
                principalTable: "Workstations",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Issues_Workstations_WorkstationId",
                table: "Issues");

            migrationBuilder.DropIndex(
                name: "IX_Issues_WorkstationId",
                table: "Issues");

            migrationBuilder.DropColumn(
                name: "WorkstationId",
                table: "Issues");

            migrationBuilder.AddColumn<string>(
                name: "Workstation",
                table: "Issues",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
