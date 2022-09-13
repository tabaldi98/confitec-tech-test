using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Confitec.Technical.Test.Infra.Data.Migrations
{
    public partial class aproveuser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsAproved",
                schema: "dbo",
                table: "SystemUsers",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Parameters",
                keyColumn: "ID",
                keyValue: 2,
                column: "LastDateUpdated",
                value: new DateTime(2022, 9, 12, 18, 16, 17, 551, DateTimeKind.Local).AddTicks(4747));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "SystemUsers",
                keyColumn: "ID",
                keyValue: 1,
                columns: new[] { "CreateDate", "IsAproved", "LastUpdatePasswordDate" },
                values: new object[] { new DateTime(2022, 9, 12, 18, 16, 17, 551, DateTimeKind.Local).AddTicks(4648), true, new DateTime(2022, 9, 12, 18, 16, 17, 551, DateTimeKind.Local).AddTicks(4655) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsAproved",
                schema: "dbo",
                table: "SystemUsers");

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Parameters",
                keyColumn: "ID",
                keyValue: 2,
                column: "LastDateUpdated",
                value: new DateTime(2022, 9, 12, 10, 38, 27, 473, DateTimeKind.Local).AddTicks(9135));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "SystemUsers",
                keyColumn: "ID",
                keyValue: 1,
                columns: new[] { "CreateDate", "LastUpdatePasswordDate" },
                values: new object[] { new DateTime(2022, 9, 12, 10, 38, 27, 473, DateTimeKind.Local).AddTicks(9029), new DateTime(2022, 9, 12, 10, 38, 27, 473, DateTimeKind.Local).AddTicks(9036) });
        }
    }
}
