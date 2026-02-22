using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace PromptStorageApi.Migrations
{
    /// <inheritdoc />
    public partial class DbEnhancements : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedAtUtc",
                schema: "dbo",
                table: "Show",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                schema: "dbo",
                table: "Show",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<byte[]>(
                name: "RowVersion",
                schema: "dbo",
                table: "Show",
                type: "rowversion",
                rowVersion: true,
                nullable: false,
                defaultValue: new byte[0]);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedAtUtc",
                schema: "dbo",
                table: "Scene",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                schema: "dbo",
                table: "Scene",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<byte[]>(
                name: "RowVersion",
                schema: "dbo",
                table: "Scene",
                type: "rowversion",
                rowVersion: true,
                nullable: false,
                defaultValue: new byte[0]);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedAtUtc",
                schema: "dbo",
                table: "Prompt",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                schema: "dbo",
                table: "Prompt",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<byte[]>(
                name: "RowVersion",
                schema: "dbo",
                table: "Prompt",
                type: "rowversion",
                rowVersion: true,
                nullable: false,
                defaultValue: new byte[0]);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedAtUtc",
                schema: "dbo",
                table: "Performance",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                schema: "dbo",
                table: "Performance",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<byte[]>(
                name: "RowVersion",
                schema: "dbo",
                table: "Performance",
                type: "rowversion",
                rowVersion: true,
                nullable: false,
                defaultValue: new byte[0]);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedAtUtc",
                schema: "dbo",
                table: "AIGenerator",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                schema: "dbo",
                table: "AIGenerator",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<byte[]>(
                name: "RowVersion",
                schema: "dbo",
                table: "AIGenerator",
                type: "rowversion",
                rowVersion: true,
                nullable: false,
                defaultValue: new byte[0]);

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "AIGenerator",
                columns: new[] { "Id", "CreatedAtUtc", "CreatedBy", "DeletedAtUtc", "IsDeleted", "Name", "UpdatedAtUtc", "UpdatedBy", "WebsiteUrl" },
                values: new object[,]
                {
                    { new Guid("11111111-1111-1111-1111-111111111111"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "System", null, false, "OpenAI", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "System", "https://openai.com" },
                    { new Guid("22222222-2222-2222-2222-222222222222"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "System", null, false, "Gemini", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "System", "https://gemini.google.com" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "AIGenerator",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111111"));

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "AIGenerator",
                keyColumn: "Id",
                keyValue: new Guid("22222222-2222-2222-2222-222222222222"));

            migrationBuilder.DropColumn(
                name: "DeletedAtUtc",
                schema: "dbo",
                table: "Show");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                schema: "dbo",
                table: "Show");

            migrationBuilder.DropColumn(
                name: "RowVersion",
                schema: "dbo",
                table: "Show");

            migrationBuilder.DropColumn(
                name: "DeletedAtUtc",
                schema: "dbo",
                table: "Scene");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                schema: "dbo",
                table: "Scene");

            migrationBuilder.DropColumn(
                name: "RowVersion",
                schema: "dbo",
                table: "Scene");

            migrationBuilder.DropColumn(
                name: "DeletedAtUtc",
                schema: "dbo",
                table: "Prompt");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                schema: "dbo",
                table: "Prompt");

            migrationBuilder.DropColumn(
                name: "RowVersion",
                schema: "dbo",
                table: "Prompt");

            migrationBuilder.DropColumn(
                name: "DeletedAtUtc",
                schema: "dbo",
                table: "Performance");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                schema: "dbo",
                table: "Performance");

            migrationBuilder.DropColumn(
                name: "RowVersion",
                schema: "dbo",
                table: "Performance");

            migrationBuilder.DropColumn(
                name: "DeletedAtUtc",
                schema: "dbo",
                table: "AIGenerator");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                schema: "dbo",
                table: "AIGenerator");

            migrationBuilder.DropColumn(
                name: "RowVersion",
                schema: "dbo",
                table: "AIGenerator");
        }
    }
}
