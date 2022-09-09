using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Confitec.Technical.Test.Infra.Data.Migrations
{
    public partial class DefaultUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Parameters",
                keyColumn: "ID",
                keyValue: 1,
                column: "LastDateUpdated",
                value: new DateTime(2022, 9, 9, 9, 10, 55, 729, DateTimeKind.Local).AddTicks(923));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Parameters",
                keyColumn: "ID",
                keyValue: 2,
                column: "LastDateUpdated",
                value: new DateTime(2022, 9, 9, 9, 10, 55, 729, DateTimeKind.Local).AddTicks(927));

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "SystemUsers",
                columns: new[] { "ID", "CreateDate", "FullName", "LastLoginDate", "Mail", "Password", "UserName" },
                values: new object[] { 1, new DateTime(2022, 9, 9, 9, 10, 55, 729, DateTimeKind.Local).AddTicks(816), "Administrador", null, "tabaldi98@gmail.com", "123", "admin" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "SystemUsers",
                keyColumn: "ID",
                keyValue: 1);

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Parameters",
                keyColumn: "ID",
                keyValue: 1,
                column: "LastDateUpdated",
                value: new DateTime(2022, 9, 9, 9, 10, 8, 493, DateTimeKind.Local).AddTicks(2209));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Parameters",
                keyColumn: "ID",
                keyValue: 2,
                column: "LastDateUpdated",
                value: new DateTime(2022, 9, 9, 9, 10, 8, 493, DateTimeKind.Local).AddTicks(2224));
        }
    }
}
