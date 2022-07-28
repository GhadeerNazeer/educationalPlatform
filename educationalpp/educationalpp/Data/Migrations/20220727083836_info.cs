using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace educationalpp.Data.Migrations
{
    public partial class info : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "department",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_department", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "teacher",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GenderId = table.Column<int>(type: "int", nullable: false),
                    Date_of_Birth = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Date_of_employment = table.Column<DateTime>(type: "datetime2", nullable: true),
                    address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_teacher", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "course",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    start_date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    end_date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    hours = table.Column<int>(type: "int", nullable: false),
                    price = table.Column<float>(type: "real", nullable: true),
                    teacherid = table.Column<int>(type: "int", nullable: true),
                    departmentid = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_course", x => x.id);
                    table.ForeignKey(
                        name: "FK_course_department_departmentid",
                        column: x => x.departmentid,
                        principalTable: "department",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_course_teacher_teacherid",
                        column: x => x.teacherid,
                        principalTable: "teacher",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "courses_and_student",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    studentid = table.Column<int>(type: "int", nullable: true),
                    courseid = table.Column<int>(type: "int", nullable: true),
                    mark = table.Column<float>(type: "real", nullable: false),
                    student_status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    total_payment = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_courses_and_student", x => x.Id);
                    table.ForeignKey(
                        name: "FK_courses_and_student_course_courseid",
                        column: x => x.courseid,
                        principalTable: "course",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_courses_and_student_student_studentid",
                        column: x => x.studentid,
                        principalTable: "student",
                        principalColumn: "id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_course_departmentid",
                table: "course",
                column: "departmentid");

            migrationBuilder.CreateIndex(
                name: "IX_course_teacherid",
                table: "course",
                column: "teacherid");

            migrationBuilder.CreateIndex(
                name: "IX_courses_and_student_courseid",
                table: "courses_and_student",
                column: "courseid");

            migrationBuilder.CreateIndex(
                name: "IX_courses_and_student_studentid",
                table: "courses_and_student",
                column: "studentid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "courses_and_student");

            migrationBuilder.DropTable(
                name: "course");

            migrationBuilder.DropTable(
                name: "department");

            migrationBuilder.DropTable(
                name: "teacher");
        }
    }
}
