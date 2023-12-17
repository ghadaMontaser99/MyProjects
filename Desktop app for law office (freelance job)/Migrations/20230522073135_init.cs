using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace project.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Case",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SerialNumber = table.Column<int>(type: "int", nullable: false),
                    CaseNumber = table.Column<int>(type: "int", nullable: false),
                    ClientName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Case", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CourtDates",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourtDates", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Passwored = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Role = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ImagesCases",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CaseImage = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    CaseId = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ImagesCases", x => x.id);
                    table.ForeignKey(
                        name: "FK_ImagesCases_Case_CaseId",
                        column: x => x.CaseId,
                        principalTable: "Case",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Case_Court_dates",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Court_DatesId = table.Column<int>(type: "int", nullable: false),
                    CaseID = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Case_Court_dates", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Case_Court_dates_Case_CaseID",
                        column: x => x.CaseID,
                        principalTable: "Case",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Case_Court_dates_CourtDates_Court_DatesId",
                        column: x => x.Court_DatesId,
                        principalTable: "CourtDates",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "CaseUser",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CaseId = table.Column<int>(type: "int", nullable: false),
                    UsersId = table.Column<int>(type: "int", nullable: false),
                    Action = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CaseUser", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CaseUser_Case_CaseId",
                        column: x => x.CaseId,
                        principalTable: "Case",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_CaseUser_Users_UsersId",
                        column: x => x.UsersId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Case_Court_dates_CaseID",
                table: "Case_Court_dates",
                column: "CaseID");

            migrationBuilder.CreateIndex(
                name: "IX_Case_Court_dates_Court_DatesId",
                table: "Case_Court_dates",
                column: "Court_DatesId");

            migrationBuilder.CreateIndex(
                name: "IX_CaseUser_CaseId",
                table: "CaseUser",
                column: "CaseId");

            migrationBuilder.CreateIndex(
                name: "IX_CaseUser_UsersId",
                table: "CaseUser",
                column: "UsersId");

            migrationBuilder.CreateIndex(
                name: "IX_ImagesCases_CaseId",
                table: "ImagesCases",
                column: "CaseId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Case_Court_dates");

            migrationBuilder.DropTable(
                name: "CaseUser");

            migrationBuilder.DropTable(
                name: "ImagesCases");

            migrationBuilder.DropTable(
                name: "CourtDates");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Case");
        }
    }
}
