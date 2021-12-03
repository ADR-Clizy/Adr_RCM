using Microsoft.EntityFrameworkCore.Migrations;

namespace DatabaseConnection.Migrations
{
    public partial class ChangingIdNames : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Restorers",
                newName: "RestorerId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Cards",
                newName: "CardId");

            migrationBuilder.AlterColumn<string>(
                name: "CardName",
                table: "Cards",
                type: "nvarchar(40)",
                maxLength: 40,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "RestorerId",
                table: "Restorers",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "CardId",
                table: "Cards",
                newName: "Id");

            migrationBuilder.AlterColumn<string>(
                name: "CardName",
                table: "Cards",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(40)",
                oldMaxLength: 40);
        }
    }
}
