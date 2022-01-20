using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EF_CodeFirst.Migrations
{
    public partial class AddedUserLinks : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "UserQuizz",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PathMiniature = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsAdmin = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PrimaryKey_UserQuizzId", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LinksUserQuizz",
                columns: table => new
                {
                    LinksId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserQuizzId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LinksUserQuizz", x => new { x.LinksId, x.UserQuizzId });
                    table.ForeignKey(
                        name: "FK_LinksUserQuizz_Links_LinksId",
                        column: x => x.LinksId,
                        principalTable: "Links",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LinksUserQuizz_UserQuizz_UserQuizzId",
                        column: x => x.UserQuizzId,
                        principalTable: "UserQuizz",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "QuestionUserQuizz",
                columns: table => new
                {
                    QuestionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserQuizzId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuestionUserQuizz", x => new { x.QuestionId, x.UserQuizzId });
                    table.ForeignKey(
                        name: "FK_QuestionUserQuizz_Questions_QuestionId",
                        column: x => x.QuestionId,
                        principalTable: "Questions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_QuestionUserQuizz_UserQuizz_UserQuizzId",
                        column: x => x.UserQuizzId,
                        principalTable: "UserQuizz",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ReponseUserQuizz",
                columns: table => new
                {
                    ReponseId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserQuizzId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReponseUserQuizz", x => new { x.ReponseId, x.UserQuizzId });
                    table.ForeignKey(
                        name: "FK_ReponseUserQuizz_Reponses_ReponseId",
                        column: x => x.ReponseId,
                        principalTable: "Reponses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ReponseUserQuizz_UserQuizz_UserQuizzId",
                        column: x => x.UserQuizzId,
                        principalTable: "UserQuizz",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ThemeExUserQuizz",
                columns: table => new
                {
                    ThemeExId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserQuizzId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ThemeExUserQuizz", x => new { x.ThemeExId, x.UserQuizzId });
                    table.ForeignKey(
                        name: "FK_ThemeExUserQuizz_ThemeEx_ThemeExId",
                        column: x => x.ThemeExId,
                        principalTable: "ThemeEx",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ThemeExUserQuizz_UserQuizz_UserQuizzId",
                        column: x => x.UserQuizzId,
                        principalTable: "UserQuizz",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_LinksUserQuizz_UserQuizzId",
                table: "LinksUserQuizz",
                column: "UserQuizzId");

            migrationBuilder.CreateIndex(
                name: "IX_QuestionUserQuizz_UserQuizzId",
                table: "QuestionUserQuizz",
                column: "UserQuizzId");

            migrationBuilder.CreateIndex(
                name: "IX_ReponseUserQuizz_UserQuizzId",
                table: "ReponseUserQuizz",
                column: "UserQuizzId");

            migrationBuilder.CreateIndex(
                name: "IX_ThemeExUserQuizz_UserQuizzId",
                table: "ThemeExUserQuizz",
                column: "UserQuizzId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LinksUserQuizz");

            migrationBuilder.DropTable(
                name: "QuestionUserQuizz");

            migrationBuilder.DropTable(
                name: "ReponseUserQuizz");

            migrationBuilder.DropTable(
                name: "ThemeExUserQuizz");

            migrationBuilder.DropTable(
                name: "UserQuizz");
        }
    }
}
