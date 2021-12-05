using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DatabaseConnection.Migrations
{
    public partial class AddingRestorerClaim : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DateOfSubscription",
                table: "Restorers");

            migrationBuilder.AlterColumn<string>(
                name: "Password",
                table: "Restorers",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateTable(
                name: "RestorerClaims",
                columns: table => new
                {
                    RestorerClaimId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClaimGUID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EndOfGUID = table.Column<DateTime>(type: "datetime2", nullable: false),
                    RestorerId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RestorerClaims", x => x.RestorerClaimId);
                    table.ForeignKey(
                        name: "FK_RestorerClaims_Restorers_RestorerId",
                        column: x => x.RestorerId,
                        principalTable: "Restorers",
                        principalColumn: "RestorerId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_RestorerClaims_RestorerId",
                table: "RestorerClaims",
                column: "RestorerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RestorerClaims");

            migrationBuilder.AlterColumn<string>(
                name: "Password",
                table: "Restorers",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(20)",
                oldMaxLength: 20);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateOfSubscription",
                table: "Restorers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
