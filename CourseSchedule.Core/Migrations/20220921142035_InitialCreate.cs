﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CourseSchedule.Core.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Combination",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    LogicalOperator = table.Column<int>(type: "integer", nullable: false),
                    Created = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Modified = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Combination", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Course",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Credits = table.Column<int>(type: "integer", nullable: false),
                    CourseCode = table.Column<string>(type: "text", nullable: false),
                    Created = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Modified = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Course", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Institutions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    PublicKey = table.Column<Guid>(type: "uuid", nullable: false),
                    SecretKey = table.Column<Guid>(type: "uuid", nullable: false),
                    Created = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Modified = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Institutions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CombinationCourse",
                columns: table => new
                {
                    CombinationsId = table.Column<Guid>(type: "uuid", nullable: false),
                    CoursesId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CombinationCourse", x => new { x.CombinationsId, x.CoursesId });
                    table.ForeignKey(
                        name: "FK_CombinationCourse_Combination_CombinationsId",
                        column: x => x.CombinationsId,
                        principalTable: "Combination",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CombinationCourse_Course_CoursesId",
                        column: x => x.CoursesId,
                        principalTable: "Course",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Disciplines",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    MajorCode = table.Column<string>(type: "text", nullable: false),
                    IsMajor = table.Column<bool>(type: "boolean", nullable: false),
                    InstitutionId = table.Column<Guid>(type: "uuid", nullable: false),
                    Created = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Modified = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Disciplines", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Disciplines_Institutions_InstitutionId",
                        column: x => x.InstitutionId,
                        principalTable: "Institutions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Semester",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    InstitutionId = table.Column<Guid>(type: "uuid", nullable: false),
                    Created = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Modified = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Semester", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Semester_Institutions_InstitutionId",
                        column: x => x.InstitutionId,
                        principalTable: "Institutions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Year",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    InstitutionId = table.Column<Guid>(type: "uuid", nullable: false),
                    Created = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Modified = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Year", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Year_Institutions_InstitutionId",
                        column: x => x.InstitutionId,
                        principalTable: "Institutions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CourseDiscipline",
                columns: table => new
                {
                    CoursesId = table.Column<Guid>(type: "uuid", nullable: false),
                    DisciplinesId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourseDiscipline", x => new { x.CoursesId, x.DisciplinesId });
                    table.ForeignKey(
                        name: "FK_CourseDiscipline_Course_CoursesId",
                        column: x => x.CoursesId,
                        principalTable: "Course",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CourseDiscipline_Disciplines_DisciplinesId",
                        column: x => x.DisciplinesId,
                        principalTable: "Disciplines",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CourseSemester",
                columns: table => new
                {
                    CoursesId = table.Column<Guid>(type: "uuid", nullable: false),
                    SemestersId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourseSemester", x => new { x.CoursesId, x.SemestersId });
                    table.ForeignKey(
                        name: "FK_CourseSemester_Course_CoursesId",
                        column: x => x.CoursesId,
                        principalTable: "Course",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CourseSemester_Semester_SemestersId",
                        column: x => x.SemestersId,
                        principalTable: "Semester",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CourseYear",
                columns: table => new
                {
                    CoursesId = table.Column<Guid>(type: "uuid", nullable: false),
                    YearsId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourseYear", x => new { x.CoursesId, x.YearsId });
                    table.ForeignKey(
                        name: "FK_CourseYear_Course_CoursesId",
                        column: x => x.CoursesId,
                        principalTable: "Course",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CourseYear_Year_YearsId",
                        column: x => x.YearsId,
                        principalTable: "Year",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CombinationCourse_CoursesId",
                table: "CombinationCourse",
                column: "CoursesId");

            migrationBuilder.CreateIndex(
                name: "IX_CourseDiscipline_DisciplinesId",
                table: "CourseDiscipline",
                column: "DisciplinesId");

            migrationBuilder.CreateIndex(
                name: "IX_CourseSemester_SemestersId",
                table: "CourseSemester",
                column: "SemestersId");

            migrationBuilder.CreateIndex(
                name: "IX_CourseYear_YearsId",
                table: "CourseYear",
                column: "YearsId");

            migrationBuilder.CreateIndex(
                name: "IX_Disciplines_InstitutionId",
                table: "Disciplines",
                column: "InstitutionId");

            migrationBuilder.CreateIndex(
                name: "IX_Semester_InstitutionId",
                table: "Semester",
                column: "InstitutionId");

            migrationBuilder.CreateIndex(
                name: "IX_Year_InstitutionId",
                table: "Year",
                column: "InstitutionId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CombinationCourse");

            migrationBuilder.DropTable(
                name: "CourseDiscipline");

            migrationBuilder.DropTable(
                name: "CourseSemester");

            migrationBuilder.DropTable(
                name: "CourseYear");

            migrationBuilder.DropTable(
                name: "Combination");

            migrationBuilder.DropTable(
                name: "Disciplines");

            migrationBuilder.DropTable(
                name: "Semester");

            migrationBuilder.DropTable(
                name: "Course");

            migrationBuilder.DropTable(
                name: "Year");

            migrationBuilder.DropTable(
                name: "Institutions");
        }
    }
}