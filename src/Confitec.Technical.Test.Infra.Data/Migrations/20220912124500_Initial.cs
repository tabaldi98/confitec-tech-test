using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Confitec.Technical.Test.Infra.Data.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "dbo");

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

            migrationBuilder.CreateTable(
                name: "SystemUsers",
                schema: "dbo",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FullName = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false),
                    UserName = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false),
                    Password = table.Column<string>(type: "varchar(1000)", maxLength: 1000, nullable: false),
                    Mail = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    LastLoginDate = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SystemUsers", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                schema: "dbo",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false),
                    Surname = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false),
                    Mail = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false),
                    BirthDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    Scholarity = table.Column<byte>(type: "tinyint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.ID);
                });

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

            migrationBuilder.CreateTable(
                name: "SystemUserPermissions",
                schema: "dbo",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Role = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false),
                    SystemUserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SystemUserPermissions", x => x.ID);
                    table.ForeignKey(
                        name: "FK_SystemUserPermissions_SystemUsers_SystemUserId",
                        column: x => x.SystemUserId,
                        principalSchema: "dbo",
                        principalTable: "SystemUsers",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "Parameters",
                columns: new[] { "ID", "Key", "LastDateUpdated", "Value" },
                values: new object[] { 1, "SIDE_BAR_TYPE", new DateTime(2022, 9, 12, 9, 45, 0, 492, DateTimeKind.Local).AddTicks(1077), "1" });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "Parameters",
                columns: new[] { "ID", "Key", "LastDateUpdated", "Value" },
                values: new object[] { 2, "SESSION_TIME", new DateTime(2022, 9, 12, 9, 45, 0, 492, DateTimeKind.Local).AddTicks(1081), "120" });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "SystemUsers",
                columns: new[] { "ID", "CreateDate", "FullName", "LastLoginDate", "Mail", "Password", "UserName" },
                values: new object[] { 1, new DateTime(2022, 9, 12, 9, 45, 0, 492, DateTimeKind.Local).AddTicks(972), "Administrador do Sistema", null, "andersonandi_t@hotmail.com", "123", "admin" });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "SystemUserPermissions",
                columns: new[] { "ID", "Role", "SystemUserId" },
                values: new object[] { 1, "CanManageSystemUsers", 1 });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "SystemUserPermissions",
                columns: new[] { "ID", "Role", "SystemUserId" },
                values: new object[] { 2, "CanManageObjects", 1 });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "SystemUserPermissions",
                columns: new[] { "ID", "Role", "SystemUserId" },
                values: new object[] { 3, "CanChangeGeneralSettings", 1 });

            migrationBuilder.CreateIndex(
                name: "IX_RecoveryPassword_SystemUserID",
                schema: "dbo",
                table: "RecoveryPassword",
                column: "SystemUserID");

            migrationBuilder.CreateIndex(
                name: "IX_SystemUserPermissions_SystemUserId",
                schema: "dbo",
                table: "SystemUserPermissions",
                column: "SystemUserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Parameters",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "RecoveryPassword",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "SystemUserPermissions",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Users",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "SystemUsers",
                schema: "dbo");
        }
    }
}
