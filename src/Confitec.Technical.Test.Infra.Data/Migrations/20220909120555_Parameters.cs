using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Confitec.Technical.Test.Infra.Data.Migrations
{
    public partial class Parameters : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Parameters",
                schema: "dbo",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Key = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false),
                    Value = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false),
                    LastDateUpdated = table.Column<DateTime>(type: "datetime", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Parameters", x => x.ID);
                });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "Parameters",
                columns: new[] { "ID", "Key", "LastDateUpdated", "Value" },
                values: new object[] { 1, "SIDE_BAR_TYPE", new DateTime(2022, 9, 9, 9, 5, 54, 817, DateTimeKind.Local).AddTicks(2930), "1" });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "Parameters",
                columns: new[] { "ID", "Key", "LastDateUpdated", "Value" },
                values: new object[] { 2, "SESSION_TIME", new DateTime(2022, 9, 9, 9, 5, 54, 817, DateTimeKind.Local).AddTicks(2940), "120" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Parameters",
                schema: "dbo");
        }
    }
}
