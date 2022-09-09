using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Confitec.Technical.Test.Infra.Data.Migrations
{
    public partial class AddFullName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Password",
                schema: "dbo",
                table: "SystemUsers",
                type: "varchar(1000)",
                maxLength: 1000,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(255)",
                oldMaxLength: 255);

            migrationBuilder.AddColumn<string>(
                name: "FullName",
                schema: "dbo",
                table: "SystemUsers",
                type: "varchar(255)",
                maxLength: 255,
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FullName",
                schema: "dbo",
                table: "SystemUsers");

            migrationBuilder.AlterColumn<string>(
                name: "Password",
                schema: "dbo",
                table: "SystemUsers",
                type: "varchar(255)",
                maxLength: 255,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(1000)",
                oldMaxLength: 1000);
        }
    }
}
