using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EvaluationApp.Data.Migrations
{
    public partial class RedoAgain : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Courses_Lecturers_LecturersId",
                table: "Courses");

            migrationBuilder.DropForeignKey(
                name: "FK_Lectures_Courses_CoursesId",
                table: "Lectures");

            migrationBuilder.DropForeignKey(
                name: "FK_Lectures_Students_StudentsId",
                table: "Lectures");

            migrationBuilder.DropIndex(
                name: "IX_Lectures_StudentsId",
                table: "Lectures");

            migrationBuilder.DropColumn(
                name: "StudentID",
                table: "Lectures");

            migrationBuilder.DropColumn(
                name: "StudentsId",
                table: "Lectures");

            migrationBuilder.RenameColumn(
                name: "QuestionID",
                table: "Students",
                newName: "QuestionId");

            migrationBuilder.RenameColumn(
                name: "DataID",
                table: "Students",
                newName: "DataId");

            migrationBuilder.RenameColumn(
                name: "StudentID",
                table: "DataOfUnderstanding",
                newName: "StudentId");

            migrationBuilder.AlterColumn<int>(
                name: "CoursesId",
                table: "Lectures",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "LecturersId",
                table: "Courses",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Courses_Lecturers_LecturersId",
                table: "Courses",
                column: "LecturersId",
                principalTable: "Lecturers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Lectures_Courses_CoursesId",
                table: "Lectures",
                column: "CoursesId",
                principalTable: "Courses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Courses_Lecturers_LecturersId",
                table: "Courses");

            migrationBuilder.DropForeignKey(
                name: "FK_Lectures_Courses_CoursesId",
                table: "Lectures");

            migrationBuilder.RenameColumn(
                name: "QuestionId",
                table: "Students",
                newName: "QuestionID");

            migrationBuilder.RenameColumn(
                name: "DataId",
                table: "Students",
                newName: "DataID");

            migrationBuilder.RenameColumn(
                name: "StudentId",
                table: "DataOfUnderstanding",
                newName: "StudentID");

            migrationBuilder.AlterColumn<int>(
                name: "CoursesId",
                table: "Lectures",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<int>(
                name: "StudentID",
                table: "Lectures",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "StudentsId",
                table: "Lectures",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "LecturersId",
                table: "Courses",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.CreateIndex(
                name: "IX_Lectures_StudentsId",
                table: "Lectures",
                column: "StudentsId");

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

            migrationBuilder.AddForeignKey(
                name: "FK_Lectures_Students_StudentsId",
                table: "Lectures",
                column: "StudentsId",
                principalTable: "Students",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
