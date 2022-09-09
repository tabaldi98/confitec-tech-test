using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Confitec.Technical.Test.Infra.Data.Migrations
{
    public partial class addRevocerypass : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "RecoveryPassword",
                schema: "dbo",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    ExpirationDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    IsUsed = table.Column<bool>(type: "bit", nullable: false),
                    SystemUserID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RecoveryPassword", x => x.ID);
                    table.ForeignKey(
                        name: "FK_RecoveryPassword_SystemUsers_SystemUserID",
                        column: x => x.SystemUserID,
                        principalSchema: "dbo",
                        principalTable: "SystemUsers",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Parameters",
                keyColumn: "ID",
                keyValue: 1,
                column: "LastDateUpdated",
                value: new DateTime(2022, 9, 9, 14, 24, 21, 285, DateTimeKind.Local).AddTicks(8400));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Parameters",
                keyColumn: "ID",
                keyValue: 2,
                column: "LastDateUpdated",
                value: new DateTime(2022, 9, 9, 14, 24, 21, 285, DateTimeKind.Local).AddTicks(8403));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "SystemUsers",
                keyColumn: "ID",
                keyValue: 1,
                columns: new[] { "CreateDate", "FullName", "Mail" },
                values: new object[] { new DateTime(2022, 9, 9, 14, 24, 21, 285, DateTimeKind.Local).AddTicks(8292), "Administrador do Sistema", "andersonandi_t@hotmail.com" });

            migrationBuilder.CreateIndex(
                name: "IX_RecoveryPassword_SystemUserID",
                schema: "dbo",
                table: "RecoveryPassword",
                column: "SystemUserID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RecoveryPassword",
                schema: "dbo");

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

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "SystemUsers",
                keyColumn: "ID",
                keyValue: 1,
                columns: new[] { "CreateDate", "FullName", "Mail" },
                values: new object[] { new DateTime(2022, 9, 9, 9, 10, 55, 729, DateTimeKind.Local).AddTicks(816), "Administrador", "tabaldi98@gmail.com" });
        }
    }
}
