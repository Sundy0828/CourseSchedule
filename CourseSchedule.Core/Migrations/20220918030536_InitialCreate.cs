using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CourseSchedule.Core.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "institutions",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    PublicKey = table.Column<Guid>(type: "uuid", nullable: false),
                    SecretKey = table.Column<Guid>(type: "uuid", nullable: false),
                    created = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    modified = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_institutions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "disciplines",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    IsMajor = table.Column<bool>(type: "boolean", nullable: false),
                    InstitutionId = table.Column<Guid>(type: "uuid", nullable: false),
                    InstitutionId1 = table.Column<string>(type: "text", nullable: true),
                    created = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    modified = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_disciplines", x => x.Id);
                    table.ForeignKey(
                        name: "FK_disciplines_institutions_InstitutionId1",
                        column: x => x.InstitutionId1,
                        principalTable: "institutions",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_disciplines_InstitutionId1",
                table: "disciplines",
                column: "InstitutionId1");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "disciplines");

            migrationBuilder.DropTable(
                name: "institutions");
        }
    }
}
