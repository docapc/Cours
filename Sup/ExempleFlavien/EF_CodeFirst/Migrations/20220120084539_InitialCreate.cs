using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EF_CodeFirst.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ThemeEx",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ThemeName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PrimaryKey_ThemeId", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Questions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    QuestionText = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ThemeExId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PrimaryKey_QuestionId", x => x.Id);
                    table.ForeignKey(
                        name: "Question_In_Theme",
                        column: x => x.ThemeExId,
                        principalTable: "ThemeEx",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Reponses",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ReponseText = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ReponseExplication = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    QuestionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    isTrool = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PrimaryKey_ReponseId", x => x.Id);
                    table.ForeignKey(
                        name: "Reponses_In_Question",
                        column: x => x.QuestionId,
                        principalTable: "Questions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Links",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Element = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ReponseId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PrimaryKey_LinksId", x => x.Id);
                    table.ForeignKey(
                        name: "Link_In_Response",
                        column: x => x.ReponseId,
                        principalTable: "Reponses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Links_ReponseId",
                table: "Links",
                column: "ReponseId");

            migrationBuilder.CreateIndex(
                name: "IX_Questions_ThemeExId",
                table: "Questions",
                column: "ThemeExId");

            migrationBuilder.CreateIndex(
                name: "IX_Reponses_QuestionId",
                table: "Reponses",
                column: "QuestionId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Links");

            migrationBuilder.DropTable(
                name: "Reponses");

            migrationBuilder.DropTable(
                name: "Questions");

            migrationBuilder.DropTable(
                name: "ThemeEx");
        }
    }
}
