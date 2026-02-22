using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PromptStorageApi.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "dbo");

            migrationBuilder.CreateTable(
                name: "AIGenerator",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false),
                    WebsiteUrl = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    CreatedAtUtc = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAtUtc = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AIGenerator", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Show",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(120)", maxLength: 120, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    CreatedAtUtc = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAtUtc = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Show", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Performance",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(120)", maxLength: 120, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    DateUtc = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ShowId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedAtUtc = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAtUtc = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Performance", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Performance_Show_ShowId",
                        column: x => x.ShowId,
                        principalSchema: "dbo",
                        principalTable: "Show",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Scene",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(120)", maxLength: 120, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    Order = table.Column<int>(type: "int", nullable: false),
                    PerformanceId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedAtUtc = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAtUtc = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Scene", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Scene_Performance_PerformanceId",
                        column: x => x.PerformanceId,
                        principalSchema: "dbo",
                        principalTable: "Performance",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Prompt",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    Body = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Tags = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AIGeneratorId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SceneId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedAtUtc = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAtUtc = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Prompt", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Prompt_AIGenerator_AIGeneratorId",
                        column: x => x.AIGeneratorId,
                        principalSchema: "dbo",
                        principalTable: "AIGenerator",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Prompt_Scene_SceneId",
                        column: x => x.SceneId,
                        principalSchema: "dbo",
                        principalTable: "Scene",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AIGenerator_Name",
                schema: "dbo",
                table: "AIGenerator",
                column: "Name");

            migrationBuilder.CreateIndex(
                name: "IX_Performance_CreatedAtUtc",
                schema: "dbo",
                table: "Performance",
                column: "CreatedAtUtc");

            migrationBuilder.CreateIndex(
                name: "IX_Performance_ShowId",
                schema: "dbo",
                table: "Performance",
                column: "ShowId");

            migrationBuilder.CreateIndex(
                name: "IX_Performance_Title",
                schema: "dbo",
                table: "Performance",
                column: "Title");

            migrationBuilder.CreateIndex(
                name: "IX_Prompt_AIGeneratorId",
                schema: "dbo",
                table: "Prompt",
                column: "AIGeneratorId");

            migrationBuilder.CreateIndex(
                name: "IX_Prompt_CreatedAtUtc",
                schema: "dbo",
                table: "Prompt",
                column: "CreatedAtUtc");

            migrationBuilder.CreateIndex(
                name: "IX_Prompt_SceneId",
                schema: "dbo",
                table: "Prompt",
                column: "SceneId");

            migrationBuilder.CreateIndex(
                name: "IX_Prompt_Title",
                schema: "dbo",
                table: "Prompt",
                column: "Title");

            migrationBuilder.CreateIndex(
                name: "IX_Scene_CreatedAtUtc",
                schema: "dbo",
                table: "Scene",
                column: "CreatedAtUtc");

            migrationBuilder.CreateIndex(
                name: "IX_Scene_PerformanceId",
                schema: "dbo",
                table: "Scene",
                column: "PerformanceId");

            migrationBuilder.CreateIndex(
                name: "IX_Scene_Title",
                schema: "dbo",
                table: "Scene",
                column: "Title");

            migrationBuilder.CreateIndex(
                name: "IX_Show_CreatedAtUtc",
                schema: "dbo",
                table: "Show",
                column: "CreatedAtUtc");

            migrationBuilder.CreateIndex(
                name: "IX_Show_Name",
                schema: "dbo",
                table: "Show",
                column: "Name");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Prompt",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "AIGenerator",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Scene",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Performance",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Show",
                schema: "dbo");
        }
    }
}
