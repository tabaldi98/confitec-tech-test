using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Confitec.Technical.Test.Infra.Data.Migrations
{
    public partial class LastUpdatePass : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Parameters",
                keyColumn: "ID",
                keyValue: 1);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastUpdatePasswordDate",
                schema: "dbo",
                table: "SystemUsers",
                type: "datetime",
                nullable: true);

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LastUpdatePasswordDate",
                schema: "dbo",
                table: "SystemUsers");

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Parameters",
                keyColumn: "ID",
                keyValue: 2,
                column: "LastDateUpdated",
                value: new DateTime(2022, 9, 12, 9, 45, 0, 492, DateTimeKind.Local).AddTicks(1081));

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "Parameters",
                columns: new[] { "ID", "Key", "LastDateUpdated", "Value" },
                values: new object[] { 1, "SIDE_BAR_TYPE", new DateTime(2022, 9, 12, 9, 45, 0, 492, DateTimeKind.Local).AddTicks(1077), "1" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "SystemUsers",
                keyColumn: "ID",
                keyValue: 1,
                column: "CreateDate",
                value: new DateTime(2022, 9, 12, 9, 45, 0, 492, DateTimeKind.Local).AddTicks(972));
        }
    }
}
