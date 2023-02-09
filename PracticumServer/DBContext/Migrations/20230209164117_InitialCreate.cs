using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DBContext.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "HMO",
                columns: table => new
                {
                    idHMO = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HMO = table.Column<string>(type: "nchar(10)", fixedLength: true, maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HMO", x => x.idHMO);
                });

            migrationBuilder.CreateTable(
                name: "Sex",
                columns: table => new
                {
                    idSex = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    sex = table.Column<string>(type: "nchar(10)", fixedLength: true, maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sex", x => x.idSex);
                });

            migrationBuilder.CreateTable(
                name: "Status",
                columns: table => new
                {
                    idStatus = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    status = table.Column<string>(type: "nchar(10)", fixedLength: true, maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Status", x => x.idStatus);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    idUser = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    idFamily = table.Column<string>(type: "nchar(9)", fixedLength: true, maxLength: 9, nullable: false),
                    firstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    lastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    id = table.Column<string>(type: "nchar(9)", fixedLength: true, maxLength: 9, nullable: true),
                    birthDate = table.Column<DateTime>(type: "date", nullable: false),
                    idSex = table.Column<int>(type: "int", nullable: true),
                    idHMO = table.Column<int>(type: "int", nullable: true),
                    idStatus = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.idUser);
                    table.ForeignKey(
                        name: "FK_User_HMO",
                        column: x => x.idHMO,
                        principalTable: "HMO",
                        principalColumn: "idHMO");
                    table.ForeignKey(
                        name: "FK_User_Sex",
                        column: x => x.idSex,
                        principalTable: "Sex",
                        principalColumn: "idSex");
                    table.ForeignKey(
                        name: "FK_User_Status",
                        column: x => x.idStatus,
                        principalTable: "Status",
                        principalColumn: "idStatus");
                });

            migrationBuilder.CreateIndex(
                name: "IX_User_idHMO",
                table: "User",
                column: "idHMO");

            migrationBuilder.CreateIndex(
                name: "IX_User_idSex",
                table: "User",
                column: "idSex");

            migrationBuilder.CreateIndex(
                name: "IX_User_idStatus",
                table: "User",
                column: "idStatus");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "HMO");

            migrationBuilder.DropTable(
                name: "Sex");

            migrationBuilder.DropTable(
                name: "Status");
        }
    }
}
