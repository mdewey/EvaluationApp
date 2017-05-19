using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EvaluationApp.Data.Migrations
{
    public partial class ConnectionsRedo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Courses_Lectures_LecturesId",
                table: "Courses");

            migrationBuilder.DropForeignKey(
                name: "FK_Lecturers_Courses_CoursesId",
                table: "Lecturers");

            migrationBuilder.DropIndex(
                name: "IX_Lecturers_CoursesId",
                table: "Lecturers");

            migrationBuilder.DropColumn(
                name: "CourseID",
                table: "Lecturers");

            migrationBuilder.DropColumn(
                name: "CoursesId",
                table: "Lecturers");

            migrationBuilder.DropColumn(
                name: "LectureID",
                table: "Courses");

            migrationBuilder.RenameColumn(
                name: "LecturesId",
                table: "Courses",
                newName: "LecturersId");

            migrationBuilder.RenameIndex(
                name: "IX_Courses_LecturesId",
                table: "Courses",
                newName: "IX_Courses_LecturersId");

            migrationBuilder.AddColumn<int>(
                name: "CoursesId",
                table: "Lectures",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Lectures_CoursesId",
                table: "Lectures",
                column: "CoursesId");

            migrationBuilder.AddForeignKey(
                name: "FK_Courses_Lecturers_LecturersId",
                table: "Courses",
                column: "LecturersId",
                principalTable: "Lecturers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Lectures_Courses_CoursesId",
                table: "Lectures",
                column: "CoursesId",
                principalTable: "Courses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Courses_Lecturers_LecturersId",
                table: "Courses");

            migrationBuilder.DropForeignKey(
                name: "FK_Lectures_Courses_CoursesId",
                table: "Lectures");

            migrationBuilder.DropIndex(
                name: "IX_Lectures_CoursesId",
                table: "Lectures");

            migrationBuilder.DropColumn(
                name: "CoursesId",
                table: "Lectures");

            migrationBuilder.RenameColumn(
                name: "LecturersId",
                table: "Courses",
                newName: "LecturesId");

            migrationBuilder.RenameIndex(
                name: "IX_Courses_LecturersId",
                table: "Courses",
                newName: "IX_Courses_LecturesId");

            migrationBuilder.AddColumn<int>(
                name: "CourseID",
                table: "Lecturers",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CoursesId",
                table: "Lecturers",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "LectureID",
                table: "Courses",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Lecturers_CoursesId",
                table: "Lecturers",
                column: "CoursesId");

            migrationBuilder.AddForeignKey(
                name: "FK_Courses_Lectures_LecturesId",
                table: "Courses",
                column: "LecturesId",
                principalTable: "Lectures",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Lecturers_Courses_CoursesId",
                table: "Lecturers",
                column: "CoursesId",
                principalTable: "Courses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
