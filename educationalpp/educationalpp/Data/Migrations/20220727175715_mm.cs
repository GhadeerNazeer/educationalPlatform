using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace educationalpp.Data.Migrations
{
    public partial class mm : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Date_of_Birth",
                table: "student",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "coursestudentmodel",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    mark = table.Column<float>(type: "real", nullable: false),
                    student_status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    total_payment = table.Column<float>(type: "real", nullable: false),
                    studentid = table.Column<int>(type: "int", nullable: true),
                    courseid = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "courseviewmodel",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    hours = table.Column<int>(type: "int", nullable: false),
                    price = table.Column<float>(type: "real", nullable: true),
                    start_date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    end_date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    teacherid = table.Column<int>(type: "int", nullable: false),
                    departmentid = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "coursestudentmodel");

            migrationBuilder.DropTable(
                name: "courseviewmodel");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Date_of_Birth",
                table: "student",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);
        }
    }
}
